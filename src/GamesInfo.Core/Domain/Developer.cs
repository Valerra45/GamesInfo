using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Core.Domain
{
    public class Developer 
        : BaseEntity
    {
        public string? Name { get; set; }

        public virtual List<Game>? Games { get; set; }
    }
}
