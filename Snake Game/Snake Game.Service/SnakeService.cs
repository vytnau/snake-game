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
        private LinkedList<Vector3> snake;

        public SnakeService()
        {
            Initialize();
        }

        private void Initialize()
        {
            snake = new LinkedList<Vector3>();
            for (int i = 0; i < 6; i++)
            {
                snake.AddLast(new Vector3(13 + i, 10, -1));
            }
        }

        public void GrowSnake(Vector3 tail)
        {
            snake.AddLast(tail);
        }


        public void Move(Vector3 xy)
        {
            snake.RemoveLast();
            snake.AddFirst(xy);
        }


        public LinkedList<Vector3> GetSnakeCoordinates()
        {
            return snake;
        }

        public Vector3 GetSnakeHead()
        {
            return snake.First();
        }

        public Vector3 GetSnakeTail()
        {
            return snake.Last();
        }
    }
}
