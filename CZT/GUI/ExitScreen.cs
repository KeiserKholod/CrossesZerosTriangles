using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CZT.GUI
{
    class ExitScreen : Form
    {
        public ExitScreen()
        {
            var cancelButton = new Button();
            var exitButton = new Button();
            var label = new Label();

            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(255, 69, 0);
            this.ClientSize = new Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(400, 200);
            this.MaximumSize = new Size(400, 200);
            this.FormBorderStyle = FormBorderStyle.None;

            label.Location = new Point(0, 20);
            label.Size = new Size(400, 100);
            label.Text = "Are you sure, you want to exit?";
            label.BackColor = Color.FromArgb(255, 69, 0);
            label.Font = new Font("MV Boli", 20.00F);
            label.TextAlign = ContentAlignment.BottomCenter;

            exitButton.Anchor = AnchorStyles.Left;
            exitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitButton.Cursor = Cursors.Hand;
            exitButton.FlatStyle = FlatStyle.Popup;
            exitButton.Font = new Font("MV Boli", 20.25F);
            exitButton.BackColor = Color.FromArgb(255, 255, 0);
            exitButton.ForeColor = Color.FromArgb(0, 0, 0);
            exitButton.ImageAlign = ContentAlignment.BottomCenter;
            exitButton.Location = new Point(70, 100);
            exitButton.Text = "Yes";
            exitButton.Size = new Size(100, 50);
            exitButton.Click += (sender, args) =>
            {
                Application.Exit();
            };

            cancelButton.Anchor = AnchorStyles.Left;
            cancelButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            cancelButton.Cursor = Cursors.Hand;
            cancelButton.FlatStyle = FlatStyle.Popup;
            cancelButton.Font = new Font("MV Boli", 20.25F);
            cancelButton.BackColor = Color.FromArgb(255, 255, 0);
            cancelButton.ForeColor = Color.FromArgb(0, 0, 0);
            cancelButton.ImageAlign = ContentAlignment.BottomCenter;
            cancelButton.Location = new Point(230, 100);
            cancelButton.Text = "No";
            cancelButton.Size = new Size(100, 50);
            cancelButton.Click += (sender, args) =>
            {
                this.Hide();
                var mainMenu = new MainScreen();
                mainMenu.Show();
            };

            Controls.Add(label);
            Controls.Add(cancelButton);
            Controls.Add(exitButton);
        }
    }
}
