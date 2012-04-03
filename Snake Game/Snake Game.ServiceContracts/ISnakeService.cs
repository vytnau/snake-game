using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Snake_Game.ServiceContracts
{
    public interface ISnakeService
    {
        /// <summary>
        /// Auginama gyvatė.
        /// </summary>
        void GrowSnake(Vector2 tail);

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

        /// <summary>
        /// Gražinama gyvatės galvos koordinatės.
        /// </summary>
        /// <returns></returns>
        Vector2 GetSnakeHead();

        /// <summary>
        /// Gyvatės uodegos koordinatės.
        /// </summary>
        /// <returns></returns>
        Vector2 GetSnakeTail();
    }
}
