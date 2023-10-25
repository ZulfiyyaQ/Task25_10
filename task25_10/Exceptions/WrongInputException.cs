using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task25_10.Exceptions
{
    internal class WrongInputException:Exception
    {
        private const string _message = "Duzgun deyer daxil edin";
        public WrongInputException(string message = _message) : base(message)
        {

        }
    }
}
