using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesInfo.Core.Exceptions
{
    public class EmptyGuidException : Exception
    {
        public EmptyGuidException(string message) 
            : base(message)
        {

        }
    }
}
