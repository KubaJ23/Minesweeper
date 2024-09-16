using System;
using System.Drawing;
using System.Windows.Forms;

namespace minesweeper
{
    public class Slot : Button
    {
        public bool bomb = false;
        public int closebombcount = 0;
        public int vertical_index;
        public int horizontal_index;
        public bool flagged = false;

        public Slot(int vertical, int horizontal)
        {
            vertical_index = vertical;
            horizontal_index = horizontal;
        }
        public void Reveal()
        {
            if (!flagged)
            {
                this.Enabled = false;
                if (closebombcount != 0)
                {
                    this.Text = Convert.ToString(closebombcount);
                }
                Globals.NumOfRevealedSlots++;
                this.BackColor = Color.FromArgb(215, 215, 215);
            }
        }
    }
}
