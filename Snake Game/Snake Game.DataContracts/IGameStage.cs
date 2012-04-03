using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game.DataContracts
{
    public interface IGameStage<T>
    {
        /// <summary>
        /// Gražina žaidimo lauko masyvą.
        /// </summary>
        /// <returns></returns>
        LinkedList<T> GetStageCoord();

        /// <summary>
        /// Įrašo gyvatės maistą.
        /// </summary>
        void SetSnakeFood();

        /// <summary>
        /// Įrašoma gyvatės koordinatė į žaidimo lauko
        /// masyvą.
        /// </summary>
        /// <param name="x"></param>
        void SetSnakeCoordinates(int x, int y);

        /// <summary>
        /// Pašalina gyvatės uodegos koordinatęs.
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        void RemoveSnakeCoordinate(int x, int y);

    }
}
