using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;
using DomainModel.Sound;
using Snake_Game.ServiceContracts.SoundsInterface;
using Snake_Game.Service.SoundsService;
namespace Snake_Game.Service
{
    public class GameService : IGameService
    {
        private readonly int STAGE_HEIGTH = 13;
        private readonly int STAGE_WIDTH = 25;
        private const int BUG_POINT = 1000;
        public int POINT {set; get;}
        private readonly IGameStage stage;
        private readonly ISnakeService snake;
        private readonly IGameComponent food;
        private readonly IPlayerService player;
        private readonly BarrierService barrier;
        private IBugService bug;
        private readonly ISnakeSoundsService snakeSound;
        private readonly IGameBackgroundSoundsService backgroundSound;
        private bool snakeHit = false;
        private int level;

        //private bool orent;
        public GameService(SnakeSounds sound)
        {
            POINT = 15;
            stage = new GameStageService(STAGE_WIDTH, STAGE_HEIGTH);
            bug = new BugService(STAGE_WIDTH, STAGE_HEIGTH);
            snake = new SnakeService();
            food = new FoodService();
            player = new PlayerService();
            barrier = new BarrierService();
            snakeSound = new SnakeSoundsService(sound.SnakeSound);
            backgroundSound = new GameBackgroundSoundsService(sound.BackgroundSound);
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
            LinkedList<Vector3> barr = barrier.GetList();
            Vector3 head = snake.GetSnakeHead();
            if (x >= 0 &&  x < STAGE_WIDTH)
            {
                if (!EmtyCoord(coord, new Vector2(x, head.Y))) return false;
                if (!EmtyCoord(barr, new Vector2(x, head.Y))) return false;
            }
            else return false;
            return true;
        }

        private bool MoveY(int y)
        {
            LinkedList<Vector3> coord = snake.GetSnakeCoordinates();
            LinkedList<Vector3> barr = barrier.GetList();
            Vector3 head = snake.GetSnakeHead();
            if (y >= 0 && y < STAGE_HEIGTH)
            {
                if (!EmtyCoord(coord, new Vector2(head.X, y))) return false;
                if (!EmtyCoord(barr, new Vector2(head.X, y))) return false;
            }
            else return false;
            return true;
        }

        /// ToDO 
        /// perasyt si metoda, isskaidyti i mazesnius ir t.t.
        

        //judejimo metodas, na toks nemenkas gausis
        public void SetMovment(int x, int y)
        {
            Vector3 head = snake.GetSnakeHead();
            Vector3 tail = snake.GetSnakeTail();
            //RemoveBug(bug.GetCoord());
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
                        
                    }
                    else
                    {
                        //gyvate atsimuse
                        snakeSound.PlaySnakeHit();
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
                    }
                    else
                    {
                        //gyvate atsimuse
                        snakeSound.PlaySnakeHit();
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
                    }
                    else
                    {
                        //gyvate atsimuse
                        snakeSound.PlaySnakeHit();
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
                    }
                    else
                    {
                        //gyvate atsimuse
                        snakeSound.PlaySnakeHit();
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
                snakeSound.PlayeSnakeEat();
                snake.GrowSnake(tail);
            }
            if (level == 2)
                backgroundSound.PlayOwl();
            if (level == 1)
            {
                if (snake.SnakeLenght() < 70)
                    snake.GrowSnake(tail);
            }
            StageUpdate();
            bug.SetDirection(snake.GetSnakeHead(), stage.GetStageCoord());
            if (level == 3)
            {
                EatBug(head);
                FillBugCoord();
            }
        }

        /// <summary>
        /// Metodas fiksuojantis gyvatės atsimušimą į kliūtį ar į savo kūną.
        /// </summary>
        private void SnakeHit()
        {
            snakeHit = true;
            player.DecreseLive();
            backgroundSound.StopPlaySounds();
            /*if (player.GetLive() == 0)
                backgroundSound.StopPlaySounds();*/
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

        private void EatBug(Vector3 snakeHead)
        {
            Vector2 bugCoord = bug.BugCoord();
            if (bugCoord.X == snakeHead.X && bugCoord.Y == snakeHead.Y)
            {
                snakeSound.PlayeSnakeEat();
                snake.GrowSnake(snake.GetSnakeTail());
                bug = new BugService(STAGE_WIDTH, STAGE_HEIGTH);
                player.AddPoint(BUG_POINT);
                
            }
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
            FillBarrierCoord(barrier.GetList());            
        }

        private void RemoveBug(Vector3 bugCoor)
        {
            stage.RemoveBugCoord(bug.GetCoord());
        }

        private void FillBarrierCoord(LinkedList<Vector3> list)
        {
            foreach (Vector3 a in list)
                stage.SetBarrierCoord(a);
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
            ConfigurateGame();
            //snake.SetNewSnake();
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
                    ClasicGame();
                    break;
                case 1:
                    SurvivalGame();
                    break;
                case 2:
                    SnakeInNight();
                    break;
                case 3:
                    SnakeAndBugs();
                    break;
                case 4:
                    FastSnake();
                    break;
                case 5:
                    SnakeInBarrier();
                    break;
                case 6:
                    SnakeInBarrier1();
                    break;
            }
        }

