using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    class CardTypeException : Exception
    {
        public CardTypeException(string _messageException)
        {
            messageException = _messageException;
        }

        private string messageException;
    }
}
