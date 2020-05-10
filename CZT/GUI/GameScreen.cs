using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Media;

namespace CZT.GUI
{
    class GameScreen : Form
    {
        public Core.Game game;
        TableLayoutPanel table;
        private int[,] Map;
        private int Size;

        public GameScreen(int size, int playersCount, int realPlayersCount, List<string> playersNames)
        {
            this.Size = (int)Math.Sqrt(Math.Pow((double)(playersCount + 1), (double)playersCount));
            this.game = new Core.Game(playersNames, playersCount, realPlayersCount);
<<<<<<< Updated upstream
            this.game.StartLevel(size, size, playersCount + 1);
=======
            this.game.StartLevel(this.Size, this.Size, playersCount + 1);
>>>>>>> Stashed changes
            SoundPlayer gameMedia = new SoundPlayer(Properties.Resources.bensound_punky);
            SoundPlayer buttonClick = new SoundPlayer(Properties.Resources.button_click);
            gameMedia.PlayLooping();
            var exitButton = new Button();
            table = new TableLayoutPanel();
            table.BackColor = Color.FromArgb(173, 216, 230);
            table.Location = new Point(2, 2);
            table.Size = new Size(76 * this.Size, 76 * this.Size);
            for (int i = 0; i < this.Size; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / this.Size));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / this.Size));
            }
            for (int column = 0; column < this.Size; column++)
                for (int row = 0; row < this.Size; row++)
                {
                    var button = new Button();
                    button.BackColor = Color.FromArgb(255, 255, 255);
                    button.Size = new Size(66, 66);
                    button.FlatStyle = FlatStyle.Standard;
                    button.Click += (senders, args) =>
                    {
                        var position = table.GetCellPosition((Control)senders);
                        this.game.CurrentLevel.MakeMove(position.Column, position.Row);
                        this.Map = this.game.CurrentLevel.Map;
                        ChangeMap();
                        if (!(this.game.CurrentLevel.Winner == null) || this.game.CurrentLevel.IsDraw == true)
                        {
                            var draw = this.game.CurrentLevel.IsDraw;
                            var winnerName = game.CurrentLevel.Winner.Name;
                            this.Hide();
                            gameMedia.Stop();
                            GameOverScreen gameOver = new GameOverScreen(size, playersCount, realPlayersCount, playersNames, winnerName, draw);
                            gameOver.Show();
                        }
                    };
                    table.Controls.Add(button, column, row);
                }


            // Game Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(173, 216, 230);
            this.ClientSize = new Size(76 * this.Size, 76 * this.Size + 60);
            this.MinimumSize = new Size(76 * this.Size, 76 * this.Size+ 60);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;

            exitButton.Anchor = AnchorStyles.Left;
            exitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitButton.Cursor = Cursors.Hand;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("MV Boli", 20.25F);
            exitButton.BackColor = Color.FromArgb(74, 118, 168);
            exitButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitButton.ImageAlign = ContentAlignment.BottomCenter;
            exitButton.Location = new Point(ClientSize.Width / 2 - 90, ClientSize.Height - 50);
            exitButton.Text = "Main Menu";
            exitButton.Size = new Size(180, 40);
            exitButton.Click += (sender, args) =>
            {
                buttonClick.Play();
                Thread.Sleep(150);
                gameMedia.Stop();
                this.Hide();
                var mainScreen = new MainScreen(size, 3, 3);
                mainScreen.Show();
            };

            Controls.Add(table);
            Controls.Add(exitButton);
        }

        void ChangeMap()
        {
            for (var x = 0; x < this.Size; x++)
                for (var y = 0; y < this.Size; y++)
                {
                    var button = (Button)table.GetControlFromPosition(x, y);
                    var sym = this.Map[x, y];
                    switch(sym)
                    {
                        case 1:
                            button.BackgroundImage = Properties.Resources.cross;
                            break;
                        case 2:
                            button.BackgroundImage = Properties.Resources.circle;
                            break;
                        case 3:
                            button.BackgroundImage = Properties.Resources.triangle;
                            break;
                    }
                }
        }
    }
}
