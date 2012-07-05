using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;

namespace Snake_Game.ServiceContracts
{
public interface IPlayerStatisticService: IDisposable
    {
        IList<PlayerStat> GetPlayerByType(string type);

        void AddPlayerRezult(PlayerStat player);

        void RemovePlayerRezultByID(int id);


        IList<PlayerStat> GetPlayers();
    }
}
