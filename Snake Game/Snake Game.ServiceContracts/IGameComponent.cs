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
        void AddItem(Vector3 coord);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Vector3 GetCoord();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coord"></param>
        void RemoveItem(Vector3 coord);

        int Size();

        void NextItem();

        void FirstItem();

        LinkedList<Vector3> GetList();

        LinkedList<Vector2> GetVector2List();

    }
}
