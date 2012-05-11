using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    class FoodService : IGameComponent
    {
        private LinkedList<Vector3> coord = new LinkedList<Vector3>();
        private int i = 0;

        public void AddItem(Vector3 coord)
        {
            this.coord.AddLast(coord);
        }

        public Vector3 GetCoord()
        {
            return coord.ElementAt(i);
        }

        public void RemoveItem(Vector3 coord)
        {

            this.coord.Remove(new Vector3(coord.X, coord.Y, 2));
            this.coord.Remove(new Vector3(coord.X, coord.Y, 1));
        }

        public int Size()
        {
            return coord.Count;
        }

        public void NextItem()
        {
            if (i < coord.Count)
            {
                i++;
            }
        }

        public void FirstItem()
        {
            i = 0;
        }

        public LinkedList<Vector3> GetList()
        {
            return coord;
        }

        public LinkedList<Vector2> GetVector2List()
        {
            LinkedList<Vector2> list = new LinkedList<Vector2>();
            foreach (var a in coord)
            {
                list.AddLast(new Vector2(a.X, a.Y));
            }
            return list;
        }
    }
}
