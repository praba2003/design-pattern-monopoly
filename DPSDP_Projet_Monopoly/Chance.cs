using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class Chance : Card
    {

        #region Constructors
        // Constuctors
        public Chance()
        {

        }

        public Chance(int square_index) : base(square_index)
        {

        }
        public Chance(int number_message, int square_index) : base(number_message, square_index)
        {
            this.number_message = number_message;
        }
        #endregion

        public override string message(int randomMove, int randomCash)
        {
            {
                return computeMessage(randomMove, randomCash);
            }
        }

        public int RandomMove()
        {
            Random random = new Random();
            int result = random.Next(1, 11);
            return result;
        }

        public int RandomCash()
        {
            Random random = new Random();
            int result = random.Next(10, 1001);
            return result;
        }

        public int RandomInt()
        {
            Random random = new Random();
            int result = random.Next(1, 6);
            return result;
        }


        private string computeMessage(int randomMove, int randomCash)
        {

            switch (this.number_message)
            {
                case 1:
                    return "Receive " + randomCash + "$ from the bank";
                    break;


                case 2:
                    return "Move " + randomMove + " squared forward";
                    break;

                case 3:
                    return "Go to Jail. Go directly to Jail, do not pass Go, do not collect $200";
                    break;

                case 4:
                    return "Advance to Marlborough. If you pass Go, collect $200";
                    break;

                case 5:
                    return "Speeding fine! You must pay " + randomCash + "$";
                    break;

                case 6:
                    return "Advance to Go (Collect $200)";
                    break;


                default:
                    throw new CardTypeException("Error");
            }
        }

        #region Method - Display the square
        public override string ToString()
        {
            return "square number: " + square_index + "\n";
        }
        #endregion


    }
}