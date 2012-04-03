using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Snake_Game.ServiceContracts
{
    public interface IGameComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord"></param>
        void AddItem(Vector2 coord);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Vector2 GetCoord();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord"></param>
        void RemoveItem(Vector2 coord);

        int Size();

        void NextItem();

        void FirstItem();

        LinkedList<Vector2> GetList();

    }
}
