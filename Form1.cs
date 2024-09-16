using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minesweeper
{
    public partial class Form1 : Form
    {
        bool flag_mode;
        Slot[,] minefield;
        int minecount;
        int fieldsize;
        public Form1()
        {
            InitializeComponent();
        }

        private void startgamebtn_Click(object sender, EventArgs e)
        {
            flag_mode = false;
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                if (radioButton1.Checked)
                {
                    minecount = 10;
                    fieldsize = 10;
                }
                else if (radioButton2.Checked)
                {
                    minecount = 40;
                    fieldsize = 17;
                }
                else if (radioButton3.Checked)
                {
                    minecount = 80;
                    fieldsize = 24;
                }
                menulbl.Visible = false;
                difficultygroupbox.Visible = false;
                startgamebtn.Visible = false;
                minefield = new Slot[fieldsize, fieldsize];
                for (int i = 0; i < fieldsize ; i++)
                {
                    for (int k = 0; k < fieldsize; k++)
                    {
                        minefield[i,k] = new Slot(i,k);
                        this.Controls.Add(minefield[i,k]);
                        minefield[i,k].Width = (800 / fieldsize);
                        minefield[i,k].Height = (800 / fieldsize);
                        minefield[i,k].Enabled = true;
                        minefield[i,k].Show();
                        minefield[i,k].Font = new Font("Bold", 15);
                        minefield[i,k].Top = i * (800 / fieldsize);
                        minefield[i,k].Left = k * (800 / fieldsize);
                        minefield[i, k].BackColor = Color.FromArgb(230,230,230);

                        minefield[i, k].Click += new System.EventHandler(this.slot_Click);
                    }
                }
                //places the bombs on the grid
                placebombs();
                // must assign the closebombcount to all the slots
                for (int i = 0; i < fieldsize; i++)
                {
                    for (int k = 0; k < fieldsize; k++)
                    {
                        assignbombnumber(i, k);

                        //delete later only for designing game \/
                        //if (minefield[i, k].closebombcount != 0 && !minefield[i, k].bomb)
                        //{
                        //    minefield[i, k].Text = Convert.ToString(minefield[i, k].closebombcount);
                        //}
                    }
                }
                Globals.NumOfRevealedSlots = 0;
            }
            else
            {
                MessageBox.Show("Must select a difficulty option");
            }
        }
        private void newgame()
        {
            menulbl.Visible = true;
            difficultygroupbox.Visible = true;
            startgamebtn.Visible = true;
            for (int i = 0; i < fieldsize; i++)
            {
                for (int k = 0; k < fieldsize; k++)
                {
                    minefield[i, k].Visible = false;
                }
            }

        }
        private bool inbounds(int vertical_Index, int horizontal_Index, Slot[,] array)
        {
            return (vertical_Index >= 0) && (horizontal_Index >= 0) && (horizontal_Index < array.GetLength(0)) && (vertical_Index < array.GetLength(1));
        }
        private void placebombs()
        {
            Random rand = new Random();
            bool bombplaced;
            for (int i = 0; i < minecount; i++)
            {
                bombplaced = false;
                while (!bombplaced)
                {
                    int bombposition_x = rand.Next(fieldsize);
                    int bombposition_y = rand.Next(fieldsize);
                    if (!minefield[bombposition_x, bombposition_y].bomb)
                    {
                        minefield[bombposition_x, bombposition_y].bomb = true;
                        bombplaced = true;
                        //TEMPORARY CODE to see bombs \/
                        //minefield[bombposition_x, bombposition_y].BackColor = Color.IndianRed;
                    }
                }
            }
        }
        private void assignbombnumber(int pos_vertical, int pos_horizontal)
        {
            if (inbounds(pos_vertical - 1, pos_horizontal - 1, minefield) && minefield[pos_vertical - 1, pos_horizontal - 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical - 1, pos_horizontal, minefield) && minefield[pos_vertical - 1, pos_horizontal].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical - 1, pos_horizontal + 1, minefield) && minefield[pos_vertical - 1, pos_horizontal + 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical, pos_horizontal + 1, minefield) && minefield[pos_vertical, pos_horizontal + 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical + 1, pos_horizontal + 1, minefield) && minefield[pos_vertical + 1, pos_horizontal + 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical + 1, pos_horizontal, minefield) && minefield[pos_vertical + 1, pos_horizontal].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical + 1, pos_horizontal - 1, minefield) && minefield[pos_vertical + 1, pos_horizontal - 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
            if (inbounds(pos_vertical, pos_horizontal - 1, minefield) && minefield[pos_vertical, pos_horizontal - 1].bomb == true)
            {
                minefield[pos_vertical, pos_horizontal].closebombcount++;
            }
        }
        private void slot_Click(object sender, EventArgs e)
        {
            Slot slot = (Slot)sender;
            if (!Form1.IsKeyLocked(Keys.CapsLock) && !slot.flagged   )
            {
                if (slot.bomb)
                {
                    RevealAllMines();
                    finishgame(false);
                    return;
                }
                else if (slot.closebombcount == 0)
                {
                    RevealSafeZone(slot);
                }
                else
                {
                    slot.Reveal();
                }

                if (minecount == (Math.Pow(fieldsize, 2) - Globals.NumOfRevealedSlots))
                {
                    finishgame(true);
                }
            }
            else
            {
                if (slot.flagged)
                {
                    slot.flagged = false;
                    slot.BackColor = Color.FromArgb(230, 230, 230);
                }
                else
                {
                    slot.BackColor = Color.MediumOrchid;
                    slot.flagged = true;
                }
            }
        }
        private void RevealSafeZone(Slot slot)
        {
            int pos_vertical = slot.vertical_index;
            int pos_horizontal = slot.horizontal_index;

            if (inbounds(pos_vertical - 1, pos_horizontal - 1, minefield) && !minefield[pos_vertical - 1, pos_horizontal - 1].flagged && minefield[pos_vertical - 1, pos_horizontal - 1].closebombcount == 0 && minefield[pos_vertical - 1, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal - 1].Reveal();
                RevealSafeZone(minefield[pos_vertical - 1, pos_horizontal - 1]);
            }
            if (inbounds(pos_vertical - 1, pos_horizontal, minefield) && !minefield[pos_vertical - 1, pos_horizontal].flagged &&  minefield[pos_vertical - 1, pos_horizontal].closebombcount == 0 && minefield[pos_vertical - 1, pos_horizontal].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal].Reveal();
                RevealSafeZone(minefield[pos_vertical - 1, pos_horizontal]);
            }
            if (inbounds(pos_vertical - 1, pos_horizontal + 1, minefield) && !minefield[pos_vertical - 1, pos_horizontal + 1].flagged && minefield[pos_vertical - 1, pos_horizontal + 1].closebombcount == 0 && minefield[pos_vertical - 1, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal + 1].Reveal();
                RevealSafeZone(minefield[pos_vertical - 1, pos_horizontal + 1]);
            }
            if (inbounds(pos_vertical, pos_horizontal + 1, minefield) && !minefield[pos_vertical, pos_horizontal + 1].flagged &&  minefield[pos_vertical, pos_horizontal + 1].closebombcount == 0 && minefield[pos_vertical, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical, pos_horizontal + 1].Reveal();
                RevealSafeZone(minefield[pos_vertical, pos_horizontal + 1]);
            }
            if (inbounds(pos_vertical + 1, pos_horizontal + 1, minefield) && !minefield[pos_vertical + 1, pos_horizontal + 1].flagged &&  minefield[pos_vertical + 1, pos_horizontal + 1].closebombcount == 0 && minefield[pos_vertical + 1, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal + 1].Reveal();
                RevealSafeZone(minefield[pos_vertical + 1, pos_horizontal + 1]);
            }
            if (inbounds(pos_vertical + 1, pos_horizontal, minefield) && !minefield[pos_vertical + 1, pos_horizontal].flagged &&  minefield[pos_vertical + 1, pos_horizontal].closebombcount == 0 && minefield[pos_vertical + 1, pos_horizontal].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal].Reveal();
                RevealSafeZone(minefield[pos_vertical + 1, pos_horizontal]);
            }
            if (inbounds(pos_vertical + 1, pos_horizontal - 1, minefield) && !minefield[pos_vertical + 1, pos_horizontal - 1].flagged &&  minefield[pos_vertical + 1, pos_horizontal - 1].closebombcount == 0 && minefield[pos_vertical + 1, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal - 1].Reveal();
                RevealSafeZone(minefield[pos_vertical + 1, pos_horizontal - 1]);
            }
            if (inbounds(pos_vertical, pos_horizontal - 1, minefield) && !minefield[pos_vertical, pos_horizontal - 1].flagged &&  minefield[pos_vertical, pos_horizontal - 1].closebombcount == 0 && minefield[pos_vertical, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical, pos_horizontal - 1].Reveal();
                RevealSafeZone(minefield[pos_vertical, pos_horizontal - 1]);
            }
            RevealAllSorroundingSlots(slot);
        }
        private void RevealAllSorroundingSlots(Slot slot)
        {
            int pos_vertical = slot.vertical_index;
            int pos_horizontal = slot.horizontal_index;

            if (inbounds(pos_vertical - 1, pos_horizontal - 1, minefield) && !minefield[pos_vertical - 1, pos_horizontal - 1].flagged &&  minefield[pos_vertical - 1, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal - 1].Reveal();
            }
            if (inbounds(pos_vertical - 1, pos_horizontal, minefield) && !minefield[pos_vertical - 1, pos_horizontal].flagged &&  minefield[pos_vertical - 1, pos_horizontal].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal].Reveal();
            }
            if (inbounds(pos_vertical - 1, pos_horizontal + 1, minefield) && !minefield[pos_vertical - 1, pos_horizontal + 1].flagged &&  minefield[pos_vertical - 1, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical - 1, pos_horizontal + 1].Reveal();
            }
            if (inbounds(pos_vertical, pos_horizontal + 1, minefield) && !minefield[pos_vertical, pos_horizontal + 1].flagged &&  minefield[pos_vertical, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical, pos_horizontal + 1].Reveal();
            }
            if (inbounds(pos_vertical + 1, pos_horizontal + 1, minefield) && !minefield[pos_vertical + 1, pos_horizontal + 1].flagged &&  minefield[pos_vertical + 1, pos_horizontal + 1].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal + 1].Reveal();
            }
            if (inbounds(pos_vertical + 1, pos_horizontal, minefield) && !minefield[pos_vertical + 1, pos_horizontal].flagged && minefield[pos_vertical + 1, pos_horizontal].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal].Reveal();
            }
            if (inbounds(pos_vertical + 1, pos_horizontal - 1, minefield) && !minefield[pos_vertical + 1, pos_horizontal - 1].flagged &&  minefield[pos_vertical + 1, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical + 1, pos_horizontal - 1].Reveal();
            }
            if (inbounds(pos_vertical, pos_horizontal - 1, minefield) && !minefield[pos_vertical, pos_horizontal - 1].flagged &&  minefield[pos_vertical, pos_horizontal - 1].Enabled)
            {
                minefield[pos_vertical, pos_horizontal - 1].Reveal();
            }
        }
        private void finishgame(bool win)
        {
            //must code for actions once game has finished. this will include wether the game has been won or lost
            if (win)
            {
                MessageBox.Show("you won");
            }
            else
            {
                MessageBox.Show("you hit a mine");
            }
            newgame();
        }
        private void RevealAllMines()
        {
            for (int i = 0; i < fieldsize; i++)
            {
                for (int k = 0; k < fieldsize; k++)
                {
                    if (minefield[i,k].bomb)
                    {
                        minefield[i, k].BackColor = Color.IndianRed;
                        minefield[i, k].Enabled = false;
                    }
                }
            }
        }
    }
}
