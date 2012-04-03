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

        public void SetSnakeFood(Vector2 coord)
        {
            stageMatrix[(int)coord.X, (int)coord.Y] = 2;
        }

        public void SetSnakeCoordinates(Vector2 coord)
        {
            stageMatrix[(int)coord.X, (int)coord.Y] = 1;
        }

        public void RemoveSnakeCoordinate(Vector2 coord)
        {
        }

        public void RemoveSnkaeTail(Vector2 coord)
        {
            stageMatrix[(int)coord.X, (int)coord.Y] = 0;
        }
    }
}
