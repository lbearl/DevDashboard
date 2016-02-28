using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBoard.Core.Exceptions
{
    public class ApplicationConfigurationException : Exception
    {
        public ApplicationConfigurationException()
        {
        }

        public ApplicationConfigurationException(string message)
        {
            
        }

        public ApplicationConfigurationException(string message, Exception inner)
        {
        }
    }
}
