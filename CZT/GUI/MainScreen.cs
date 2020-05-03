using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CZT.GUI
{
    class MainScreen : Form
    {
        private int Size = 7;
        private int PlayersCount = 3;

        public MainScreen()
        {
            var label = new Label();
            var exitButton = new Button();
            var playButton = new Button();
            var exitFromSettingsButton = new Button();
            var settingsButton = new Button();


            label.Location = new Point(400, 100);
            label.Size = new Size(400, 50);
            label.Text = "Settings";
            label.BackColor = Color.FromArgb(255, 255, 0);
            label.Font = new Font("MV Boli", 20.00F);
            label.TextAlign = ContentAlignment.BottomCenter;

            label.Hide();

            // Main Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(255, 69, 0);
            this.ClientSize = new Size(1200, 600);
            this.MinimumSize = new Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "MainScreen";

            // "Exit" button settings
            exitButton.Anchor = AnchorStyles.Left;
            exitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitButton.Cursor = Cursors.Hand;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("MV Boli", 20.25F);
            exitButton.BackColor = Color.FromArgb(255, 255, 0);
            exitButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitButton.ImageAlign = ContentAlignment.BottomCenter;
            exitButton.Location = new Point((int)(ClientSize.Width * 6.6 / 100), (int)(ClientSize.Height / 2) + 140);
            exitButton.Text = "Exit";
            exitButton.Size = new Size(200, 50);
            exitButton.Click += (sender, args) =>
            {
                this.Hide();
                ExitScreen exitScreen = new ExitScreen();
                exitScreen.Show();
            };

            // "Play" button settings
            playButton.Anchor = AnchorStyles.Left;
            playButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            playButton.Cursor = Cursors.Hand;
            playButton.FlatStyle = FlatStyle.Popup;
            playButton.Font = new Font("MV Boli", 20.25F);
            playButton.BackColor = Color.FromArgb(255, 255, 0);
            playButton.ForeColor = Color.FromArgb(0, 0, 0);
            playButton.ImageAlign = ContentAlignment.BottomCenter;
            playButton.Location = new Point((int)(ClientSize.Width * 6.6 / 100), (int)(ClientSize.Height / 2));
            playButton.Text = "Play";
            playButton.Size = new Size(200, 50);
            playButton.Click += (sender, args) =>
            {
                this.Hide();
                var gameScreen = new GameScreen( Size = 5);
                gameScreen.Show();
            };

            //Кнопка выхода из настроек
            exitFromSettingsButton.Hide();
            exitFromSettingsButton.Anchor = AnchorStyles.Left;
            exitFromSettingsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitFromSettingsButton.Cursor = Cursors.Hand;
            exitFromSettingsButton.Font = new Font("MV Boli", 20.25F);
            exitFromSettingsButton.Text = "Back to Main menu";
            exitFromSettingsButton.FlatStyle = FlatStyle.Popup;
            exitFromSettingsButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitFromSettingsButton.ImageAlign = ContentAlignment.BottomCenter;
            exitFromSettingsButton.Location = new Point((int)(ClientSize.Width * 6.6 / 100), (int)(ClientSize.Height / 2) + 140);
            exitFromSettingsButton.Size = new Size(200, 50);
            exitFromSettingsButton.BackColor = Color.FromArgb(255, 255, 0);
            exitFromSettingsButton.Click += (sender, args) =>
            {
                playButton.Show();
                exitButton.Show();
                settingsButton.Show();
                label.Hide();
                exitFromSettingsButton.Hide();
            };

            // "Setting" button of game settings
            settingsButton.Anchor = AnchorStyles.Left;
            settingsButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            settingsButton.Cursor = Cursors.Hand;
            settingsButton.Font = new Font("MV Boli", 20.25F);
            settingsButton.Text = "Settings";
            settingsButton.FlatStyle = FlatStyle.Popup;
            settingsButton.ForeColor = Color.FromArgb(0, 0, 0);
            settingsButton.ImageAlign = ContentAlignment.BottomCenter;
            settingsButton.Location = new Point((int)(ClientSize.Width * 6.6 / 100), (int)(ClientSize.Height / 2) + 70);
            settingsButton.Size = new Size(200, 50);
            settingsButton.BackColor = Color.FromArgb(255, 255, 0);
            settingsButton.Click += (sender, args) =>
            {
                playButton.Hide();
                exitButton.Hide();
                settingsButton.Hide();
                label.Show();
                exitFromSettingsButton.Show();
            };


            Controls.Add(exitFromSettingsButton);
            Controls.Add(label);
            Controls.Add(settingsButton);
            Controls.Add(playButton);
            Controls.Add(exitButton);
        }
    }
}
