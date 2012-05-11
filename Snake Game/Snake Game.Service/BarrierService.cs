using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts;
using Microsoft.Xna.Framework;

namespace Snake_Game.Service
{
    class BarrierService : IGameComponent
    {
        private LinkedList<Vector3> list;
        // ToDo: kliutys yra nuo 20 iki 24 imtinai
        // klase nebaigta

        public void AddItem(Vector3 coord)
        {
            throw new NotImplementedException();
        }

        public Vector3 GetCoord()
        {
            throw new NotImplementedException();
        }

        public void RemoveItem(Vector3 coord)
        {
            throw new NotImplementedException();
        }

        public int Size()
        {
            throw new NotImplementedException();
        }

        public void NextItem()
        {
            throw new NotImplementedException();
        }

        public void FirstItem()
        {
            throw new NotImplementedException();
        }

        public LinkedList<Vector3> GetList()
        {
            throw new NotImplementedException();
        }

        public LinkedList<Vector2> GetVector2List()
        {
            throw new NotImplementedException();
        }
    }
}
