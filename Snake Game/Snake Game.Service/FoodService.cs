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
        private LinkedList<Vector2> coord = new LinkedList<Vector2>();
        private int i = 0;

        public void AddItem(Vector2 coord)
        {
            this.coord.AddLast(coord);
        }

        public Vector2 GetCoord()
        {
            return coord.ElementAt(i);
        }

        public void RemoveItem(Vector2 coord)
        {
            this.coord.Remove(coord);
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

        public LinkedList<Vector2> GetList()
        {
            return coord;
        }
    }
}
