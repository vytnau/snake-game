using System;
using System.Collections.Generic;
using System.Text;
using DataContrats;
using NHibernate;
using Repositories.DataContext;
using DomainModel;
using System.Linq;
using NHibernate.Linq;

namespace Repositories
{
    public class PlayerStatRepository : IPlayerRepository
    {
        private readonly ISession session;

        public PlayerStatRepository(){
            session = SessionFactoryProvider.OpenSession();
        }

        public DomainModel.PlayerStat GetById(int id)
        {
            return session.Get<PlayerStat>(id);
        }

        public void Save(DomainModel.PlayerStat entity)
        {
            session.SaveOrUpdate(entity);
            session.Flush();
        }

        public void Remove(DomainModel.PlayerStat entity)
        {
            session.Delete(entity);
            session.Flush();
        }

        public IQueryable<DomainModel.PlayerStat> AllQuery()
        {
            return session.Query<PlayerStat>();
        }

        public void Dispose()
        {
            session.Close();
            session.Dispose();
        }
    }
}
