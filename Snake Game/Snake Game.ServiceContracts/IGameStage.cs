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
        void SetSnakeFood(Vector2 coord);

        /// <summary>
        /// Įrašoma gyvatės koordinatė į žaidimo lauko
        /// masyvą.
        /// </summary>
        /// <param name="x"></param>
        void SetSnakeCoordinates(Vector2 coord);

        /// <summary>
        /// Iš žaidimo lango šalinama gyvatės uodega.
        /// </summary>
        /// <param name="coord"></param>
        void RemoveSnkaeTail(Vector2 coord);

        /// <summary>
        /// Pašalina gyvatės uodegos koordinatęs.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        void RemoveSnakeCoordinate(Vector2 coord);

        void SetBugCoord(Vector2 bugCoord);

        void RemoveBugCoord(Vector2 bugCoord);
    }
}
