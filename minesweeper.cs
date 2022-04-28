using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace higherlower
{
    public partial class Minesweeper : Form
    {
        static bool[,] isBomb = new bool[15, 15];
        private int Starter(int n)
        {

        }
        public Minesweeper()
        {
            InitializeComponent();
            int rows = 15;
            int cols = 15;
            Random rand = new Random();
            for (int x = 0; x < 100; x++)
            {
                isBomb[rand.Next(0, 15), rand.Next(0, 15)] = true;
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Button btn = new Button()
                    {
                        Size = new Size(25, 25),
                        Location = new Point(i * 20,j *20),
                        Visible = true,
                    };
                    if (isBomb[i,j] == true)
                    {
                        btn.BackColor = Color.LightPink;
                    }
                    this.Controls.Add(btn);
                    int adjBombs = 0;
                    int ii = i;
                    int jj = j;
                    int[] range = { -1, 0, 1 };
                    btn.Click += (sender, args) =>
                    {
                        if (isBomb[ii,jj] == true)
                        {
                            MessageBox.Show("kaboom");
                        }
                        else
                        {
                     
                            for (int y = -1; y < 2; y++)
                            {
                                for (int x = -1; x < 2; x++)
                                {
                                    if (y == 0 && x == 0)
                                    {  // Skip the middle item (it's our current item)
                                        continue;
                                    }
                                    if (isBomb[ii + x, jj + y])
                                    {
                                        adjBombs++;
                                    }

                                }
                            }
                            btn.Text = adjBombs.ToString();
                        }
                    };
                } 
            }
        }
    }
}
