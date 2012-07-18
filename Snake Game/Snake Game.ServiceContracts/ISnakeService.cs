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
        void GrowSnake(Vector3 tail);

        /// <summary>
        /// Gyvatės judijėimas.
        /// </summary>
        /// <param name="xy"></param>
        void Move(Vector3 xy);

        /// <summary>
        /// Gražinamos gyvatės koordinačių masyvas.
        /// </summary>
        /// <returns></returns>
        LinkedList<Vector3> GetSnakeCoordinates();

        /// <summary>
        /// Gražinama gyvatės galvos koordinatės.
        /// </summary>
        /// <returns></returns>
        Vector3 GetSnakeHead();

        /// <summary>
        /// Gyvatės uodegos koordinatės.
        /// </summary>
        /// <returns></returns>
        Vector3 GetSnakeTail();

        void SetNewSnake();

        void SetNewSnakeClassic();

        void SetNewSnakeLongSnake();

        void SetNewSnakeInNight();

        void SetNewSnakeAndBugs();

        void SetNewSnakeInBarriers();

        void SetNewSnakeInBarriers1();

        int SnakeLenght();

    }
}
