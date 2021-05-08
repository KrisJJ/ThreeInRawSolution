using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class Figure
    {
        private int[] pos;
        //private Sprite sprite;
        private Shape shape;
        private Color color;
        private bool isShapeFocused = false;
        enum colors
        {
            red,
            orange,
            yellow,
            green,
            blue,
            violet
        }
        public Figure(int[] pos)
        {
            this.pos = pos;
            this.shape = new CircleShape(20);

            var col = (colors)(new Random()).Next(6);
            switch (col)
            {
                case colors.red:
                    this.color = new Color(250, 0, 0);
                    break;
                case colors.orange:
                    this.color = new Color(200, 100, 0);
                    break;
                case colors.yellow:
                    this.color = new Color(200, 200, 0);
                    break;
                case colors.green:
                    this.color = new Color(0, 250, 0);
                    break;
                case colors.blue:
                    this.color = new Color(0, 0, 250);
                    break;
                case colors.violet:
                    this.color = new Color(200, 0, 200);
                    break;
                default:
                    this.color = new Color(0, 0, 0);
                    break;
            }

            this.shape.FillColor = new Color(this.color);
            this.shape.OutlineThickness = 0;
            this.shape.OutlineColor = new Color(0, 0, 0);
            this.shape.Position = new SFML.System.Vector2f(pos[0] + 5, pos[1] + 5);
        }

        public Figure(Figure figure)
        {
            this.shape = figure.GetShape();
            this.color = figure.GetColor();
            //Sprite sprite;
            this.shape.FillColor = new Color(this.color);
            this.shape.OutlineColor = new Color(0, 0, 0);
        }

        public Shape GetShape()
        {
            return this.shape;
        }

        public void SetFigure(Color color)
        {
            this.color = color;
            this.shape.FillColor = this.color;
        }

        public Color GetColor()
        {
            return this.color;
        }

        public void FocusOn()
        {
            this.shape.OutlineThickness = 3;
            this.isShapeFocused = true;
        }

        public void FocusOff()
        {
            this.shape.OutlineThickness = 0;
            this.isShapeFocused = false;
        }

        public bool IsFocused()
        {
            return this.isShapeFocused;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.shape);
        }
    }
}
