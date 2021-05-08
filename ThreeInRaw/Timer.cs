﻿using System;
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

        public Timer()
        {
            this.clock = new Clock();
            this.pos = new int[2] { 470, 20 };
            this.font = new Font("..\\..\\..\\resource\\Gabriola.ttf");
            this.text = new Text("", font);
            this.text.CharacterSize = 40;
            this.text.FillColor = new Color(0, 0, 0);
            this.text.Position = new SFML.System.Vector2f(pos[0], pos[1]);
        }

        public Time GetTime()
        {
            return this.clock.ElapsedTime;
        }

        public void Draw(RenderWindow window)
        {
            double curTime = new double();
            curTime = Math.Ceiling(60 - this.clock.ElapsedTime.AsSeconds());
            if (curTime <= 0) { curTime = 0; }
            this.text.DisplayedString = "Оставшееся время: " + curTime;
            window.Draw(this.text);
        }
    }
}
