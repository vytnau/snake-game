using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    public class SnakeService : ISnakeService
    {
        private LinkedList<Vector2> snake;

        public SnakeService()
        {
            Initialize();
        }

        private void Initialize()
        {
            snake = new LinkedList<Vector2>();
            for (int i = 0; i < 6; i++)
            {
                snake.AddLast(new Vector2(13 + i, 10));
            }
        }

        public void GrowSnake(Vector2 tail)
        {
            snake.AddLast(tail);
        }


        public void Move(Vector2 xy)
        {
            snake.RemoveLast();
            snake.AddFirst(xy);
        }


        public LinkedList<Vector2> GetSnakeCoordinates()
        {
            return snake;
        }

        public Vector2 GetSnakeHead()
        {
            return snake.First();
        }

        public Vector2 GetSnakeTail()
        {
            return snake.Last();
        }
    }
}
