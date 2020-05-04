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
            this.Size = size;
            this.game = new Core.Game(playersNames, playersCount, realPlayersCount);
            this.game.StartLevel(size, size);
            SoundPlayer gameMedia = new SoundPlayer(Properties.Resources.bensound_punky);
            SoundPlayer buttonClick = new SoundPlayer(Properties.Resources.button_click);
            gameMedia.PlayLooping();
            var exitButton = new Button();
            table = new TableLayoutPanel();
            table.BackColor = Color.FromArgb(173, 216, 230);
            table.Location = new Point(2, 2);
            table.Size = new Size(76 * size, 76 * size);
            for (int i = 0; i < size; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / size));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / size));
            }
            for (int column = 0; column < size; column++)
                for (int row = 0; row < size; row++)
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
                    };
                    table.Controls.Add(button, column, row);
                }


            // Game Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(173, 216, 230);
            this.ClientSize = new Size(76 * size, 76 * size + 60);
            this.MinimumSize = new Size(76 * size, 76 * size+ 60);
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
                            button.BackgroundImage = Properties.Resources.circle;
                            break;
                        case 2:
                            button.BackgroundImage = Properties.Resources.cross;
                            break;
                        case 3:
                            button.BackgroundImage = Properties.Resources.triangle;
                            break;
                    }
                }
        }
    }
}
