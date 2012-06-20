using FluentNHibernate.Mapping;
using DomainModel;


namespace Snake_Game.Repositories.Mappings
{
    public class PlayerMap : ClassMap<PlayerStat>
    {
        public PlayerMap()
        {
            Table("Classic");
            Id(f => f.Id).Column("Id").GeneratedBy.Increment();
            Map(f => f.Name);
            Map(f => f.Point);
            Map(f => f.Time);
            Map(f => f.Type);
        }
    }
}
