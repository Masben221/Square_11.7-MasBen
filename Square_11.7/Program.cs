using System;
using SFML.Graphics;
using SFML.Window;

namespace Square_11._7
{
    public class Program
    {
        //private static Game _game;
        public static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Game");
            win.Closed += Win_Closed;
            win.SetFramerateLimit(60);

            Game game = new Game();
            Menu menu = new Menu();

            menu.Start(win);

            game.Reset();

            while (win.IsOpen == true)
            {
                win.Clear(new Color(230, 230, 230));
               
                win.DispatchEvents();

                game.Update(win);

                win.Display();
            }
        }
        private static void Win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow)sender).Close();
        }
    }
}
