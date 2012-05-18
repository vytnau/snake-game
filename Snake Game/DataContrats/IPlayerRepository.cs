using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel;

namespace DataContrats
{

    public interface IPlayerRepository : IDisposable
    {
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Entity by id.</returns>
        PlayerStat GetById(int id);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save(PlayerStat entity);

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Remove(PlayerStat entity);

        /// <summary>
        /// Alls the query.
        /// </summary>
        /// <returns>Query to get all entities</returns>
        IQueryable<PlayerStat> AllQuery();
    }

}





