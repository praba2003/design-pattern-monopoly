using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class MyCardFactory : CardFactory
    {
        public override Card createCard(CardType type)
        {
            switch (type)
            {
                case CardType.Chance:
                    return new Chance();
                    break;

                case CardType.CommunityChest:
                    return new CommunityChest();
                    break;


                default:
                    throw new CardTypeException("Cannot create a card of the given type");
            }
        }
    }
}
