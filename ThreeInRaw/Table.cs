using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

namespace ThreeInRaw
{
    class Table
    {
        private Cell[][] table;
        private int[] curPos;
        private Figure curFig;
        private Cell curCell;
        private int[] curTab;
        private Summary summary;
        private Timer timer;

        public Table(int m, int n)
        {
            table = new Cell[m][];
            for (int i = 1; i <= m; i++)
            {
                table[i - 1] = new Cell[n];
                for (int j = 1; j <= n; j++)
                {
                    table[i - 1][j - 1] = new Cell(new int[2] { i * 50, j * 50 });
                }
            }
            summary = new Summary();
            timer = new Timer();
        }

        public Cell[][] GetTable()
        {
            return table;
        }

        public void Draw(RenderWindow window)
        {
            foreach (Cell[] cell in this.table)
            {
                foreach (Cell c in cell)
                {
                    c.Draw(window);
                }
            }
            this.summary.Draw(window);
            this.timer.Draw(window);
        }

        public void MousePressed(RenderWindow window)
        {
            for (int i=0; i<this.table.Length; i++)
            {
                for (int j=0; j<this.table[i].Length; j++)
                {
                    Cell c = this.table[i][j];
                    if (c.MousePressed(window))
                    {
                        if (this.curPos is null && c.GetFigure().GetColor() != new Color(255, 255, 255))
                        {
                            this.curCell = c;
                            this.curPos = c.GetPosition();
                            this.curFig = new Figure(c.GetFigure());
                            this.curTab = new int[2] {i, j};
                            c.FocusOn();
                        }
                        else if (this.curPos == c.GetPosition())
                        {
                            c.MousePressedTwise(window);
                            this.curPos = null;
                        }
                        else if (this.curPos != null && ((this.curPos[0] == c.GetPosition()[0] && Math.Abs(this.curPos[1] - c.GetPosition()[1]) <= 50) ||
                            (this.curPos[1] == c.GetPosition()[1] && Math.Abs(this.curPos[0] - c.GetPosition()[0]) <= 50)))
                        {
                            bool accept = false;

                            Color color1 = new Color(c.GetFigure().GetColor());
                            Color color2 = new Color(this.curFig.GetColor());
                            this.curCell.SetFigure(color1);
                            c.SetFigure(color2);

                            //проверка на наличие тройки при перемещении подсвеченной фигуры
                            if (i >= 0 && i < this.table.Length - 2)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i + 1][j].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i + 2][j].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }
                            if (i <= this.table.Length - 1 && i > 1)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i - 1][j].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i - 2][j].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }
                            if (i < this.table.Length - 1 && i > 0)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i - 1][j].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i + 1][j].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }
                            if (j >= 0 && j < this.table[i].Length - 2)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i][j + 1].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i][j + 2].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }
                            if (j <= this.table[i].Length - 1 && j > 1)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i][j - 1].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i][j - 2].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }
                            if (j < this.table[i].Length - 1 && j > 0)
                            {
                                if (this.table[i][j].GetFigure().GetColor() == this.table[i][j - 1].GetFigure().GetColor() && this.table[i][j].GetFigure().GetColor() == this.table[i][j + 1].GetFigure().GetColor())
                                {
                                    accept = true;
                                }
                            }

                            //проверка на наличие тройки при перемещении нажатой фигуры
                            if (!accept)
                            {
                                if (this.curTab[0] >= 0 && this.curTab[0] < this.table.Length - 2)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] + 1][this.curTab[1]].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] + 2][this.curTab[1]].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                                if (this.curTab[0] <= this.table.Length - 1 && this.curTab[0] > 1)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] - 1][this.curTab[1]].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] - 2][this.curTab[1]].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                                if (this.curTab[0] < this.table.Length - 1 && this.curTab[0] > 0)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] - 1][this.curTab[1]].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0] + 1][this.curTab[1]].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                                if (this.curTab[1] >= 0 && this.curTab[1] < this.table[this.curTab[0]].Length - 2)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] + 1].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] + 2].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                                if (this.curTab[1] <= this.table[this.curTab[0]].Length - 1 && this.curTab[1] > 1)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] - 1].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] - 2].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                                if (this.curTab[1] < this.table[this.curTab[0]].Length - 1 && this.curTab[1] > 0)
                                {
                                    if (this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] - 1].GetFigure().GetColor() && this.table[this.curTab[0]][this.curTab[1]].GetFigure().GetColor() == this.table[this.curTab[0]][this.curTab[1] + 1].GetFigure().GetColor())
                                    {
                                        accept = true;
                                    }
                                }
                            }

                            if (!accept)
                            {
                                this.curCell.SetFigure(color2);
                                c.SetFigure(color1);
                            }
                            this.curPos = null;
                        }
                        else
                        {
                            //Console.WriteLine("4");
                        }
                    }
                }
            }
        }

        public void DeleteTriplets()
        {
            List<int[]> del = new List<int[]>();
            int points = 0;

            for (int i = 1; i < this.table.Length-1; i++)
            {
                for (int j = 0; j < this.table[i].Length; j++)
                {
                    if (this.table[i][j].GetFigure().GetColor() == this.table[i - 1][j].GetFigure().GetColor() &&
                        this.table[i][j].GetFigure().GetColor() == this.table[i + 1][j].GetFigure().GetColor() &&
                        this.table[i][j].GetFigure().GetColor() != new Color(255,255,255))
                    {
                        for (int k=0; k<=2; k++)
                        {
                            if (!del.Contains(new int[2] {i+k-1, j}))
                            {
                                del.Add(new int[2] { i+k-1, j });
                                points += 50;
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < this.table.Length; i++)
            {
                for (int j = 1; j < this.table[i].Length-1; j++)
                {
                    if (this.table[i][j].GetFigure().GetColor() == this.table[i][j - 1].GetFigure().GetColor() &&
                        this.table[i][j].GetFigure().GetColor() == this.table[i][j + 1].GetFigure().GetColor() &&
                        this.table[i][j].GetFigure().GetColor() != new Color(255, 255, 255))
                    {
                        for (int k = 0; k <= 2; k++)
                        {
                            if (!del.Contains(new int[2] { i, j+k-1 }))
                            {
                                del.Add(new int[2] { i, j+k-1 });
                                points += 50;
                            }
                        }
                    }
                }
            }
            foreach (int[] d in del)
            {
                this.table[d[0]][d[1]].SetFigure(new Color(255, 255, 255));
            }
            this.summary.UpdatePoints(points);
        }

        public void FillVoid()
        {
            for (int i = 0; i < this.table.Length; i++)
            {
                for (int j = 0; j < this.table[i].Length; j++)
                {
                    if (this.table[i][j].GetFigure().GetColor() == new Color(255, 255, 255))
                    {
                        if (j == 0)
                        {
                            table[i][j] = new Cell(new int[2] { (i + 1) * 50, (j + 1) * 50 });
                        }
                        else
                        {
                            Color color = new Color(this.table[i][j].GetFigure().GetColor());
                            this.table[i][j].SetFigure(this.table[i][j-1].GetFigure().GetColor());
                            this.table[i][j - 1].SetFigure(color);
                        }
                    }
                }
            }
        }

        public bool VoidExists()
        {
            bool existing = false; 
            for (int i = 0; i < this.table.Length; i++)
            {
                for (int j = 0; j < this.table[i].Length; j++)
                {
                    if (this.table[i][j].GetFigure().GetColor() == new Color(255, 255, 255))
                    {
                        existing = true;
                    }
                }
            }
            return existing;
        }
    }
}
