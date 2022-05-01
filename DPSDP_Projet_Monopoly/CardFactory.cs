using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public enum CardType { Chance, CommunityChest };
    public abstract class CardFactory
    {
        public abstract Card createCard(CardType type);
    }
}
