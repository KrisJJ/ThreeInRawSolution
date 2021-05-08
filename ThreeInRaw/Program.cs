using System;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;

namespace ThreeInRaw
{
    class Program
    {
        static RenderWindow window;
        static Table table = new Table(10, 10);

        static void Main(string[] args)
        {
            window = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Testing window");
            window.SetVerticalSyncEnabled(true);

            window.Closed += Window_Closed;

            window.MouseButtonPressed += Window_MouseButtonPressed;

            while (window.IsOpen)
            {
                window.DispatchEvents();

                window.Clear(Color.White);

                table.DeleteTriplets();

                table.Draw(window);

                //_1.main();

                window.Display();
            }
        }

        private static void Window_MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            table.MousePressed(window);
        }

        private static void Window_Closed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}