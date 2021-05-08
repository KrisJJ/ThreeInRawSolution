using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class _1
    {
        static Font font;
        static Text text;
        public static void main(RenderWindow window)
        {
            font = new Font("..\\..\\..\\resource\\Gabriola.ttf");
            text = new Text("Yell", font);
            text.FillColor = new Color(250, 0, 0);
            window.Draw(text);
        }
    }
}
