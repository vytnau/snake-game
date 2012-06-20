using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;

namespace Snake_Game.ServiceContracts.DataBaseInterface
{
    public interface IHighScores
    {
        bool NewRecord(PlayerStat player);

        IList<PlayerStat> GetHighScores(String gameType);

        void SaveHighScores(PlayerStat player);

        void Dispose();
    }
}
