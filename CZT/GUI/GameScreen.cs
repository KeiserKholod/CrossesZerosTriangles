using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CZT.GUI
{
    class GameScreen : Form
    {
        //private Game game; здесь будет класс игры
        private int Size;
        private int PlayersCount;

        TableLayoutPanel table;
        public GameScreen(int size)
        {
            this.Size = size;
            var exitButton = new Button();
            table = new TableLayoutPanel();
            table.BackColor = Color.FromArgb(173, 216, 230);
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
                    button.Size = new Size(74, 74);
                    button.Dock = DockStyle.Fill;
                    button.FlatStyle = FlatStyle.Standard;
                    button.Click += MakeMove;
                    table.Controls.Add(button, column, row);
                }
            table.Size = new Size(74 * this.Size, 74 * this.Size);


            // Game Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(173, 216, 230);
            this.ClientSize = new Size(74 * this.Size, 74 * this.Size + 60);
            this.MinimumSize = new Size(74 * this.Size, 74 * this.Size + 60);
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
                this.Hide();
                var mainScreen = new MainScreen();
                mainScreen.Show();
            };

            Controls.Add(table);
            Controls.Add(exitButton);
        }

        void MakeMove(object sender, EventArgs e)
        {
            var position = table.GetCellPosition((Control)sender);
            var button = (Button)table.GetControlFromPosition(position.Column, position.Row);
            button.BackgroundImage = Properties.Resources.triangle;
        }
    }
}
