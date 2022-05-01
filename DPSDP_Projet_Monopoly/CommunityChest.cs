using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class CommunityChest : Card
    {
        #region Constructors
        // Constuctors
        public CommunityChest()
        {

        }

        public CommunityChest(int square_index) : base(square_index)
        {

        }
        public CommunityChest(int number_message, int square_index) : base(number_message, square_index)
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
                    return "Bank error in your favor. Collect $200";
                    break;


                case 2:
                    return "Doctor’s fee. Pay $50";
                    break;

                case 3:
                    return "Go to Jail. Go directly to Jail, do not pass Go, do not collect $200";
                    break;

                case 4:
                    return "Advance to Go. (Collect $200)";
                    break;

                case 5:
                    return "From sale of stock you get $50";
                    break;

                case 6:
                    return "Holiday fund matures. Receive $100";
                    break;

                case 7:
                    return "Income tax refund. Collect $20";
                    break;

                case 8:
                    return "Life insurance matures. Collect $100";
                    break;

                case 9:
                    return "Pay hospital fees of $100";
                    break;

                case 10:
                    return "Pay school fees of $50";
                    break;

                case 11:
                    return "You have won second prize in a beauty contest. Collect $10";

                case 12:
                    return "You inherit $100";


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