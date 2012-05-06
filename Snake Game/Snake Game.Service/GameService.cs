using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    public class GameService : IGameService
    {
        private readonly int STAGE_HEIGTH = 13;
        private readonly int STAGE_WIDTH = 25;
        private readonly int POINT = 15;
        private readonly IGameStage stage;
        private readonly ISnakeService snake;
        private readonly IGameComponent food;
        private readonly IPlayerService player;
        private readonly IBugService bug;

        //private bool orent;
        public GameService()
        {
            stage = new GameStageService(STAGE_WIDTH, STAGE_HEIGTH);
            bug = new BugService(STAGE_WIDTH, STAGE_HEIGTH);
            snake = new SnakeService();
            food = new FoodService();
            player = new PlayerService();

            food.AddItem(new Vector2(10, 10));
            //orent = true;
        }

        public int[,] GetGameStage()
        {
            StageUpdate();
            return stage.GetStageCoord();
        }

        private bool EmtyCoord(LinkedList<Vector3> coord, Vector2 newCord)
        {
            foreach(Vector3 list in coord){
                if (list.X == newCord.X && list.Y == newCord.Y)
                {
                    return false;
                }
            }
            return true;
        }

        private bool MoveX(int x)
        {
            LinkedList<Vector3> coord = snake.GetSnakeCoordinates();
            Vector3 head = snake.GetSnakeHead();
            if (x >= 0 &&  x < STAGE_WIDTH)
            {
                return EmtyCoord(coord, new Vector2(x, head.Y));
            }
            return false;
        }

        private bool MoveY(int y)
        {
            LinkedList<Vector3> coord = snake.GetSnakeCoordinates();
            Vector3 head = snake.GetSnakeHead();
            if (y >= 0 && y < STAGE_HEIGTH)
            {
                return EmtyCoord(coord, new Vector2(head.X, y));
            }
            return false;
        }

        /// ToDO 
        /// perasyt si metoda, isskaidyti i mazesnius ir t.t.
        

        //judejimo metodas, na toks nemenkas gausis
        public void SetMovment(int x, int y)
        {
            Vector3 head = snake.GetSnakeHead();
            Vector3 tail = snake.GetSnakeTail();
            RemoveBug(bug.GetCoord());

            if (x == 1) //x as fiksuotas
            {
                if (y == 1)
                {
                    if (MoveX((int)head.X + x))
                    {
                        head.X += 1;
                        head.Z = 1;
                        snake.Move(head);
                        //bug.SetDirection(head);
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
                        head.Z = 2;
                        snake.Move(head);
                        //bug.SetDirection(head);
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
                        head.Z = -1;
                        head.X -= 1;
                        snake.Move(head);
                        //bug.SetDirection(head);
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
                        head.Z = -2;
                        head.Y += 1;
                        snake.Move(head);
                       // bug.SetDirection(head);
                    }
                    else
                    {
                        //gyvate atsimuse
                    }
                }
            }
            if (!EatFood(new Vector2(head.X, head.Y)))
            {
                stage.RemoveSnkaeTail(new Vector2(tail.X, tail.Y), new Vector2(snake.GetSnakeTail().X, snake.GetSnakeTail().Y));
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
                player.AddPoint(POINT); 
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
            FillBugCoord();
        }

        private void RemoveBug(Vector2 bugCoor)
        {
            stage.RemoveBugCoord(bug.GetCoord());
        }

        private void FillSnakeCoord(LinkedList<Vector3> list)
        {
            stage.SetSnakeHead(list.First());
            for (int i = 1; i < list.Count - 2; i++)
            {
                stage.SetSnakeTurnCoord(list.ElementAt(i), (int)list.ElementAt(i-1).Z);
                //stage.SetSnakeCoordinates(list.ElementAt(i));
            }
            stage.SetSnakeTail(list.Last(), (int)list.ElementAt(list.Count -2).Z);
        }

        private void FillFoodCoord(LinkedList<Vector2> list)
        {
            foreach (var a in list)
            {
                stage.SetSnakeFood(a);
            }
        }

        private void FillBugCoord()
        {
            stage.SetBugCoord(bug.GetCoord());
        }

        public string GetPoints()
        {
            return player.GetPoints().ToString();
        }

        public string GetLives()
        {
            return player.GetLive().ToString();
        }
    }
}
