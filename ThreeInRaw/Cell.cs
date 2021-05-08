using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class Cell
    {
        private int[] pos;
        private Shape border;
        private Figure figure;
        

        public Cell(int[] pos)
        {
            this.pos = pos;
            this.figure = new Figure(pos);
            this.border = new RectangleShape(new SFML.System.Vector2f(50, 50));
            this.border.OutlineThickness = 1;
            this.border.OutlineColor = new Color(0, 0, 0);
            this.border.Position = new SFML.System.Vector2f(pos[0], pos[1]);
        }

        public Figure GetFigure()
        {
            return this.figure;
        }

        public void SetFigure(Color color)
        {
            this.figure.SetFigure(color);
            this.figure.FocusOff();
        }

        public Shape GetBorder()
        {
            return this.border;
        }

        public int[] GetPosition()
        {
            return this.pos;
        }

        public bool MousePressed(RenderWindow window)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                var mousePos = Mouse.GetPosition(window);
                return (mousePos.X >= this.pos[0] && mousePos.X <= this.pos[0] + 50 && mousePos.Y >= this.pos[1] && mousePos.Y <= this.pos[1] + 50);
            }
            else
            {
                return false;
            }
        }

        public void FocusOn()
        {
            if (this.figure.GetColor() != new Color(255, 255, 255))
            {
                this.figure.FocusOn();
            }
        }
        public void MousePressedTwise(RenderWindow window)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left) && this.figure.IsFocused())
            {
                this.figure.FocusOff();
            }
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.border);
            figure.Draw(window);
        }
    }
}
