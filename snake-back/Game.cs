using System;
using System.Numerics;
using System.Collections.Generic;
using snake_back.Objects;

namespace snake_back
{
    public class Game
    {
        private Snake Player;
        private bool GameOver;
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
        }

        public void Control (byte dir)
        {
            Player.ChangeDir(dir);
        }

        public void Update()
        {
            Player.Move();
            GameOver = !Player.IsAlive();
        }

        public void Display()
        {
            Console.Clear();

            List<Vector2> positions = Player.GetPositions();
            WriteAt('@', (int) positions[0].X, (int) positions[0].Y);

            for (int i = 1; i < positions.Count; i++)
            {
                WriteAt('*', (int)positions[i].X, (int)positions[i].Y);
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
