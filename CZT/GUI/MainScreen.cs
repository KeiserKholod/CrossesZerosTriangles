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
        public int Size = 5;
        public int PlayersCount = 3;
        public int RealPlayersCount = 3;
        public List<string> PlayersNickNames = new List<string>() { "Player1", "Player2", "Player3" };

        public MainScreen(int size, int playersCount, int realPlayesrCount)
        {
            Size = size;
            PlayersCount = playersCount;
            RealPlayersCount = realPlayesrCount;


            var label = new Label();
            var exitButton = new Button();
            var playButton = new Button();
            var exitFromSettingsButton = new Button();
            var settingsButton = new Button();
            var choosePlayersCount = new ComboBox();
            var chPlayersCountLabel = new Label();




            chPlayersCountLabel.Location = new Point(400, 180);
            chPlayersCountLabel.Size = new Size(240, 40);
            chPlayersCountLabel.Text = "Выберите режим игры";
            chPlayersCountLabel.BackColor = Color.FromArgb(74, 118, 168);
            chPlayersCountLabel.Font = new Font("MV Boli", 12.00F);
            chPlayersCountLabel.TextAlign = ContentAlignment.BottomCenter;
            chPlayersCountLabel.Hide();


            choosePlayersCount.Items.Add(new KeyValuePair<string, int[]>("1 игрок + 1 бот", new int[] { 1, 1 }));
            choosePlayersCount.Items.Add(new KeyValuePair<string, int[]>("1 игрок + 2 ботa", new int[] { 1, 2 }));
            choosePlayersCount.Items.Add(new KeyValuePair<string, int[]>("2 игрока + 0 ботов", new int[] { 2, 0 }));
            choosePlayersCount.Items.Add(new KeyValuePair<string, int[]>("2 игрока + 1 бот", new int[] { 2, 1 }));
            choosePlayersCount.Items.Add(new KeyValuePair<string, int[]>("3 игрока + 0 ботов", new int[] { 1, 1 }));
            choosePlayersCount.Location = new Point(400, 240);
            choosePlayersCount.BackColor = Color.FromArgb(237, 238, 240);
            choosePlayersCount.DisplayMember = "key";
            choosePlayersCount.ValueMember = "value";
            choosePlayersCount.Hide();
            choosePlayersCount.Size = new Size(240, 40);


            label.Location = new Point(400, 100);
            label.Size = new Size(400, 50);
            label.Text = "Settings";
            label.BackColor = Color.FromArgb(74, 118, 168);
            label.Font = new Font("MV Boli", 20.00F);
            label.TextAlign = ContentAlignment.BottomCenter;

            label.Hide();

            var back = new PictureBox();
            back.Location = new Point(1000, 50);
            back.Size = new Size(159, 132);
            back.BackgroundImage = Properties.Resources.back;

            // Main Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(237, 238, 240);
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
            exitButton.BackColor = Color.FromArgb(74, 118, 168);
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
            playButton.BackColor = Color.FromArgb(74, 118, 168);
            playButton.ForeColor = Color.FromArgb(0, 0, 0);
            playButton.ImageAlign = ContentAlignment.BottomCenter;
            playButton.Location = new Point((int)(ClientSize.Width * 6.6 / 100), (int)(ClientSize.Height / 2));
            playButton.Text = "Play";
            playButton.Size = new Size(200, 50);
            playButton.Click += (sender, args) =>
            {
                this.Hide();
                var gameScreen = new GameScreen(Size);
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
            exitFromSettingsButton.BackColor = Color.FromArgb(74, 118, 168);
            exitFromSettingsButton.Click += (sender, args) =>
            {
                playButton.Show();
                exitButton.Show();
                settingsButton.Show();
                label.Hide();
                choosePlayersCount.Hide();
                chPlayersCountLabel.Hide();
                exitFromSettingsButton.Hide();
                if (choosePlayersCount.SelectedItem != null)
                {
                    KeyValuePair<string, int[]> kvp = (KeyValuePair<string, int[]>)choosePlayersCount.SelectedItem;
                    int[] value = kvp.Value.ToArray();
                    PlayersCount = value[0];
                    RealPlayersCount = value[0] + value[1];
                }
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
            settingsButton.BackColor = Color.FromArgb(74, 118, 168);
            settingsButton.Click += (sender, args) =>
            {
                playButton.Hide();
                exitButton.Hide();
                settingsButton.Hide();
                label.Show();
                choosePlayersCount.Show();
                exitFromSettingsButton.Show();
                chPlayersCountLabel.Show();
            };


            Controls.Add(exitFromSettingsButton);
            Controls.Add(label);
            Controls.Add(settingsButton);
            Controls.Add(playButton);
            Controls.Add(back);
            Controls.Add(exitButton);
            Controls.Add(choosePlayersCount);
            Controls.Add(chPlayersCountLabel);
        }
    }
}
