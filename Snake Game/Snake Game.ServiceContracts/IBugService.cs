using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Snake_Game.ServiceContracts
{
    public interface IBugService
    {
        /// <summary>
        /// nustatoma vabalo judejimo kryptis
        /// </summary>
        /// <param name="snakeHead"></param>
        void SetDirection(Vector2 snakeHead);

        /// <summary>
        /// Grazinama vabalo koordintaes
        /// </summary>
        /// <returns>vabalo naujas koordinates</returns>
        Vector2 GetCoord();
        
        void Move();


    }
}
