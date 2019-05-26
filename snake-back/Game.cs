using System;
using System.Numerics;
using System.Collections.Generic;
using snake_back.Objects;

namespace snake_back
{
    public class Game
    {
        private Snake Player;
        private Token Apple = null;
        private bool GameOver;
        private bool CanGenerateApple = true;
        private Random Generator;
        private readonly char HEAD = '@', TAIL = '*', APPLE = '?';
        /*private Limits Walls;
        private Puntuation Score;*/

        public bool pGameOver {
            get
            {
                return GameOver;
            }
        }

        public Game()
        {
            Player = new Snake();
            Generator = new Random();
            CanGenerateApple = false;
        }

        public void GenerateApple()
        {
            Apple = new Token( Generator.Next(0, Console.WindowWidth) , Generator.Next(0, Console.WindowWidth) );
            CanGenerateApple = false;
        }

        public void CheckEat()
        {
            if (Apple != null)
            {
                if (Player.pPosition.Equals(Apple.pPosition))
                {
                    Player.AddSection();
                    Apple = null;
                    CanGenerateApple = true;
                }
            }
        }

        public void Control (ConsoleKey dir)
        {
            Player.ChangeDir(dir);
        }

        public void Update()
        {
            
            if (CanGenerateApple) GenerateApple();
            if (Apple != null) CheckEat();

            Player.Move();
            GameOver = !Player.IsAlive();
        }

        public void Display()
        {
            List<Vector2> positions = Player.GetPositions();

            Console.Clear();

            if (Apple != null)
                WriteAt(APPLE, (int) Apple.pPosition.X, (int) Apple.pPosition.Y);

            WriteAt(HEAD, (int) positions[0].X, (int) positions[0].Y);

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
