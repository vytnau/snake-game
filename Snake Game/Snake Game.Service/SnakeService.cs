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
            SetNewSnake();
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


        public void SetNewSnake()
        {
            snake = new LinkedList<Vector3>();
            for (int i = 0; i < 6; i++)            
                snake.AddLast(new Vector3(14 + i, 6, -1));            
        }


        public void SetNewSnakeClassic()
        {
            SetNewSnake();
        }

        public void SetNewSnakeLongSnake()
        {
            snake = new LinkedList<Vector3>();
            snake.AddFirst(new Vector3(24, 6, -1));
            snake.AddFirst(new Vector3(23, 6, -1));
        }


        public void SetNewSnakeInNight()
        {
            snake = new LinkedList<Vector3>();
            //zemyn
            for (int j = 2; j < 7; j++)
            {
                snake.AddFirst(new Vector3(17, j, -2));
            }
            snake.AddFirst(new Vector3(16, 6, -1));
        }


        public void SetNewSnakeAndBugs()
        {
            snake = new LinkedList<Vector3>();
            for (int j = 22; j > 15; j--)
            {
                snake.AddFirst(new Vector3(j, 6, -1));
            }
        }


        public void SetNewSnakeInBarriers()
        {
            snake = new LinkedList<Vector3>();
            //kairen
            for (int j = 19; j > 15; j--)
            {
                snake.AddFirst(new Vector3(j, 1, -1));
            }
            snake.AddFirst(new Vector3(16, 2, -2));
            snake.AddFirst(new Vector3(16, 3, -2));
        }


        public void SetNewSnakeInBarriers1()
        {
            snake = new LinkedList<Vector3>();
            //kairen
            for (int j = 14; j < 19; j++)
            {
                snake.AddLast(new Vector3(j, 6, -1));
            }
        }

        public int SnakeLenght()
        {
            return snake.Count;
        }
    }
}
