using FluentNHibernate.Mapping;
using DomainModel;


namespace Snake_Game.Repositories.Mappings
{
    public class PlayerMap : ClassMap<PlayerStat>
    {
        public PlayerMap()
        {
            Table("Classic");
            Id(f => f.Id).GeneratedBy.Identity();
            Map(f => f.Name);
            Map(f => f.Point);
            Map(f => f.Time);
            Map(f => f.Level);
            Map(f => f.Type);
        }
    }
}
