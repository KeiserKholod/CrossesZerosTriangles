using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    public class Line
    {
        public int Length { get => Points.Count; }
        public List<Point> Points = new List<Point>();
        public readonly int Id;

        public Line(params Point[] points)
        {
            foreach (var p in points)
            {
                Id = p.Id;
                Points.Add(p);
            }
        }

        public static void Connect(Player player, Level level, Point p)
        {
            var neighbours = GetNeighbourPoints(level, p).ToList();
            if (IsIncorrectIEnumerable(neighbours))
            {
                var line = new Line(p);
                p.Lines.Add(line);
                player.Lines.Add(line);
                return;
            }
            var pairs = FindPairNeighbour(neighbours, p).ToList();
            if (!IsIncorrectIEnumerable(pairs))
                ConnectLineInPairs(player, pairs, p);
            foreach (var point in neighbours)
            {
                var correctLines = FindCorrectLineInPoint(p, point).ToList();
                if (IsIncorrectIEnumerable(correctLines))
                {
                    var line = new Line(p, point);
                    point.Lines.Add(line);
                    p.Lines.Add(line);
                    player.Lines.Add(line);
                    continue;
                }
                foreach (var line in correctLines)
                {
                    line.Points.Add(p);
                    p.Lines.Add(line);
                }
            }
        }

        private static void ConnectLineInPairs(Player player, IEnumerable<Tuple<Point, Point>> pairs, Point p)
        {
            foreach (var pair in pairs)
            {
                var firstLines = FindCorrectLineInPoint(p, pair.Item1);
                var secondLines = FindCorrectLineInPoint(p, pair.Item2);
                var firstIncorrect = IsIncorrectIEnumerable(firstLines);
                var secondIncorrect = IsIncorrectIEnumerable(secondLines);
                if (firstIncorrect)
                    if (secondIncorrect)
                        ConnectPairWithoutCorrectLines(player, p, pair);
                    else
                        ConnectPairFirstIncorrect(secondLines, p, pair);
                else
                    if (secondIncorrect)
                        ConnectPairSecondIncorrect(firstLines, p, pair);
                else
                    ConnectPairBothCorrect(player, firstLines.First(), secondLines.First(), p);
            }
        }

        private static void ConnectPairBothCorrect(Player player, Line line1, Line line2, Point p)
        {
            line1.Points = line1.Points.Concat(line2.Points).ToList();
            foreach (var point in line2.Points)
            {
                point.Lines.Add(line1);
                point.Lines.Remove(line2);
                player.Lines.Remove(line2);
            }
            line1.Points.Add(p);
            p.Lines.Add(line1);
        }

        private static void ConnectPairFirstIncorrect(IEnumerable<Line> secondLines, Point p, Tuple<Point, Point> pair)
        {
            foreach (var line in secondLines)
            {
                line.Points.Add(p);
                p.Lines.Add(line);
                line.Points.Add(pair.Item1);
                pair.Item1.Lines.Add(line);
            }
        }

        private static void ConnectPairSecondIncorrect(IEnumerable<Line> firstLines, Point p, Tuple<Point, Point> pair)
        {
            foreach (var line in firstLines)
            {
                line.Points.Add(p);
                p.Lines.Add(line);
                line.Points.Add(pair.Item2);
                pair.Item2.Lines.Add(line);
            }
        }

        private static void ConnectPairWithoutCorrectLines(Player player, Point p, Tuple<Point, Point> pair)
        {
            var line = new Line(p, pair.Item1, pair.Item2);
            pair.Item1.Lines.Add(line);
            pair.Item2.Lines.Add(line);
            p.Lines.Add(line);
            player.Lines.Add(line);
        }

        private static IEnumerable<Tuple<Point,Point>> FindPairNeighbour(List<Point> neighbour, Point center)
        {
            for (var dy = 0; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    if (dx == 0 && dy == 0) continue;
                    if (dy == 0 && dx == 1) continue;
                    var first = new Point(center.X + dx, center.Y + dy, center.Id);
                    var second = new Point(center.X - dx, center.Y - dy, center.Id);
                    if (neighbour.Contains(first) && neighbour.Contains(second))
                    {
                        yield return Tuple.Create(neighbour.Find(x => x == first),
                            neighbour.Find(x => x == second));
                        neighbour.Remove(first);
                        neighbour.Remove(second);
                    }
                }
        }

        private static bool IsIncorrectIEnumerable<T>(IEnumerable<T> ienum) 
            => !ienum.Any() || ienum == null;

        private static IEnumerable<Line> FindCorrectLineInPoint(Point p, Point point)
            => point.Lines
            .Where(line => IsCorrectLine(p, line));

        private static bool IsCorrectLine(Point point, Line line)
        {
            var hor = line.Points.All(p => p.X == point.X);
            if (hor) return hor;
            var vert = line.Points.All(p => p.Y == point.Y);
            if (vert) return vert;
            //var vertical = line.Points.All(p => );
            // var cur = 1;
            foreach (var p in line.Points)
            {
                if (Math.Abs(p.X - point.X) == Math.Abs(p.Y - point.Y))
                {
                    //cur++;
                    continue;
                }
                return false;
            }
            return true;
        }

        private static bool IsCorrectLine(Point p1, Point p2)
        {
            if (p1.X == p2.X) return true;
            if (p1.Y == p2.Y) return true;
            return Math.Abs(p1.X - p2.X) == 1 && Math.Abs(p1.Y - p2.Y) == 1;
        }

        private static IEnumerable<Point> GetNeighbourPoints(Level level, Point point)
        {
            for (var dy = -1; dy <= 1; dy++)
                for (var dx = -1; dx <= 1; dx++)
                {
                    if (dx == 0 && dy == 0) continue;
                    if ((point.X + dx < 0 || point.X + dx >= level.width)
                        && (point.Y + dy < 0 || point.Y + dy >= level.height)) continue;
                    var curPoint = new Point(point.X + dx, point.Y + dy, point.Id);
                    if (level.settedPoints.Contains(curPoint))
                        yield return level.Points.Where(p => p == curPoint).First();
                }
        }
    }
}
