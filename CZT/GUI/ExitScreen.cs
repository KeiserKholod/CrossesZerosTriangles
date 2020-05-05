﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace CZT.GUI
{
    class ExitScreen : Form
    {
        public ExitScreen()
        {
            SoundPlayer buttonClick = new SoundPlayer(Properties.Resources.button_click);
            var cancelButton = new Button();
            var exitButton = new Button();
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
            label.Text = "Are you want to exit?";
            label.Font = new Font("MV Boli", 20.00F);
            label.TextAlign = ContentAlignment.BottomCenter;


            exitButton.Anchor = AnchorStyles.Left;
            exitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitButton.Cursor = Cursors.Hand;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("MV Boli", 20.25F);
            exitButton.BackColor = Color.FromArgb(74, 118, 168);
            exitButton.BackgroundImage = Properties.Resources.exit_button;
            exitButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitButton.ImageAlign = ContentAlignment.BottomCenter;
            exitButton.Location = new Point(70, 100);
            exitButton.Text = "Yes";
            exitButton.Size = new Size(100, 50);
            exitButton.BackgroundImage = Properties.Resources.exit_button;
            exitButton.Click += (sender, args) =>
            {
                buttonClick.Play();
                Thread.Sleep(150);
                Application.Exit();
            };

            cancelButton.Anchor = AnchorStyles.Left;
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatStyle = FlatStyle.Popup;
            cancelButton.Font = new Font("MV Boli", 20.25F);
            cancelButton.ImageAlign = ContentAlignment.BottomCenter;
            cancelButton.Location = new Point(230, 100);
            cancelButton.Text = "No";
            cancelButton.BackgroundImage = Properties.Resources.exit_button;
            cancelButton.Size = new Size(100, 50);
            cancelButton.Click += (sender, args) =>
            {
                buttonClick.Play();
                Thread.Sleep(150);
                this.Hide();
                var mainMenu = new MainScreen(5, 3, 3);
                mainMenu.Show();
            };

            Controls.Add(label);
            Controls.Add(cancelButton);
            Controls.Add(exitButton);
        }
    }
}