        private void ClasicGame()
        {
            backgroundSound.PlayBirdsSound();
            backgroundSound.PlayMusic();
            snake.SetNewSnakeClassic();
            if(food.Size() == 0)
                food.AddItem(new Vector3(10, 10, 1));
        }

        private void SurvivalGame()
        {
            backgroundSound.SurvivalMusic();
            snake.SetNewSnakeLongSnake();
            barrier.SurvivalMode();            
        }

        private void SnakeInNight()
        {
            backgroundSound.NightSound();
            barrier.SnakeInNight();
            snake.SetNewSnakeInNight();
            if (food.Size() == 0)
                food.AddItem(new Vector3(9, 3, 1));
        }

        private void SnakeAndBugs()
        {
            backgroundSound.CatchBugsMusic();
            barrier.SnakeAndBugs();
            snake.SetNewSnakeAndBugs();            
            if (food.Size() == 0)
                food.AddItem(new Vector3(9, 3, 1));
        }

        private void FastSnake()
        {
            backgroundSound.PlayBirdsSound();
            backgroundSound.PlayMusic();
            snake.SetNewSnakeClassic();
            if (food.Size() == 0)
                food.AddItem(new Vector3(9, 3, 1));
        }

        private void SnakeInBarrier()
        {
            backgroundSound.PlayBirdsSound();
            backgroundSound.PlayMusic();
            snake.SetNewSnakeInBarriers();
            barrier.SnakeInBarrier();
            if (food.Size() == 0)
                food.AddItem(new Vector3(8, 6, 1));
        }

        private void SnakeInBarrier1()
        {
            backgroundSound.PlayBirdsSound();
            backgroundSound.PlayMusic();
            snake.SetNewSnakeInBarriers1();
            barrier.SnakeInBarrier1();
            if (food.Size() == 0)
                food.AddItem(new Vector3(2, 6, 2));
        }

        public string GetGameType()
        {
            string value = "ee";
            switch (level)
            {
                case 0:
                    value = Difficult();
                    break;
                case 1:
                    value = "ar1";
                    break;
                case 2:
                    value = "ar2";
                    break;
                case 3:
                    value = "ar3";
                    break;
                case 4:
                    value = "ar4";
                    break;
                case 5:
                    value = "ar5";
                    break;
                case 6:
                    value = "ar6";
                    break;
            }
            return value;
        }

        private string Difficult()
        {
            switch (POINT)
            {
                case 25: 
                    return "cl2";
                case 10:
                    return "cl1";
                case 5:
                    return "cl0";
                default:
                    return "ee";
            }
        }


        public void CountPointByTime()
        {
            player.AddPoint(10);
        }

        public void GrowSnake()
        {
            if(snake.SnakeLenght() < 105)
                snake.GrowSnake(snake.GetSnakeTail());
        }


        public LinkedList<Vector2> GetSnakeHead()
        {
            LinkedList<Vector2> corners = new LinkedList<Vector2>();
            Vector3 head = snake.GetSnakeHead(); 
            Vector2 leftUpCorner;
            Vector2 rightDownCorner;
            switch ((int)head.Z)
            {
                case -2:
                    leftUpCorner = new Vector2(head.X - 3, head.Y - 1);
                    rightDownCorner = new Vector2(head.X + 3, head.Y + 6);
                    //zemyn
                    break;
                case -1:
                    leftUpCorner = new Vector2(head.X - 6, head.Y - 3);
                    rightDownCorner = new Vector2(head.X + 3, head.Y + 3);
                    //kairen
                    break;
                case 1:
                    leftUpCorner = new Vector2(head.X - 1, head.Y - 3);
                    rightDownCorner = new Vector2(head.X + 6, head.Y + 3);
                    //desinen
                    break;
                case 2:
                    leftUpCorner = new Vector2(head.X - 3, head.Y - 5);
                    rightDownCorner = new Vector2(head.X + 3, head.Y + 4);
                    //aukstyn
                    break;
                default:
                    leftUpCorner.X = 0;
                    leftUpCorner.Y = 0;
                    rightDownCorner.X = 25;
                    rightDownCorner.Y = 13;
                    break;

            }
            if ((int)leftUpCorner.X > 25) leftUpCorner.X = 25;
            if ((int)leftUpCorner.Y > 13) leftUpCorner.Y = 13;
            if ((int)rightDownCorner.X < 0) rightDownCorner.X = 0;
            if ((int)rightDownCorner.X > 25) rightDownCorner.X = 25;
            if ((int)rightDownCorner.Y < 0) rightDownCorner.Y = 0;
            if ((int)rightDownCorner.Y > 13) rightDownCorner.Y = 13;
            corners.AddFirst(rightDownCorner);
            corners.AddFirst(leftUpCorner);
            return corners;
        }


        public void StopSounds()
        {
            backgroundSound.StopPlaySounds();
        }
    }
}
