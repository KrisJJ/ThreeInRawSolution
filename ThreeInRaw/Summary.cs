using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class Summary
    {
        private int points;
        private int[] pos;
        private Text text;
        private Font font;

        public Summary()
        {
            this.points = 0;
            this.pos = new int[2] {470,80};
            this.font = new Font("..\\..\\..\\resource\\Gabriola.ttf");
            this.text = new Text("",font);
            this.text.CharacterSize = 40;
            this.text.FillColor = new Color(0, 0, 0);
            this.text.Position = new SFML.System.Vector2f(pos[0], pos[1]);
        }

        public void Draw(RenderWindow window)
        {
            this.text.DisplayedString = "Очки: "+points.ToString();
            window.Draw(this.text);
        }

        public void UpdatePoints(int points)
        {
            this.points += points;
        }

        public int GetPoints()
        {
            return this.points;
        }
    }
}
