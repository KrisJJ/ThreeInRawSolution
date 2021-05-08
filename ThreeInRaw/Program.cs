using System;
using SFML.Audio;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace ThreeInRaw
{
    class Program
    {
        static RenderWindow window;
        static Table table = new Table(8, 8);

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

                while (table.VoidExists()) { table.FillVoid(); }

                table.Draw(window);

                //_1.main(window);

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