﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    public class GameService : IGameService
    {
        private readonly int STAGE_HEIGTH = 40;
        private readonly int STAGE_WIDTH = 60;
        private readonly IGameStage stage;
        private readonly ISnakeService snake;
        private readonly IGameComponent food;
        //private bool orent;
        public GameService()
        {
            stage = new GameStageService(STAGE_WIDTH, STAGE_HEIGTH);
            snake = new SnakeService();
            food = new FoodService();

            food.AddItem(new Vector2(10, 10));
            //orent = true;
        }

        public int[,] GetGameStage()
        {
            StageUpdate();
            return stage.GetStageCoord();
        }

        private bool MoveX(int x)
        {
            LinkedList<Vector2> coord = snake.GetSnakeCoordinates();
            if (x > 0 &&  x < STAGE_WIDTH)
            {
                if (!coord.Contains(new Vector2(x, snake.GetSnakeHead().Y)))
                {
                    return true;
                }
            }
            return false;
        }

        private bool MoveY(int y)
        {
            LinkedList<Vector2> coord = snake.GetSnakeCoordinates();
            if (y > 1 && y < STAGE_HEIGTH)
            {
                if (!coord.Contains(new Vector2(snake.GetSnakeHead().X, y)))
                {
                    return true;
                }
            }
            return false;
        }


        //judejimo metodas, na toks nemenkas gausis
        public void SetMovment(int x, int y)
        {
            Vector2 head = snake.GetSnakeHead();
            Vector2 tail = snake.GetSnakeTail();
            if (x == 1)
            {
                if (y == 1)
                {
                    if (MoveX((int)head.X + x))
                    {
                        head.X += 1;
                        snake.Move(head);
                    }
                    else
                    {
                        //gyvate atsimuse
                    }
                }
                else
                {
                    if (MoveY((int)head.Y - 1))
                    {
                        head.Y -= 1;
                        snake.Move(head);
                    }
                    else
                    {
                        //gyvate atsimuse
                    }
                }
            }
            else
            {
                if (y == 1)
                {
                    if (MoveX((int)head.X - 1))
                    {
                        head.X -= 1;
                        snake.Move(head);
                    }
                    else
                    {
                        //gyvate atsimuse
                    }
                }
                else
                {
                    if (MoveY((int)head.Y + 1))
                    {
                        head.Y += 1;
                        snake.Move(head);
                    }
                    else
                    {
                        //gyvate atsimuse
                    }
                }
            }
            if (!EatFood(head))
            {
                stage.RemoveSnkaeTail(tail);
            }
            else
            {
                snake.GrowSnake(tail);
            }
            StageUpdate();

        }

        private bool EatFood(Vector2 snakeHead)
        {
            LinkedList<Vector2> list = food.GetList();
            if (list.Contains(snakeHead))
            {
                food.RemoveItem(snakeHead);
                CreateFood();
                return true;
            }
            return false;
        }

        private void CreateFood()
        {
            var coord = new Vector2();
            bool check = true;
            int[,] stageCoord = stage.GetStageCoord();
            while (check)
            {
                coord = RandomCoord();
                if (stageCoord[(int)coord.X, (int)coord.Y] == 0)
                {
                    check = false;
                }
            }
            food.AddItem(coord);
        }

        private Vector2 RandomCoord()
        {
            var coord = new Vector2();
            Random random = new Random();
            coord.X = random.Next(2, this.STAGE_WIDTH-1);
            coord.Y = random.Next(2, this.STAGE_HEIGTH-1);
            return coord;
        }

        public void StageUpdate()
        {
            FillSnakeCoord(snake.GetSnakeCoordinates());
            FillFoodCoord(food.GetList());
        }

        private void FillSnakeCoord(LinkedList<Vector2> list)
        {
            foreach (var a in list)
            {
                stage.SetSnakeCoordinates(a);
            }
        }

        private void FillFoodCoord(LinkedList<Vector2> list)
        {
            foreach (var a in list)
            {
                stage.SetSnakeFood(a);
            }
        }
    }
}