using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rysowanie
{
    public partial class Form1 : Form
    {
        Game game = new Game();


        public Form1()
        {
            InitializeComponent();
            game.RandomFile();
            game.ReadFromFile();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    game.Board[i, j] = true;
                    
                    //if (game.Board[i, j] == false)
                    //{
                    //  game.BoardVal[i, j] = 0;
                    //}
                    if (game.BoardVal[i,j] == 0)
                    {
                        game.Board[i, j] = false;
                    }
                    game.BoardConst[i, j] = game.Board[i, j];
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            game.RandomFile();
            game.ReadFromFile();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    game.Board[i, j] = true;

                    //if (game.Board[i, j] == false)
                    //{
                    //  game.BoardVal[i, j] = 0;
                    //}
                    if (game.BoardVal[i, j] == 0)
                    {
                        game.Board[i, j] = false;
                    }
                    game.BoardConst[i, j] = game.Board[i, j];
                }

            }
            this.Refresh();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // ustalnie wilkosci pola gry
            float height = pictureBox1.Height - 2;
            float width = pictureBox1.Width - 2;
            if (width > height) width = height;
            else height = width;


            for (int i = 0; i < 10; i++)
            {
                g.DrawLine(new Pen(Color.Red), i * (width / 9), 0, i * (width / 9), height);
                g.DrawLine(new Pen(Color.Red), 0, i * (height / 9), width, i * (height / 9));
            }
            for (int i = 0; i < 4; i++)
            {
                g.DrawLine(new Pen(Color.Green), i * (width / 3), 0, i * (width / 3), height);
                g.DrawLine(new Pen(Color.Green), 0, i * (height / 3), width, i * (height / 3));
            }

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (game.Board[x, y] == true)
                    {
                        
                       
                        Brush Brush = new System.Drawing.SolidBrush(System.Drawing.Color.Blue);
                        if (game.BoardConst[x, y] == true)
                        {
                            Brush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
                        }
                        String line = game.BoardVal[x, y].ToString();
                            g.DrawString(line, Font, Brush, x * (width / 9) + (width / 20), y * (height / 9) + (height / 20));
                        
                    }
                }
            }
        }

       
        

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int height = pictureBox1.Height - 2;
            int width = pictureBox1.Width - 2;
            if (width > height) width = height;
            else height = width;

            int mousex = e.X  / (width/9);
            int mousey = e.Y  / (height/9);


            if (game.BoardConst[mousex, mousey] == false)
            {
               
                if (game.Board[mousex, mousey] == false)
                {

                    game.Board[mousex, mousey] = true;
                    game.BoardVal[mousex, mousey] = 1;
                }
                else
                {
                    game.Board[mousex, mousey] = true;
                    game.BoardVal[mousex, mousey]++;
                    if (game.BoardVal[mousex, mousey] == 10)
                        game.BoardVal[mousex, mousey] = 1;
                }
                if (e.Button == MouseButtons.Right)
                {
                    game.Board[mousex, mousey] = false;
                }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            game.IsCorrect();
            if (game.error == true)
            {
                
                MessageBox.Show("Mistake detected.");

            }
            else MessageBox.Show("Correct!!.");
        }

      

    }
}
