using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DomainModel
{
    public class PlayerStat : EntityBase
    {
        public virtual string Name { set; get; }
        public virtual int Point { set; get; }
        public virtual string Time { set; get; }
        public virtual string Level { set; get; }
        public virtual string Type { set; get; }
    }
}
