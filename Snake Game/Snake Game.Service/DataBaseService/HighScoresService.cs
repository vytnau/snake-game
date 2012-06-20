using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts.DataBaseInterface;
using DomainModel;
using Snake_Game.ServiceContracts;

namespace Snake_Game.Service.DataBaseService
{
    public class HighScoresService : IHighScores
    {
        private IPlayerStatisticService database = new PlayerStatisticService();
        public bool NewRecord(DomainModel.PlayerStat player)
        {
            IList<PlayerStat> players = database.GetPlayerByType(player.Type);
            foreach(var a in players){
                if (player.Point > a.Point)
                {
                    return true;
                }
            }
            return false;
        }

        public IList<PlayerStat> GetHighScores(string gameType)
        {
            return database.GetPlayerByType(gameType);
        }

        public void SaveHighScores(DomainModel.PlayerStat player)
        {
            ///ToDo:
            ///parasyt si saugojimo metoda kad iterpinetu ne daugiau nei man reikia, tarkim
            ///top 10 ir i ji kaip nors irasytu
            //IList<PlayerStat> players = database.GetPlayerByType(player.Type);
            database.AddPlayerRezult(player);
        }



        public void Dispose()
        {
            database.Dispose();
        }
    }
}
