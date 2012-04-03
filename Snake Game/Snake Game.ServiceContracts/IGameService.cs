using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game.ServiceContracts
{
    public interface IGameService
    {
        /// <summary>
        /// Gražinamas žaidimo lango masyvas.
        /// </summary>
        /// <returns></returns>
        int[,] GetGameStage();

        /// <summary>
        /// Gyvatės valdymo nustatymas
        /// </summary>
        /// <param name="x"></param>
        void SetMovment(int x, int y);

        /// <summary>
        /// Gyvatės pajudėjimas.
        /// </summary>
        void StageUpdate();
    }
}
