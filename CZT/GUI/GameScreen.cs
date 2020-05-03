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
        private int Player;
        TableLayoutPanel table;

        public GameScreen(int size)
        {
            this.Size = size;
            table = new TableLayoutPanel();
            for (int i = 0; i < this.Size; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / this.Size));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / this.Size));
            }
            for (int column = 0; column < this.Size; column++)
                for (int row = 0; row < this.Size; row++)
                {
                    var button = new Button();
                    button.BackColor = Color.FromArgb(255, 69, 0);
                    button.Size = new Size(64, 64);
                    button.Dock = DockStyle.Fill;
                    button.Click += MakeMove;
                    table.Controls.Add(button, column, row);
                }

            table.Dock = DockStyle.Fill;
            Controls.Add(table);


            // Game Screen Settins
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.FromArgb(0, 0, 0);
            this.ClientSize = new Size(64 * this.Size, 64 * this.Size);
            this.MinimumSize = new Size(64 * this.Size, 64 * this.Size);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        void MakeMove(object sender, EventArgs e)
        {
            var position = table.GetCellPosition((Control)sender);
            var button = (Button)table.GetControlFromPosition(position.Column, position.Row);
            button.BackColor = Color.FromArgb(255, 255, 0);
        }
    }
}
