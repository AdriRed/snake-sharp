using System;
using System.Threading;
using snake_back;

namespace snake_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Console.CursorVisible = false;

            while (!game.pGameOver)
            {
                
                if (Console.KeyAvailable)
                {
                    game.Control(Console.ReadKey(true).Key);
                }
                game.Update();
                game.Display();
                Thread.Sleep(100);
                
            }

            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 4, Console.WindowHeight / 2);
            Console.WriteLine("GAME OVER");
        }
    }
}
