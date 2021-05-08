using System;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class Timer
    {
        private Clock clock;
        private int[] pos;
        private Text text;
        private Font font;
        private double maxTime = new double();
        private double residTime = new double();

        public Timer()
        {
            this.clock = new Clock();
            this.pos = new int[2] { 470, 30 };
            this.font = new Font("..\\..\\..\\resource\\Gabriola.ttf");
            this.text = new Text("", font);
            this.text.CharacterSize = 40;
            this.text.FillColor = new Color(0, 0, 0);
            this.text.Position = new SFML.System.Vector2f(pos[0], pos[1]);
            this.maxTime = 60;
            this.residTime = this.maxTime;
        }

        public Time GetTime()
        {
            return this.clock.ElapsedTime;
        }

        public void Draw(RenderWindow window)
        {
            this.residTime = Math.Ceiling(this.maxTime - this.clock.ElapsedTime.AsSeconds());
            if (this.residTime <= 0) { this.residTime = 0; }
            this.text.DisplayedString = "Rest time: " + this.residTime;
            window.Draw(this.text);
        }

        public bool IsOver()
        {
            if (this.residTime > 0) { return false; }
            else { return true; }
        }
    }
}
