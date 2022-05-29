using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Core.Domain
{
    public class Game 
        : BaseEntity
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public virtual Developer? Developer { get; set; }

        public virtual List<Genre>? Genres { get; set; }
    }
}
