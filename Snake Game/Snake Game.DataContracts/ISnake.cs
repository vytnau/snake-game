using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Snake_Game.DataContracts
{
    public interface ISnake
    {
        /// <summary>
        /// Auginama gyvatė.
        /// </summary>
        void GrowSnake();

        /// <summary>
        /// Gyvatės judijėimas.
        /// </summary>
        /// <param name="xy"></param>
        void Move(Vector2 xy);

        /// <summary>
        /// Gražinamos gyvatės koordinačių masyvas.
        /// </summary>
        /// <returns></returns>
        LinkedList<Vector2> GetSnakeCoordinates();


    }
}
