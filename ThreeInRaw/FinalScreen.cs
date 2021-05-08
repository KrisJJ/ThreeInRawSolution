using System;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class FinalScreen
    {
        private int[] pos;
        private Text text;
        private Font font;
        private Shape button;
        private int[] buttonPos;
        private Text buttonText;
        private bool butPush;
        private Text pointsText;

        public FinalScreen()
        {
            this.pos = new int[2] { 270, 130 };

            this.font = new Font("..\\..\\..\\resource\\Gabriola.ttf");

            this.text = new Text("Game over", font);
            this.text.CharacterSize = 80;
            this.text.FillColor = new Color(0, 0, 0);
            this.text.Position = new SFML.System.Vector2f(pos[0], pos[1]);

            this.buttonPos = new int[4] { pos[0]+105, pos[1]+180, 75, 40 };
            this.button = new RectangleShape(new SFML.System.Vector2f(this.buttonPos[2], this.buttonPos[3]));
            this.button.FillColor = new Color(150,150,150);
            this.button.Position = new SFML.System.Vector2f(this.buttonPos[0], this.buttonPos[1]);

            this.buttonText = new Text("Ok", font);
            this.buttonText.CharacterSize = 30;
            this.buttonText.FillColor = new Color(0, 0, 0);
            this.buttonText.Position = new SFML.System.Vector2f(this.buttonPos[0]+25, this.buttonPos[1]-3);

            this.pointsText = new Text("", font);
            this.pointsText.CharacterSize = 25;
            this.pointsText.FillColor = new Color(0, 0, 0);
            this.pointsText.Position = new SFML.System.Vector2f(pos[0]+43, pos[1]+95);

            this.butPush = false;
        }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.text);
            window.Draw(this.button);
            window.Draw(this.buttonText);
            window.Draw(this.pointsText);
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

        public void SetPoints(int points)
        {
            this.pointsText.DisplayedString = "You've riched "+points+" points";
        }
    }
}
