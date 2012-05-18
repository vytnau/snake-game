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
        public int POINT {set; get;}
        private readonly IGameStage stage;
        private readonly ISnakeService snake;
        private readonly IGameComponent food;
        private readonly IPlayerService player;
        private readonly IBugService bug;
        private bool snakeHit = false;
        private int level;

        //private bool orent;
        public GameService()
        {
            POINT = 15;
            stage = new GameStageService(STAGE_WIDTH, STAGE_HEIGTH);
            bug = new BugService(STAGE_WIDTH, STAGE_HEIGTH);
            snake = new SnakeService();
            food = new FoodService();
            player = new PlayerService();

            food.AddItem(new Vector3(10, 10, 1));
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
            //RemoveBug(bug.GetCoord());

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
                        SnakeHit();
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
                        SnakeHit();
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
                        SnakeHit();
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
                        SnakeHit();
                    }
                }
            }
            if (!EatFood(snake.GetSnakeHead()))
            {
                stage.RemoveSnkaeTail(new Vector2(tail.X, tail.Y), new Vector2(snake.GetSnakeTail().X, snake.GetSnakeTail().Y));
            }
            else
            {
                snake.GrowSnake(tail);
            }
            StageUpdate();

        }

        /// <summary>
        /// Metodas fiksuojantis gyvatės atsimušimą į kliūtį ar į savo kūną.
        /// </summary>
        private void SnakeHit()
        {
            snakeHit = true;
            player.DecreseLive();
            /*RemoveSnakeCoord(snake.GetSnakeCoordinates());
            snake.SetNewSnake();*/
        }

        private bool EatFood(Vector3 snakeHead)
        {
            LinkedList<Vector2> list = food.GetVector2List();
            if (list.Contains(new Vector2(snakeHead.X, snakeHead.Y)))
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
            var coord = new Vector3();
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

        private Vector3 RandomCoord()
        {
            var coord = new Vector3();
            Random random = new Random();
            coord.X = random.Next(2, this.STAGE_WIDTH-1);
            coord.Y = random.Next(2, this.STAGE_HEIGTH-1);
            coord.Z = random.Next(1, 3);
            return coord;
        }

        public void StageUpdate()
        {
            FillSnakeCoord(snake.GetSnakeCoordinates());
            FillFoodCoord(food.GetList());
           // FillBugCoord();
        }

        private void RemoveBug(Vector2 bugCoor)
        {
            stage.RemoveBugCoord(bug.GetCoord());
        }

        private void FillSnakeCoord(LinkedList<Vector3> list)
        {
            stage.SetSnakeHead(list.First());
            for (int i = 1; i < list.Count - 1; i++)
            {
                stage.SetSnakeTurnCoord(list.ElementAt(i), (int)list.ElementAt(i-1).Z);
            }
            stage.SetSnakeTail(list.Last(), (int)list.ElementAt(list.Count -2).Z);
        }

        private void RemoveSnakeCoord(LinkedList<Vector3> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                stage.RemoveSnakeCoordinate(list.ElementAt(i));
            }
        }

        private void FillFoodCoord(LinkedList<Vector3> list)
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

        public int GetLives()
        {
            return player.GetLive();
        }


        public void SetPoints(int point)
        {
            POINT = point;
        }


        bool IGameService.SnakeHit()
        {
            return snakeHit;
        }


        public void NewGame()
        {
            RemoveSnakeCoord(snake.GetSnakeCoordinates());
            snake.SetNewSnake();
            snakeHit = false;
        }


        /// <summary>
        /// Metodas formuoja dvimačią matricą, kurioje įrašoma informaciją apie tai, kur
        /// nuo gyvatės galvos, per 4 vienetus yra nutolęs gyvatės maistas. Rezultatas naudojamas piešiant radarą.
        /// </summary>
        /// <returns>Gražiną dvimatę matricą užpildytą vienetais, ten kur yra gyvatės maistas</returns>
        public int[,] RadarData()
        {
            int[,] radarData = new int[9, 9];
            Vector2 head = new Vector2(snake.GetSnakeHead().X, snake.GetSnakeHead().Y);
            LinkedList<Vector2> list = food.GetVector2List();
            for (int i = -4; i < 5; i++)
            {
                for (int j = -4; j < 5; j++)
                {
                    if(list.Contains(new Vector2(head.X +i, head.Y+j))){
                        radarData[4+i, 4+j] = 1;
                    }
                }
            }
            return radarData;
        }


        public void SetLevel(int level)
        {
            this.level = level;
            ConfigurateGame();
        }

        private void ConfigurateGame()
        {
            switch (level)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        private void ClasicGame()
        {
            snake = new SnakeService();
            food = new FoodService();
            player = new PlayerService();
            food.AddItem(new Vector3(10, 10, 1));
        }
    }
}
