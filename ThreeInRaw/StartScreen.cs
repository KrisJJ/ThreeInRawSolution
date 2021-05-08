using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class StartScreen
    {
        private int[] pos;
        private Text text;
        private Font font;
        private Shape button;
        private int[] buttonPos;
        private Text buttonText;
        private bool butPush;

        public StartScreen()
        {
            this.pos = new int[2] { 250, 130 };

            this.font = new Font("..\\..\\..\\resource\\Gabriola.ttf");

            this.text = new Text("Match-three Classic", font);
            this.text.CharacterSize = 80;
            this.text.FillColor = new Color(0, 0, 0);
            this.text.Position = new SFML.System.Vector2f(this.pos[0]-100, this.pos[1]);

            this.buttonPos = new int[4] { this.pos[0] + 105, this.pos[1] + 130, 85, 40 };
            this.button = new RectangleShape(new SFML.System.Vector2f(this.buttonPos[2], this.buttonPos[3]));
            this.button.FillColor = new Color(150, 150, 150);
            this.button.Position = new SFML.System.Vector2f(this.buttonPos[0], this.buttonPos[1]);

            this.buttonText = new Text("Play", font);
            this.buttonText.CharacterSize = 30;
            this.buttonText.FillColor = new Color(0, 0, 0);
            this.buttonText.Position = new SFML.System.Vector2f(this.buttonPos[0]+23, this.buttonPos[1]-3);

            this.butPush = false;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.text);
            window.Draw(this.button);
            window.Draw(this.buttonText);
        }

        public void MousePressed(RenderWindow window)
        {
            if (Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                var mousePos = Mouse.GetPosition(window);
                this.butPush = mousePos.X >= this.buttonPos[0] && mousePos.X <= this.buttonPos[0]+this.buttonPos[2] && mousePos.Y >= this.buttonPos[1] && mousePos.Y <= this.buttonPos[1]+this.buttonPos[3];
            }
        }

        public bool ButtonPushed()
        {
            return this.butPush;
        }
    }
}
