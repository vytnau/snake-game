using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts;
using Microsoft.Xna.Framework;

namespace Snake_Game.Service
{
    class BarrierService
    {
        private LinkedList<Vector3> list;
        // ToDo: kliutys yra nuo 20 iki 24 imtinai
        // klase nebaigta
        public BarrierService()
        {
            list = new LinkedList<Vector3>();
        }

        public void RemoveItem(Vector3 coord)
        {
            list.Remove(coord);
        }

        public int Size()
        {
            return list.Count();
        }

        public LinkedList<Vector3> GetList()
        {
            return list;
        }

        public LinkedList<Vector2> GetVector2List()
        {
            LinkedList<Vector2> list2 = new LinkedList<Vector2>();
            foreach (Vector3 a in list)
            {
                list2.AddLast(new Vector2(a.X, a.Y));
            }
            return list2;
        }

        public void SurvivalMode()
        {
            list = new LinkedList<Vector3>();
            list.AddLast(new Vector3(17,0, 20));
            list.AddLast(new Vector3(24, 1, 20));
            list.AddLast(new Vector3(4, 5, 21));
            list.AddLast(new Vector3(1, 12, 22));
            for (int j = 4; j < 10; j++)
            {
                list.AddLast(new Vector3(1, j, 23));
            }

            for (int j = 1; j < 9; j++)
            {
                list.AddLast(new Vector3(j, 1, 23));
            }
            for (int i = 15; i < 23; i++)
            {
                list.AddLast(new Vector3(i, 2, 23));
            }
            list.AddLast(new Vector3(5, 5, 22));
            list.AddLast(new Vector3(5, 6, 20));
            list.AddLast(new Vector3(6, 5, 20));
            list.AddLast(new Vector3(6, 6, 22));
            for (int i = 4; i < 7; i++)
            {
                list.AddLast(new Vector3(i, 8, 21));
            }
            for (int i = 3; i < 10; i++)
            {
                list.AddLast(new Vector3(8, i, 20));
            }
            for (int i = 2; i < 10; i++)
            {
                list.AddLast(new Vector3(10, i, 20));
            }
            for (int i = 0; i < 5; i++)
            {
                list.AddLast(new Vector3(12, i, 21));
            }
            for (int i = 15; i < 21; i++)
            {
                list.AddLast(new Vector3(i, 4, 21));
            }
            for (int i = 17; i < 21; i++)
            {
                list.AddLast(new Vector3(i, 5, 23));
            }
            for (int i = 14; i < 21; i++)
            {
                list.AddLast(new Vector3(i, 8, 21));
            }
            for (int i = 16; i < 20; i++)
            {
                list.AddLast(new Vector3(i, 10, 20));
            }
            for (int i = 4; i < 21; i++)
            {
                list.AddLast(new Vector3(i, 12, 23));
            }
            list.AddLast(new Vector3(14, 8, 20));
            list.AddLast(new Vector3(14, 9, 20));
            for (int i = 8; i < 11; i++)
            {
                list.AddLast(new Vector3(22, i, 20));
            }
            //x9
            //y3
            //y10


        }
    }
}
