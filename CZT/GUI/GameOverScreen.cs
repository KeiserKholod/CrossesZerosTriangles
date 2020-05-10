using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CZT.GUI
{
    class GameOverScreen : Form
    {
        public GameOverScreen(int size, int playersCount, int realPlayersCount, List<string> playersNames, string winnerName, bool draw)
        {
            SoundPlayer buttonClick = new SoundPlayer(Properties.Resources.button_click);
            var exitMenuButton = new Button();
            var newGameButton = new Button();
            var label = new Label();

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(237, 238, 240);
            this.ClientSize = new Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(400, 200);
            this.MaximumSize = new Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.None;

            label.Location = new Point(0, 0);
            label.Size = new Size(400, 100);
            label.Text = "Game Over\n" + winnerName + " - win!";
            if (draw == true) label.Text = "Game Over\nDraw";
            label.BackColor = Color.FromArgb(237, 238, 240);
            label.Font = new Font("MV Boli", 20.00F);
            label.TextAlign = ContentAlignment.BottomCenter;

            newGameButton.Anchor = AnchorStyles.Left;
            newGameButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            newGameButton.Cursor = Cursors.Hand;
            newGameButton.FlatStyle = FlatStyle.Popup;
            newGameButton.Font = new Font("MV Boli", 20.25F);
            newGameButton.ImageAlign = ContentAlignment.BottomCenter;
            newGameButton.Location = new Point(230, 100);
            newGameButton.Text = "New";
            newGameButton.Size = new Size(100, 50);
            newGameButton.BackgroundImage = Properties.Resources.exit_button;
            newGameButton.Click += (sender, args) =>
            {
                buttonClick.Play();
                Thread.Sleep(150);
                this.Hide();
                GameScreen gameScreen = new GameScreen(size, playersCount, realPlayersCount, playersNames);
                gameScreen.Show();
            };

            exitMenuButton.Anchor = AnchorStyles.Left;
            exitMenuButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitMenuButton.Cursor = Cursors.Hand;
            exitMenuButton.FlatStyle = FlatStyle.Popup;
            exitMenuButton.Font = new Font("MV Boli", 20.25F);
            exitMenuButton.BackColor = Color.FromArgb(74, 118, 168);
            exitMenuButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitMenuButton.ImageAlign = ContentAlignment.BottomCenter;
            exitMenuButton.Location = new Point(70, 100);
            exitMenuButton.Text = "Menu";
            exitMenuButton.Size = new Size(100, 50);
            exitMenuButton.Click += (sender, args) =>
            {
                buttonClick.Play();
                Thread.Sleep(150);
                this.Hide();
                var mainMenu = new MainScreen(size, playersCount, realPlayersCount);
                mainMenu.Show();
            };

            Controls.Add(newGameButton);
            Controls.Add(label);
            Controls.Add(exitMenuButton);
        }
    }
}
