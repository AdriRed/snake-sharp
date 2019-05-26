using snake_back.Objects;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace snake_back
{
    public class Game
    {
        private Snake Player;
        private Token Apple = null;
        private bool GameOver;
        private bool CanGenerateApple = true;
        private Random RandomNumber;
        private readonly char HEAD = '@', TAIL = '*', APPLE = '?';
        /*private Limits Walls;
        private Puntuation Score;*/

        public bool pGameOver
        {
            get
            {
                return GameOver;
            }
        }

        public Game()
        {
            Player = new Snake();
            RandomNumber = new Random();
        }

        public void Update()
        {
            Player.Move();

            if (CanGenerateApple)
            {
                //chance de generar apple
                if (RandomNumber.Next(0, 3) > 1)
                {
                    Apple = new Token(RandomNumber.Next(0, Console.WindowWidth), RandomNumber.Next(0, Console.WindowHeight));
                    CanGenerateApple = false;
                }

            }
            else
            {
                //checa si ha comido apple
                if (Player.pPosition.Equals(Apple.pPosition))
                {
                    Apple = null;
                    Player.AddSection();
                    CanGenerateApple = true;
                }
            }

            GameOver = !Player.IsAlive();
        }

        public void Control(ConsoleKey dir)
        {
            Player.ChangeDir(dir);
        }

        public void Display()
        {
            List<Vector2> positions = Player.GetPositions();

            Console.Clear();

            if (Apple != null)
                WriteAt(APPLE, (int)Apple.pPosition.X, (int)Apple.pPosition.Y);

            WriteAt(HEAD, (int)positions[0].X, (int)positions[0].Y);

            for (int i = 1; i < positions.Count; i++)
            {
                WriteAt(TAIL, (int)positions[i].X, (int)positions[i].Y);
            }
        }

        protected static void WriteAt(char s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
    }
}
