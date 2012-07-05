using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake_Game.ServiceContracts;
using DataContrats;
using Repositories;
using DomainModel;

namespace Snake_Game.Service
{
    public class PlayerStatisticService : IPlayerStatisticService
    {
        private IPlayerRepository playerRepostiroy;
        public PlayerStatisticService()
        {
            playerRepostiroy = new PlayerStatRepository();
        }
        public IList<DomainModel.PlayerStat> GetPlayerByType(string type)
        {
            IQueryable<PlayerStat> query = playerRepostiroy.AllQuery();

            if (!string.IsNullOrEmpty(type))
            {
                query = query.Where(x => x.Type == type);
            }

            return query.ToList();
        }

        public void AddPlayerRezult(PlayerStat player)
        {
            playerRepostiroy.Save(player);
        }

        public void RemovePlayerRezultByID(int id)
        {
            IQueryable<PlayerStat> query = playerRepostiroy.AllQuery();
            query = query.Where(x => x.Id == id);

            PlayerStat playerToRemove = query.First();

            if (playerToRemove != null)
            {
                playerRepostiroy.Remove(playerToRemove);
            }
        }

        public IList<PlayerStat> GetPlayers()
        {
            return playerRepostiroy.AllQuery().ToList<PlayerStat>();
        }

        public void Dispose()
        {
            playerRepostiroy.Dispose();
        }
    }
}
