using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Game.ServiceContracts
{
    public interface IPlayerService
    {
        /// <summary>
        /// Pridedami žaidejo taškai prie turimų
        /// </summary>
        /// <param name="point"></param>
        void AddPoint(int point);

        /// <summary>
        /// Gražinamos žaidėjo turimos gyvybės
        /// </summary>
        /// <returns></returns>
        int GetLive();

        void DecreseLive();

        /// <summary>
        /// Gražinami surinkti taškai
        /// </summary>
        /// <returns></returns>
        int GetPoints();
    }
}
