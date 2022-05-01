using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    // We create a class Player
    public class Player
    {

        #region Attributs and accessors
        // Attributs & accessors
        public string player_name { get; set; }
        public Square player_position { get; set; }
        public bool player_inJail { get; set; }
        public bool player_visitJail { get; set; }
        public bool player_HasLost { get; set; }
        public int player_money { get; set; }
        public List<Property> player_properties { get; set; }
        #endregion


        #region Constructors
        // Constructor
        public Player(string player_name, Square sq)
        {
            this.player_name = player_name;

            // In the beginning of the game: 
            // The player's position is 0
            // We know that the 1st square is a property
            this.player_position = sq;
            // The player is not in jail
            this.player_inJail = false;
            // The player is not visiting jail
            this.player_visitJail = false;
            // The player did not lose
            this.player_HasLost = false;
            // If we want to add the option: Buy property
            this.player_money = 1000;
            // At the beginning of the game, the player hasn't buy properties
            this.player_properties = new List<Property>();
        }
        public Player(string player_name)
        {
            this.player_name = player_name;

            // In the beginning of the game: 
            // The player's position is 0
            // We know that the 1st square is a property
            this.player_position = new Property();
            this.player_position.square_index = 0;
            // The player is not in jail
            this.player_inJail = false;
            // The player is not visiting jail
            this.player_visitJail = false;
            // The player did not lose
            this.player_HasLost = false;
            // If we want to add the option: Buy property
            this.player_money = 1000;
            // At the beginning of the game, the player hasn't buy properties
            this.player_properties = new List<Property>();
        }

        public Player()
        {
            this.player_name = null;

            // In the beginning of the game: 
            // The player's position is 0 
            // We know that the 1st square is a property
            this.player_position = new Square();
            this.player_position.square_index = 0;
            // The player is not in jail
            this.player_inJail = false;
            // The player is not visiting jail
            this.player_visitJail = false;
            // The player did not lose
            this.player_HasLost = false;
            // If we want to add the option: Buy property
            this.player_money = 1500;
            // At the beginning of the game, the player hasn't buy properties
            this.player_properties = new List<Property>();
        }
        #endregion


        #region Method - Roll the dices
        public int[] RollDices()
        {
            Random rnd = new Random();

            int v1 = rnd.Next(1, 7);
            int v2 = rnd.Next(1, 7);
            int tot = v1 + v2;

            Console.WriteLine("Dice 1 : " + v1);
            Console.WriteLine("Dice 2 : " + v2);
            Console.WriteLine("Total = " + tot);

            int[] tab = new int[2];
            tab[0] = v1;
            tab[1] = v2;

            return tab;
        }
        #endregion


        #region Method - Determine if the dices have the same value
        public bool DoubleBool(int[] tab)
        {
            if (tab[0] == tab[1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion


        /*public void Move(int number)
        {
            if (this.player_position.square_index + number < 40)
            {
                this.player_position.square_index += number;
            }
            else
            {
                this.player_position.square_index = this.player_position.square_index + number - 40;
                this.player_money += 200;
            }
            // We initialize a counter
            int cpt = 0;
            // We create duplicate the board head square 
            Square board_head_bis = new Square(game_board.board_head.square_index, game_board.board_head.square_next);

            // We go through the circular list
            while (board_head_bis != null && game_board.board_tail != board_head_bis)
            {
                // if the counter is equal to the player's position
                if (cpt == player_position.square_index)
                {
                    // We display the square
                    this.player_position = board_head_bis;
                }
                cpt++;
                board_head_bis = board_head_bis.square_next;
            }
        }*/


        #region Method - Move Backward
        public void MoveBackward(int number)
        {
            if (player_position.square_index - number >= 0)
            {
                player_position.square_index -= number;
            }
            else
            {
                player_position.square_index = 40 + (player_position.square_index - number);
            }
        }
        #endregion


        #region Method - Buy a property
        // Method to give the player the ability to buy a property
        public void Buy(Property property)
        {
            // We assume that the player has enough money to buy the house
            this.player_money -= property.property_buyingCost;
            property.property_bought = true;
            // The player becomes the owner of the property
            property.property_owner = this;
            this.player_properties.Add(property);
        }
        #endregion


        #region Method - Sell a property
        // Method to give the player the ability to sell a property
        public void Sell(int index)
        {
            // If the player decide to sell the property 
            // We put the money back in his account
            this.player_money += this.player_properties[index].property_buyingCost;
            this.player_properties[index].property_bought = false;
            // The player is no more the owner of the house
            this.player_properties[index].property_owner = null;
            this.player_properties.RemoveAt(index);
        }
        #endregion


        #region Method - Pay taxes a property
        // Method to give the player the ability to pay taxes of a property
        public void payTaxes(Property property)
        {
            this.player_money -= property.property_taxes;
            property.property_owner.player_money += property.property_taxes;
        }
        #endregion


        #region Method - Determine the number of properties bought by a player
        public int numberProperties()
        {
            return this.player_properties.Count;
        }
        #endregion


        #region Method - Determine the money generated by the properties
        public int moneyProperties()
        {
            int numberProperties = this.numberProperties();
            int total_moneyProperties = 0;

            for (int i = 0; i < numberProperties; i++)
            {
                total_moneyProperties += player_properties[i].property_buyingCost;
            }

            return total_moneyProperties;
        }
        #endregion


        #region Method - Sell all properties 
        public void sellAllProperties()
        {
            int numberProperties = this.numberProperties();

            for (int indexProperty = 0; indexProperty < numberProperties; indexProperty++)
            {
                Sell(indexProperty);
            }
        }
        #endregion


        #region Method - Display all the properties of the player
        public void displayProperties()
        {
            if (this.player_properties.Count > 0)
            {
                for (int i = 0; i < this.player_properties.Count; i++)
                {
                    //Console.WriteLine(this.player_properties[i]);

                    Console.WriteLine("index : " + i + "\n"
                + "property name: " + player_properties[i].property_name + "\n"
                + "property cost: " + player_properties[i].property_buyingCost + "\n"
                + "property has been bought: " + player_properties[i].property_bought + "\n"
                + "property owner: " + player_properties[i].property_owner + "\n");
                }
            }

            else
            {
                Console.WriteLine("You don't have any properties");
            }
        }
        #endregion


        #region Method - Display the player
        public override string ToString()
        {
            return this.player_name;
        }
        #endregion
    }
}
