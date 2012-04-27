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
        private Vector2 coord;
        private readonly int STAGE_WEIGHT;
        private readonly int STGAE_HEIGHT;

        public BugService(int StageWeight, int StageHeigth)
        {
            this.STAGE_WEIGHT = StageWeight;
            this.STGAE_HEIGHT = StageHeigth;
            coord.X = 20;
            coord.Y = 10;
        }

        public void SetDirection(Vector2 snakeHead)
        {
            coord.X += CalculateX((int)snakeHead.X);
            coord.Y += CalculateY((int)snakeHead.Y);
        }

        private int CalculateX(int snakeHeadX)
        {
            if ((int)this.coord.X - snakeHeadX < 5)
            {
                if ((int)this.coord.X + 1 < this.STAGE_WEIGHT)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if ((int)this.coord.X - snakeHeadX > -5)
            {
                if ((int)this.coord.X - 1 > 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        private int CalculateY(int snakeHeadY)
        {
            if ((int)this.coord.Y - snakeHeadY < 5)
            {
                if ((int)this.coord.Y + 1 < this.STGAE_HEIGHT)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else if ((int)this.coord.Y - snakeHeadY > -5)
            {
                if ((int)this.coord.Y - 1 > 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            return 0;
        }

        public Vector2 GetCoord()
        {
            return this.coord;
        }

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
