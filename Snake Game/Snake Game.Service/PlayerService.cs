using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service
{
    class PlayerService : IPlayerService
    {
        private int points;
        private int lives;

 

        public PlayerService()
        {
            points = 0;
            lives = 3;
        }

        public void AddPoint(int points)
        {
            this.points += points;
        }

        public int GetLive()
        {
            return lives;
        }

        public int GetPoints()
        {
            return points;
        }



        public void DecreseLive()
        {
            if (lives > 0)
            {
                lives--;
            }
        }
    }
}
