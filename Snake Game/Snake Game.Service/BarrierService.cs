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
            for (int j = 0; j < 2; j++)
            {
                list.AddLast(new Vector3(10, j, 20));
                list.AddLast(new Vector3(11, j, 20));
                list.AddLast(new Vector3(10, 11+j, 20));
                list.AddLast(new Vector3(11, 11+j, 20));
            }

            for (int j = 2; j < 11; j++)
                list.AddLast(new Vector3(2, j, 21));

            list.AddLast(new Vector3(5, 4, 24));
            list.AddLast(new Vector3(5, 8, 24));
            list.AddLast(new Vector3(17, 4, 24));
            list.AddLast(new Vector3(17, 8, 24));
            list.AddLast(new Vector3(23, 1, 20));
            list.AddLast(new Vector3(23, 11, 20));

            for (int j = 7; j < 16; j++)
            {
                list.AddLast(new Vector3(j, 8, 21));
                list.AddLast(new Vector3(j, 4, 21));
            }

            for (int j = 0; j < 2; j++)
            {
                list.AddLast(new Vector3(7, 2 +j, 21));
                list.AddLast(new Vector3(7, 8 +j, 21));
                list.AddLast(new Vector3(15, 2 +j, 21));
                list.AddLast(new Vector3(15, 9 + j, 21));
            }

            for (int j = 20; j < 23; j++)
            {
                list.AddLast(new Vector3(j, 5, 23));
                list.AddLast(new Vector3(j, 7, 23));
            }
            list.AddLast(new Vector3(20, 4, 23));
            list.AddLast(new Vector3(20, 8, 23));
        }

        public void SnakeInNight()
        {
            list = new LinkedList<Vector3>();
            for (int j = 2; j < 5; j++)
            {
                list.AddLast(new Vector3(j, 2, 23));
            }
            for (int j = 20; j < 23; j++)
            {
                list.AddLast(new Vector3(j, 2, 23));
            }
            for (int j = 2; j < 5; j++)
            {
                list.AddLast(new Vector3(j, 10, 23));
            }
            for (int j = 20; j < 23; j++)
            {
                list.AddLast(new Vector3(j, 10, 23));
            }
            for (int j = 3; j < 5; j++)
            {
                list.AddLast(new Vector3(2, j, 23));
            }
            for (int j = 3; j < 5; j++)
            {
                list.AddLast(new Vector3(22, j, 23));
            }
            for (int j = 8; j < 11; j++)
            {
                list.AddLast(new Vector3(2, j, 23));
            }
            for (int j = 8; j < 11; j++)
            {
                list.AddLast(new Vector3(22, j, 23));
            }
            for (int j = 10; j < 14; j++)
            {
                list.AddLast(new Vector3(j, 0, 23));
            }
            for (int j = 10; j < 14; j++)
            {
                list.AddLast(new Vector3(j, 12, 23));
            }
            for (int j = 5; j < 8; j++)
            {
                list.AddLast(new Vector3(6, j, 21));
            }
            for (int j = 5; j < 8; j++)
            {
                list.AddLast(new Vector3(18, j, 21));
            }
        }

        public void SnakeAndBugs()
        {
            list = new LinkedList<Vector3>();
            list.AddLast(new Vector3(2, 2, 20));
            list.AddLast(new Vector3(3, 2, 20));
            list.AddLast(new Vector3(2, 3, 20));
            list.AddLast(new Vector3(3, 3, 20));

            list.AddLast(new Vector3(2, 9, 20));
            list.AddLast(new Vector3(3, 9, 20));
            list.AddLast(new Vector3(2, 10, 20));
            list.AddLast(new Vector3(3, 10, 20));

            list.AddLast(new Vector3(21, 2, 20));
            list.AddLast(new Vector3(22, 2, 20));
            list.AddLast(new Vector3(21, 3, 20));
            list.AddLast(new Vector3(22, 3, 20));

            list.AddLast(new Vector3(21, 9, 20));
            list.AddLast(new Vector3(22, 9, 20));
            list.AddLast(new Vector3(21, 10, 20));
            list.AddLast(new Vector3(22, 10, 20));

            list.AddLast(new Vector3(11, 2, 23));
            list.AddLast(new Vector3(12, 2, 23));
            list.AddLast(new Vector3(11, 10, 23));
            list.AddLast(new Vector3(12, 10, 23));
        }

        public void SnakeInBarrier()
        {
            list = new LinkedList<Vector3>();
            for (int i = 1; i < 6; i++)
                list.AddLast(new Vector3(i, 2, 21));
            list.AddLast(new Vector3(5, 3, 21));

            for (int i = 19; i < 24; i++)
                list.AddLast(new Vector3(i, 10, 21));
            list.AddLast(new Vector3(19, 9, 21));

            for (int i = 3; i < 7; i++)
                list.AddLast(new Vector3(1, i, 21));
           
            for (int i = 6; i < 10; i++)
                list.AddLast(new Vector3(23, i, 21));
            
            //akmuo
            list.AddLast(new Vector3(4, 10, 24));
            list.AddLast(new Vector3(20, 2, 24));

            for(int i = 0; i < 5; i++)
                list.AddLast(new Vector3(10+i, 4+i, 23));
        }

        public void SnakeInBarrier1()
        {
            list = new LinkedList<Vector3>();
            //krumai kampuose
            list.AddLast(new Vector3(0, 0, 20));
            list.AddLast(new Vector3(0, 1, 20));
            list.AddLast(new Vector3(1, 0, 20));
            list.AddLast(new Vector3(1, 1, 20));

            list.AddLast(new Vector3(0, 11, 20));
            list.AddLast(new Vector3(0, 12, 20));
            list.AddLast(new Vector3(1, 11, 20));
            list.AddLast(new Vector3(1, 12, 20));

            list.AddLast(new Vector3(23, 0, 20));
            list.AddLast(new Vector3(23, 1, 20));
            list.AddLast(new Vector3(24, 0, 20));
            list.AddLast(new Vector3(24, 1, 20));

            list.AddLast(new Vector3(23, 11, 20));
            list.AddLast(new Vector3(23, 12, 20));
            list.AddLast(new Vector3(24, 11, 20));
            list.AddLast(new Vector3(24, 12, 20));

            //per viduri krumai
            for (int i = 0; i < 4; i++)
            {
                list.AddLast(new Vector3(11, i, 20));
                list.AddLast(new Vector3(12, i, 20));
            }

            for (int i = 9; i < 13; i++)
            {
                list.AddLast(new Vector3(11, i, 20));
                list.AddLast(new Vector3(12, i, 20));
            }

            //C raides
            for (int i = 4; i < 9; i++)
            {
                list.AddLast(new Vector3(4, i, 21));
                list.AddLast(new Vector3(19, i, 21));
            }
            for (int i = 5; i < 9; i++)
            {
                list.AddLast(new Vector3(i, 4, 21));
                list.AddLast(new Vector3(i, 8, 21));
            }
            for (int i = 16; i < 19; i++)
            {
                list.AddLast(new Vector3(i, 4, 21));
                list.AddLast(new Vector3(i, 8, 21));
            }
        }
    }
}
