using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        public int Id { get; }
        public List<Line> Lines;

        public Point(int x, int y, int id)
        {
            X = x;
            Y = y;
            Id = id;
            Lines = new List<Line>();
        }

        public override int GetHashCode()
        {
            return (X.GetHashCode() * Y.GetHashCode() * Id.GetHashCode()) ^ 397;
        }

        public override bool Equals(object obj)
        {
            var p = obj as Point;
            if (p == this) return true;
            return base.Equals(obj);
        }

        public static bool operator ==(Point left, Point right) 
            => left.X == right.X && left.Y == right.Y && left.Id == right.Id;

        public static bool operator !=(Point left, Point right)
            => left.X != right.X || left.Y != right.Y || left.Id != right.Id;
    }
}
