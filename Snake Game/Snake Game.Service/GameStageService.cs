using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    public class GameStageService : IGameStage
    {
        private int[,] stageMatrix; 
        public GameStageService(int width, int heigth)
        {
            stageMatrix = new int[width, heigth];
            ///TODO 
            ///sukurti konstantas
            ///
        }

        public int[,] GetStageCoord()
        {
            return stageMatrix;
        }

        public void SetSnakeFood(Vector3 coord)
        {
            switch ((int)coord.Z)
            {
                case 1:
                    stageMatrix[(int)coord.X, (int)coord.Y] = 8;
                    break;
                case 2:
                    stageMatrix[(int)coord.X, (int)coord.Y] = -8;
                    break;
            }
        }

        public void SetSnakeCoordinates(Vector3 coord)
        {
            if (coord.Z == 1 || coord.Z == -1)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = 5;
            }
            else
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = -5;
            }
        }

        public void RemoveSnakeCoordinate(Vector3 coord)
        {
            stageMatrix[(int)coord.X, (int)coord.Y] = 0;
        }

        public void RemoveSnkaeTail(Vector2 coordPrev, Vector2 coordCuren)
        {
            stageMatrix[(int)coordPrev.X, (int)coordPrev.Y] = 0;
            stageMatrix[(int)coordCuren.X, (int)coordCuren.Y] = 6;
        }

        public void SetBugCoord(Vector2 bugCoord)
        {
            stageMatrix[(int)bugCoord.X, (int)bugCoord.Y] = 3;
        }


        public void RemoveBugCoord(Vector2 bugCoord)
        {
            stageMatrix[(int)bugCoord.X, (int)bugCoord.Y] = 0;
        }


        public void SetSnakeHead(Vector3 coord)
        {
            if (coord.Z == 1)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = 1;
                return;
            }
            else if (coord.Z == -1)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = -1;
                return;
            }
            else if (coord.Z == 2)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = 2;
                return;
            }
            else if (coord.Z == -2)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = -2;
                return;
            }
            
        }

        public void SetSnakeTail(Vector3 coord, int orent)
        {
            
            //if (coord.Z == 1)
            if (orent == 1)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = -6;
                return;
            }
            else if (orent == -1)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = 6;
                return;
            }
            else if (orent == 2)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = 7;
                return;
            }
            else if (orent == -2)
            {
                stageMatrix[(int)coord.X, (int)coord.Y] = -7;
                return;
            }
        }

        public void SetSnakeTurnCoord(Vector3 coord, int orent)
        {
            if (orent == 1) // i desine
            {
                if (coord.Z == 2) // is virsaus
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 10;
                    return;
                }
                else if (coord.Z == -2)
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 11;
                    return;
                }
            }
            else if (orent == -1)
            {
                if (coord.Z == 2) // is virsaus
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 12;
                    return;
                }
                else if (coord.Z == -2)
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 13;
                    return;
                }
            }

            if (orent == 2)
            {
                if (coord.Z == 1) // is virsaus
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 13;
                    return;
                }
                else if (coord.Z == -1)
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 11;
                    return;
                }
            }
            else if (orent == -2)
            {
                if (coord.Z == 1) // is virsaus
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 12;
                    return;
                }
                else if (coord.Z == -1)
                {
                    stageMatrix[(int)coord.X, (int)coord.Y] = 10;
                    return;
                }
            }
            SetSnakeCoordinates(coord);
        }


        public void SetBarrierCoord(Vector3 coord)
        {
            stageMatrix[(int)coord.X, (int)coord.Y] = (int)coord.Z;
        }
    }
}
