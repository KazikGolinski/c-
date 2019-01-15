using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rysowanie
{

    public class Game
    {
        public void RandomFile()
        {
            Random num = new Random();
            int nr = num.Next(1, 6);
            
            while (LastNr == nr || LastNr == 0)
            {
                file = "C:\\Users\\kazik\\Documents\\Inf\\Sudoku\\Sudoku" + nr + ".txt";
            }
            LastNr = nr;
        }

        public void ReadFromFile()
        {
            String input = File.ReadAllText(file);

            int i = 0, j = 0;
            foreach (var row in input.Split('\n'))
            {
                j = 0;
                foreach (var col in row.Trim().Split(' '))
                {
                    BoardVal[j, i] = int.Parse(col.Trim());
                    j++;
                }
                i++;
            }

        }

       
        public string file;
        public int LastNr=0;
        public bool[,] Board { get; set; } = new bool[9, 9];
        public bool[,] LastBoard { get; set; } = new bool[9, 9];
        public int[,] BoardVal { get; set; } = new int[9, 9];
        public bool[,] BoardConst { get; set; } = new bool[9, 9];
        public bool error = false;

        public void IsCorrect()
        {
            
            int[] row = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] col = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] sqr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] ValCol = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ValRow = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] ValSqr = { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int s = 0;
            for (int j = 0; j <= 8; j++)
            {
                row = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                ValCol = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                ValRow = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                for (int x = 0; x <= 8; x++)
                {


                    ValCol[BoardVal[j, x]] = 1;
                    if (x == 8)
                    {
                        for (int y = 0; y <= 8; y++)
                        {
                            if (ValCol[y] == 0)
                            {
                                error = true;
                            }
                        }

                    }

                    ValRow[BoardVal[x, j]] = 1;
                    if (x == 8)
                    {
                        for (int y = 0; y <= 8; y++)
                        {
                            if (ValRow[y] == 0)
                            {
                                error = true;
                            }
                        }
                    }
                }
            }
            for (int i = 1; i <= 7; i = i + 3)
            {
                for (int j = 1; j <= 7; j = j + 3)
                {
                    s = 0;
                    ValSqr = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    for (int x = i - 1; x <= i + 1; x++)
                    {
                        for (int y = j - 1; y <= j + 1; y++)
                        {
                            ValSqr[BoardVal[x, y]] = 1;
                            if (s == 8)
                            {
                                for (int u = 0; u <= 8; u++)
                                {
                                    if (ValSqr[u] == 0)
                                    {
                                        error = true;
                                    }
                                }
                            }
                            s++;
                        }


                    }
                }
            }

        }
    }
}
