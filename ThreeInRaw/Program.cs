using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace ThreeInRaw
{
    class Program
    {
        static RenderWindow window;
        static View view;
        static Table table;
        static StartScreen stScr = new StartScreen();
        static FinalScreen finScr;
        static int mode = new int();

        static void Main(string[] args)
        {
            window = new RenderWindow(new SFML.Window.VideoMode(800, 500), "Testing window");
            window.SetVerticalSyncEnabled(true);
            view = window.GetView();

            mode = 1;

            window.Closed += Window_Closed;

            window.MouseButtonPressed += Window_MouseButtonPressed;

            window.Resized += Window_Resized;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(Color.White);

                if (mode == 1) 
                { 
                    stScr.Draw(window);
                    if (stScr.ButtonPushed())
                    {
                        mode = 2;
                        table = new Table(8, 8);
                    }
                }
                else if (mode == 2) 
                {
                    table.DeleteTriplets();
                    while (table.VoidExists()) { table.FillVoid(); }
                    table.Draw(window);
                    if (table.TimeIsOver())
                    {
                        mode = 3;
                        finScr = new FinalScreen();
                        finScr.SetPoints(table.GetPoints());
                    }
                }
                else if (mode == 3)
                {
                    finScr.Draw(window);
                    if (finScr.ButtonPushed())
                    {
                        mode = 1;
                        stScr = new StartScreen();
                    }
                }

                //_1.main(window);

                window.Display();
            }
        }

        private static void Window_Resized(object sender, SizeEventArgs e)
        {
            view.Size = new SFML.System.Vector2f(e.Width,e.Height);
            window.SetView(view);
            Console.WriteLine(window.Position);
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (mode == 2) { table.MousePressed(window); }
            else if (mode == 3) { finScr.MousePressed(window); }
            else if (mode == 1) { stScr.MousePressed(window); }
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}