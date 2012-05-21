using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Snake_Game.ServiceContracts
{
    public interface IGameStage
    {
        /// <summary>
        /// Gražina žaidimo lauko masyvą.
        /// </summary>
        /// <returns></returns>
        int[,] GetStageCoord();

        /// <summary>
        /// Įrašo gyvatės maistą.
        /// </summary>
        void SetSnakeFood(Vector3 coord);

        /// <summary>
        /// Įrašoma gyvatės koordinatė į žaidimo lauko
        /// masyvą.
        /// </summary>
        /// <param name="x"></param>
        void SetSnakeCoordinates(Vector3 coord);

        void SetSnakeTurnCoord(Vector3 coord, int orent);

        void SetSnakeHead(Vector3 Coord);

        void SetSnakeTail(Vector3 Coord, int orent);

        /// <summary>
        /// Iš žaidimo lango šalinama gyvatės uodega.
        /// </summary>
        /// <param name="coord"></param>
        void RemoveSnkaeTail(Vector2 coordPrev, Vector2 coordCuren);

        /// <summary>
        /// Pašalina gyvatės uodegos koordinatęs.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        void RemoveSnakeCoordinate(Vector3 coord);

        void SetBugCoord(Vector2 bugCoord);

        void RemoveBugCoord(Vector2 bugCoord);

        void SetBarrierCoord(Vector3 coord);
    }
}
