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
        public IList<DomainModel.PlayerStat> GetPlayerByName(string name)
        {
            IQueryable<PlayerStat> query = playerRepostiroy.AllQuery();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name == name);
            }

            return query.ToList();
        }

        public void AddPlayerRezult(PlayerStat player)
        {
            playerRepostiroy.Save(player);
        }

        public void RemovePlayerRezultByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument lastName must have value.");
            }

            IQueryable<PlayerStat> query = playerRepostiroy.AllQuery();
            query = query.Where(x => x.Name == name);

            PlayerStat playerToRemove = query.FirstOrDefault();

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
