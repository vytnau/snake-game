using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;

namespace Snake_Game.ServiceContracts
{
public interface IPlayerStatisticService: IDisposable
    {
        IList<PlayerStat> GetPlayerByName(string name);

        void AddPlayerRezult(PlayerStat player);

        void RemovePlayerRezultByName(string name);


        IList<PlayerStat> GetPlayers();
    }
}
