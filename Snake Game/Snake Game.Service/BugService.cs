using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    public class BugService : IBugService
    {
        private Vector3 coord;
        private readonly int STAGE_WEIGHT;
        private readonly int STAGE_HEIGHT;
        private int newDir = 1;
        private bool hit = true;
        private bool snakeWarning = false;
        private int length;
        private bool lockStartegy = false;

        public BugService(int StageWeight, int StageHeigth)
        {
            this.STAGE_WEIGHT = StageWeight;
            this.STAGE_HEIGHT = StageHeigth;
            coord.X = 5;
            coord.Y = 6;
        }

        /// <summary>
        /// Metodas apskaiciuojantis atstumą tarp vabalo ir gyavtės galvos. Atstumas skaičiuojamas pagal du taškus.
        /// </summary>
        /// <param name="snakeHead">Gyvatės galvos koordinatės</param>
        /// <returns>Gražinamas atstumas.</returns>
        private int DistanceFromSnakeHead(Vector3 snakeHead)
        {
            int distance;
            if(coord.X < snakeHead.X)
                distance = (int)Math.Round(Math.Sqrt(Math.Pow((snakeHead.X - coord.X), 2) +
                    Math.Pow((snakeHead.Y - coord.Y), 2)),0);
            else
                distance = (int)Math.Round(Math.Sqrt(Math.Pow((coord.X - snakeHead.X), 2) + 
                    Math.Pow((coord.Y - snakeHead.Y), 2)),0);
            return distance;
        }

        public void SetDirection(Vector3 snakeHead, int[,] stage)
        {
            int distance = DistanceFromSnakeHead(snakeHead);
            if (distance < 5) snakeWarning = true;
            else if (distance > 4) snakeWarning = false;

            GoBug(snakeHead, stage);
            //coord.X += CalculateX((int)snakeHead.X);
            //coord.Y += CalculateY((int)snakeHead.Y);
        }

        private void generateDirection()
        {
            Random random = new Random();
            length = random.Next(5, 10);
            switch (random.Next(0, 4))
            {
                case 0:
                    newDir = 1;
                    break;
                case 1:
                    newDir = 2;
                    break;
                case 2:
                    newDir = -1;
                    break;
                case 3:
                    newDir = -2;
                    break;
                default:
                    newDir = 1;
                    break;
            }
        }

        private bool CanMove(int[,] stage, Vector2 newCoord)
        {
            if(newCoord.X < STAGE_WEIGHT && newCoord.Y < STAGE_HEIGHT)
                if (stage[(int)newCoord.X, (int)newCoord.Y] == 0)
                    return true;
                else
                    return false;
            else
                return false;
        }

        private void GoBug(Vector3 snakeHead, int[,] stage)
        {
            if (snakeWarning)
                EscapeFromSnake(snakeHead);
            else if (length == 0 || hit)
            {
                hit = false;
                generateDirection();
            }
            length--;
            //desinen
            if (newDir == 1 && (int)coord.X + 1 < STAGE_WEIGHT && CanMove(stage, new Vector2(coord.X+1, coord.Y)))
            {
                coord.X += 1;
                coord.Z = newDir;
                hit = false;
                return;
            }
            else
            {
                hit = true;
            }
            //i virsu
            if (newDir == 2 && (int)coord.Y - 1 >= 0 && CanMove(stage, new Vector2(coord.X , coord.Y-1)))
            {
                coord.Y -= 1;
                coord.Z = newDir;
                hit = false;
                return;
            }
            else
            {
                hit = true;
            }
            //apacion
            if (newDir == -2 && (int)coord.Y + 1 < STAGE_HEIGHT && CanMove(stage, new Vector2(coord.X, coord.Y+1)))
            {
                coord.Y += 1;
                coord.Z = newDir;
                hit = false;
                return;
            }
            else
            {
                hit = true;
            }
            //kairen
            if (newDir == -1 && (int)coord.X - 1 >= 0 && CanMove(stage, new Vector2(coord.X - 1, coord.Y)))
            {
                coord.X -= 1;
                coord.Z = newDir;
                hit = false;
                return;
            }
            else
            {
                hit = true;
            }
        }


        private void Situation1()
        {
            if (coord.Y + 1 <= STAGE_HEIGHT) newDir = -2;
            else if (coord.X - 1 >= 0) newDir = -1;
            else newDir = 1;
        }

        private void Situation2()
        {
            if (coord.X + 1 <= STAGE_WEIGHT) newDir = 1;
            else if (coord.Y - 1 >= 0) newDir = 2;
            else newDir = -2;
        }

        private void Situation3()
        {
            if (coord.Y - 1 >= 0) newDir = 2;
            else if (coord.X + 1 <= STAGE_WEIGHT) newDir = 1;
            else newDir = -2;
        }

        private void Situation4()
        {
            if (coord.Y - 1 >= 0) newDir = 2;
            else if (coord.X - 1 >= 0) newDir = -1;
            else newDir = 1;
        }

        private void Situation5()
        {
            if (coord.X - 1 >= 0) newDir = -1;
            else if (coord.Y + 1 <= STAGE_HEIGHT) newDir = -2;
            else newDir = 2;
        }

        private void Situation6()
        {
            if (coord.Y + 1 <= STAGE_HEIGHT) newDir = -2;
            else if (coord.X + 1 <= STAGE_WEIGHT) newDir = 1;
            else newDir = -1;
        }

        private void Situation7()
        {
            if (coord.Y - 1 >= 0) newDir = 2;
            else if (coord.X + 1 <= STAGE_WEIGHT) newDir = 1;
            else newDir = -1;
        }

        private void Situation8()
        {
            if (coord.X - 1 >= 0) newDir = -1;
            else if (coord.Y + 1 <= STAGE_HEIGHT) newDir = -2;
            else newDir = 1;
        }

        private void Situation9()
        {
            if (coord.Y + 1 <= STAGE_HEIGHT) newDir = -2;
            else if (coord.X - 1 >= 0) newDir = -1;
            else newDir = -1;
        }

        private void Situation10()
        {
            if (coord.X - 1 >= 0) newDir = -1;
            else if (coord.Y - 1 >= 0) newDir = 2;
            else newDir = -2;
        }

        private void Situation11()
        {
            if (coord.X + 1 <= STAGE_WEIGHT) newDir = 1;
            else if (coord.Y - 1 >= 0) newDir = 2;
            else newDir = -1;
        }

        private void Situation12()
        {
            if (coord.X - 1 >= 0) newDir = -1;
            else if (coord.Y - 1 >= 0) newDir = 2;
            else newDir = 1;
        }

        private void EscapeFromSnake(Vector3 snakeHead)
        {
            int snakeLocation = WhereSnakeHead(snakeHead);
            if (lockStartegy && !hit) return; 
            if (snakeHead.Z == 1)
            {
                if (snakeLocation == 1) { lockStartegy = true; Situation5(); return; }//canLeft
                if (snakeLocation == 2) { lockStartegy = true; Situation6(); return; }//CanUp()
                if (snakeLocation == 3) { lockStartegy = true; Situation7(); return; }//CanUp()
                if (snakeLocation == 4) { lockStartegy = true; Situation5(); return; }//CanLeft()
            }

            if (snakeHead.Z == -1)
            {
                if (snakeLocation == 1) { lockStartegy = true; Situation1(); return; }//CanUp
                if (snakeLocation == 2) { lockStartegy = true; Situation2(); return; }//CanLeft
                if (snakeLocation == 3) { lockStartegy = true; Situation3(); return; }//CanLeft
                if (snakeLocation == 4) { lockStartegy = true; Situation4(); return; }//CanUp
            }

            if (snakeHead.Z == 2)
            {
                if (snakeLocation == 1) { lockStartegy = true; Situation8(); return; }//CanDown()
                if (snakeLocation == 2) { lockStartegy = true; Situation9(); return; }//CanDown
                if (snakeLocation == 3) { lockStartegy = true; Situation2(); return; }//CanLeft
                if (snakeLocation == 4) { lockStartegy = true; Situation10(); return; }//CanRight
            }

            if (snakeHead.Z == -2)
            {
                if (snakeLocation == 1) { lockStartegy = true; Situation5(); return; }//CanRight
                if (snakeLocation == 2) { lockStartegy = true; Situation2(); return; }//CanRight
                if (snakeLocation == 3) { lockStartegy = true; Situation11(); return; }//CanUp
                if (snakeLocation == 4) { lockStartegy = true; Situation12(); return; }//CanUp
            }
            
        }

        /// <summary>
        /// Metodas, kurio pagalba nustatoma kur yra gyvate koordinačių sistemoje
        /// vabalo atžvilgiu.
        /// </summary>
        /// <param name="snakeHead"></param>
        /// <returns></returns>
        private int WhereSnakeHead(Vector3 snakeHead)
        {
            int y = 0;
            int x = 0;
            //zemiau vabalo
            if (coord.Y >= snakeHead.Y)
                y = -1; 
            else /*auksciau vabalo*/
                y = 1;
            //kaireje vabalo
            if (coord.X >= snakeHead.X)
                x = -1;
            else
                /*desinej vabalo*/
                x = 1;
            if (x == 1 && y == 1) return 1; //pirmas ketvirtis
            else if (x == 1 && y == -1) return 4; // ketvirtas ketvirtis
            else if (x == -1 && y == 1) return 2;// antras ketvirtis
            else
                return 3; // trecias ketvirtis
        }

        public Vector3 GetCoord()
        {
            return this.coord;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }


        public Vector2 BugCoord()
        {
            return new Vector2(coord.X, coord.Y);
        }
    }
}
