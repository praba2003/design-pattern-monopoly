using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public abstract class Card : Square
    {
        // Il y aura plusieurs types de cartes chance, ils seront fixés grâce à ce numéro
        // Ce numéro sera généré aléatoirement au moment du jeux
        public int number_message { get; set; }

        protected Card()
        {

        }
        protected Card(int square_index, int number_message) : base(square_index)
        {

        }

        public Card(int square_index) : base(square_index)
        {
        }

        public abstract string message(int randomMove, int randomCash);
    }
}
