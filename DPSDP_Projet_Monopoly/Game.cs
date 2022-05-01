using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    // We create a Game class 
    public class Game
    {

        #region Attributs and accesors
        // Attributs & accessors
        public Board game_board { get; set; }
        public List<Player> game_players { get; set; }
        public Player game_winner { get; set; }
        #endregion


        #region Constructors
        // Constructor
        public Game(Board game_board, List<Player> game_players)
        {
            // At the beginning of the game
            this.game_board = game_board;
            this.game_players = game_players;
            // There is no winner
            this.game_winner = null;
        }

        public Game(Board game_board)
        {
            // At the beginning of the game
            this.game_board = game_board;
            this.game_players = new List<Player>();
            // There is no winner
            this.game_winner = null;
        }

        public Game()
        {
            // At the beginning of the game
            this.game_board = createGameBoard();
            this.game_players = new List<Player>();
            // There is no winner
            this.game_winner = null;
        }
        #endregion


        #region Method - Create a game board
        public Board createGameBoard()
        {
            Board game_board_ = new Board();

            game_board_.addProperty(0, "Old Kent Road", 100);
            game_board_.addProperty(1, "Whitechapel Road", 125);
            game_board_.addProperty(2, "Kings Cross Station", 150);
            game_board_.addProperty(3, "The Angel Station", 175);
            game_board_.addChance(4);
            game_board_.addProperty(5, "Pentonville Road", 200);
            game_board_.addProperty(6, "Pall Mall", 225);
            game_board_.addProperty(7, "Whitehall", 250);
            game_board_.addProperty(8, "Northumberl'd Avenue", 275);
            game_board_.addProperty(9, "Marylebone Station", 300);

            game_board_.addJail(10, "Visit Jail");
            game_board_.addProperty(11, "Bow Street", 325);
            game_board_.addProperty(12, "Marlborough", 350);
            game_board_.addProperty(13, "Vine Street", 375);
            game_board_.addCommunityChest(14);
            game_board_.addProperty(15, "Fleet Street", 400);
            game_board_.addProperty(16, "Trafalgar Square", 425);
            game_board_.addProperty(17, "Fenchurch St Station", 450);
            game_board_.addChance(18);
            game_board_.addProperty(19, "Coventry Street", 475);

            game_board_.addProperty(20, "Picadilly", 500);
            game_board_.addProperty(21, "Regent Street", 525);
            game_board_.addProperty(22, "Oxford street", 550);
            game_board_.addProperty(23, "Bond Street", 575);
            game_board_.addProperty(24, "Liverpool St Station", 600);
            game_board_.addChance(25);
            game_board_.addProperty(26, "Time Square", 625);
            game_board_.addProperty(27, "Mayfair", 650);
            game_board_.addProperty(28, "Watts Holiday Parks", 675);
            game_board_.addProperty(29, "Nagambie Lake Parks", 700);

            game_board_.addJail(30, "Go to Jail");
            game_board_.addChance(31);
            game_board_.addProperty(32, "Virginia Avenue", 725);
            game_board_.addProperty(33, "Park Lane", 750);
            game_board_.addProperty(34, "Vermont Avenue", 775);
            game_board_.addProperty(35, "St James Place", 800);
            game_board_.addProperty(36, "Leicester Square", 825);
            game_board_.addCommunityChest(37);
            game_board_.addProperty(38, "St Charles Avenue", 850);
            game_board_.addProperty(39, "States Avenue", 875);

            return game_board_;
        }
        #endregion


        #region Method - Display the parameters of the square where the player is 
        public void printPlayerSquare(int player_position)
        {
            // We initialize a counter
            int cpt = 0;
            // We create duplicate the board head square 
            Square board_head_bis = new Square(this.game_board.board_head.square_index, this.game_board.board_head.square_next);

            // We go through the circular list
            while (board_head_bis != null && this.game_board.board_tail != board_head_bis)
            {
                // if the counter is equal to the player's position
                if (cpt == player_position)
                {
                    // We display the square
                    Console.WriteLine("\n" + board_head_bis);
                }
                cpt++;
                board_head_bis = board_head_bis.square_next;
            }

        }
        #endregion


        #region Method - Move the player on the board
        public void Move(int number, Player p)
        {
            if (p.player_position.square_index + number < 40)
            {
                p.player_position.square_index += number;
            }
            else
            {
                p.player_position.square_index = p.player_position.square_index + number - 40;
                p.player_money += 200;
            }

            // We initialize a counter
            int cpt = 0;
            // We create duplicate the board head square 
            Square board_head_bis = new Square(this.game_board.board_head.square_index, this.game_board.board_head.square_next);

            // We go through the circular list
            while (board_head_bis != null && this.game_board.board_tail != board_head_bis)
            {
                // if the counter is equal to the player's position
                if (cpt == p.player_position.square_index)
                {
                    // We display the square
                    Console.WriteLine("\n" + board_head_bis);
                    p.player_position = board_head_bis;
                }
                cpt++;
                board_head_bis = board_head_bis.square_next;
            }
        }
        #endregion


        #region Method - Move the player on a particular square on the board
        // This method is useful for the chancer and community chest cards
        public void MoveChance(int index, Player p)
        {
            if (p.player_position.square_index < index)
            {
                p.player_position.square_index = index;
            }
            else
            {
                p.player_position.square_index = index;
                p.player_money += 200;
            }

            // We initialize a counter
            int cpt = 0;
            // We create duplicate the board head square 
            Square board_head_bis = new Square(this.game_board.board_head.square_index, this.game_board.board_head.square_next);

            // We go through the circular list
            while (board_head_bis != null && this.game_board.board_tail != board_head_bis)
            {
                // if the counter is equal to the player's position
                if (cpt == p.player_position.square_index)
                {
                    // We display the square
                    Console.WriteLine("\n" + board_head_bis);
                    p.player_position = board_head_bis;
                }
                cpt++;
                board_head_bis = board_head_bis.square_next;
            }
        }
        #endregion


        #region Method - Add players on the game
        public void AddPlayers()
        {
            Console.WriteLine("Welcome !");
            int nb_players = 0;
            while (nb_players < 2 || nb_players > 6)
            {
                Console.WriteLine("How many players (2-6)?");
                nb_players = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < nb_players; i++)
            {
                Console.WriteLine("Player " + (i + 1) + ":");
                Console.Write("Username: ");
                string name = Console.ReadLine();
                Player pl = new Player(name);
                game_players.Add(pl);
                Console.WriteLine("\nThe player was successfully added!\n");
            }

            /*Console.WriteLine("\nPlayers:");
            for (int i = 0; i < nbpl; i++)
            {
                Console.WriteLine("\n" + game_players[i].toString());
            }*/

            //Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nPress any key to start the game !\n");
            //Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey(true);
        }
        #endregion


        // Initialy this method was integrated in the method Start()
        // But we saw that we have to use this code again in the method Start() if the player throw dices which have the same values
        // To simplify, we've decide to integrate the ability to buy, sell and pay taxes in a separate method
        #region Method - Allow the player to make an action (buy, sell or pay taxes)
        public void makeAction(Player player)
        {
            if (player.player_position.square_index != 10 && player.player_position.square_index != 30
                        && player.player_position.square_index != 4 && player.player_position.square_index != 18
                        && player.player_position.square_index != 25 && player.player_position.square_index != 31
                        && player.player_position.square_index != 14 && player.player_position.square_index != 37)
            {

                Property property = (Property)player.player_position;

                if (property.property_bought == false)
                {
                    Console.WriteLine("You currently have " + player.player_money + " $");
                    Console.Write("Do you want to buy the property ? T/F ");
                    string buy = Console.ReadLine();

                    // If the player want to buy the house
                    if (buy == "T")
                    {

                        // If the player hasn't got enough money to buy the property
                        if (player.player_money < property.property_buyingCost)
                        {
                            // We display this message
                            Console.WriteLine("Sorry, you can't buy this property! You don't have enough money!");
                        }
                        // If the player has enough money to buy the property
                        else
                        {
                            player.Buy(property);
                            Console.WriteLine("Congratulations! You bought the property " + property.property_name);
                            Console.WriteLine("This is your " + player.numberProperties() + " property");
                        }
                    }
                }

                else
                {
                    if (property.property_owner != player)
                    {
                        Console.WriteLine("This property belongs to " + property.property_owner);
                        Console.WriteLine("You need to pay" + property.property_taxes + "$ of taxes");


                        // If the player hasn't got enough money to buy the property
                        while (player.player_money < property.property_taxes && player.numberProperties() >= 1)
                        {
                            // We display this message
                            Console.WriteLine("Sorry, you can't buy this property! You don't have enough money!");
                            player.displayProperties();
                            Console.Write("Which one to you want to sell ? Write down the index ");
                            int idx = int.Parse(Console.ReadLine());

                            player.Sell(idx);
                        }

                        // If a the end of the while, the player has enough money to pay the taxes he can continue the game
                        if (player.player_money >= property.property_taxes)
                        {
                            player.payTaxes(property);
                            Console.WriteLine("You successfully paid the taxes!");
                            Console.WriteLine("And you currently have " + player.player_money + " $");
                        }

                        // But if the player hasn't got enough money to pay taxe, he has lost the game
                        // He cannot play anymore
                        else
                        {
                            Console.WriteLine("Sorry, you are bankrupt ! You lost the game !");
                            // We change the attribut hasLost in true
                            player.player_HasLost = true;
                        }
                    }
                }
            }
        }
        #endregion


        #region Method - Start a Monopoly game
        public void Start()
        {

            #region Beginning of the game
            int compt = 0;
            Console.Clear();
            Console.WriteLine("The game is starting!");

            /*while (!IsWinner())
            {
                Console.Clear();
                rounds++;
                while (players[compt].loser)
                {
                    if (compt == players.Count - 1)
                    {
                        compt = 0;
                    }
                    else
                    {
                        compt++;
                    }
                }
            }*/
            #endregion

            while (this.gameOver() == false)
            {
                Player current = game_players[compt];
                Console.WriteLine("\nPlayer " + current.player_name + ":");
                Console.WriteLine("\nPress any key to roll the dices !\n");
                Console.ReadKey(true);

                // If the player has no money, before throwing dices
                // He need to sell some of his properties
                while (current.player_money < 0 && current.numberProperties() >= 1)
                {

                    // We display this message
                    Console.WriteLine("You don't have enough money!");
                    current.displayProperties();
                    Console.Write("Which one to you want to sell ? Write down the index ");
                    int idx = int.Parse(Console.ReadLine());

                    current.Sell(idx);
                }

                // If at the end of the while, he still have no money he lost the game
                if (current.player_money < 0)
                {
                    Console.WriteLine("Sorry, you are bankrupt ! You lost the game !");
                    current.player_HasLost = true;
                }

                // The current player make a move only when the attribut player_hasLost is false
                if (current.player_HasLost == false)
                {
                    int[] dices = current.RollDices();
                    int nbdouble = 0;
                    this.Move(dices[0] + dices[1], current);
                    //this.printPlayerSquare(current.player_position.square_index);
                    //Console.ReadKey(true);


                    #region Part that offers to the player the possibility to make an action (buy, sell or pay taxes)
                    makeAction(current);
                    #endregion


                    #region Part useful when the player has a chance card
                    if (current.player_position.square_index == 4 || current.player_position.square_index == 18
                        || current.player_position.square_index == 25 || current.player_position.square_index == 31)
                    {
                        Console.WriteLine("Chance Card !");
                        MyCardFactory cf = new MyCardFactory();
                        Chance c = (Chance)cf.createCard(CardType.Chance);
                        c.number_message = c.RandomInt();
                        ChanceSquare(c, current);
                    }
                    #endregion


                    #region Part useful when the player has a community chest card
                    if (current.player_position.square_index == 14 || current.player_position.square_index == 37)
                    {
                        Console.WriteLine("Community Chest Card !");
                        MyCardFactory cf = new MyCardFactory();
                        CommunityChest c = (CommunityChest)cf.createCard(CardType.CommunityChest);
                        c.number_message = c.RandomInt();
                        CommunityChestSquare(c, current);
                    }
                    #endregion


                    #region Part that offers to the player the possibily to roll again the dices 
                    //DisplayMenu(current, compt, true);
                    while (current.DoubleBool(dices))
                    {
                        nbdouble++;

                        if (nbdouble == 3)
                        {
                            Console.WriteLine("You rolled a double for the third time in a row. You must go to jail.");
                            current.player_inJail = true;
                            current.player_position.square_index = 10;
                            Console.WriteLine("You are now in jail.\n");
                            Console.ReadKey(true);

                            break;
                        }

                        else
                        {
                            Console.WriteLine("\nWow, you got a double, you can roll the dices again !");
                            Console.WriteLine("\nPress any key to roll the dices !\n");
                            Console.ReadKey(true);
                            dices = current.RollDices();
                            this.Move(dices[0] + dices[1], current);
                            //  Offers to the player the possibility to make an action (buy, sell or pay taxes)
                            makeAction(current);
                        }

                        //Console.WriteLine("\nCurrent position :" + current.player_position + "\n");
                        //Console.ReadKey(true);
                        //DisplayMenu(current, compt, true);
                    }
                    #endregion

                }

                #region Part that permit to go to the next player
                if (compt == game_players.Count - 1)
                {
                    compt = 0;

                    // If the player has lost, we go to the next player
                    if (game_players[compt].player_HasLost == true)
                    {
                        compt++;
                    }
                }

                else
                {
                    compt++;

                    // If the player has lost, we go to the next player
                    if (game_players[compt].player_HasLost == true)
                    {
                        compt++;
                    }
                }
                #endregion

            }

            if (this.gameOver() == true)
            {
                Console.WriteLine("Congratulations " + displayWinner() + "! You won the game");
            }

        }
        #endregion


        #region Method - Determine if the game is over
        /* 
         * REGLE DU JEU
         * Le premier joueur à déclarer faillite se retire de la partie comme au jeu régulier.
         * Toutefois, la PARTIE FINIT lors de la seconde faillite.
         * Le jeu cesse immédiatement, et le joueur en faillite remet au créancier tout ce qu’il possède,
         * même les édifices ou autres propriétés, peu importe que le créancier soit un rival ou la banque.
         * Les autres joueurs font alors l’estimé de ses biens
         * 
        */

        public bool gameOver()
        {
            // We initialize a counter
            int cpt = 0;
            // We initialize a boolean
            bool gameOver = false;

            // We go through the game_players list in order to determine the number of players who have lost the game
            for (int i = 0; i < this.game_players.Count; i++)
            {
                if (this.game_players[i].player_HasLost)
                {
                    cpt++;
                }
            }

            // If at the beginning, the game has only two players
            if (this.game_players.Count == 2)
            {
                // The game is over, when one of them has lost
                if (cpt == 1)
                {
                    gameOver = true;
                }
            }
            // If at the beginning, the game has more than two players
            else
            {
                // The game is over, when two of them have lost the game (= are bankrupt)
                if (cpt >= 2)
                {
                    gameOver = true;
                }
            }

            return gameOver;
        }
        #endregion


        #region Method - Display the winner
        public Player displayWinner()
        {
            // We create a new list that will contain all the players who haven't lost the game
            List<Player> players_notLost = new List<Player>();

            for (int i = 0; i < this.game_players.Count; i++)
            {
                players_notLost.Add(this.game_players[i]);
            }

            // We determine the winner thanks to two parameters:
            // - the player_money at the end of the game
            // - the value of properties he has bought 

            // We could also have used the number of properties bought to determine the winner 

            Player player_winner = players_notLost[0];

            for (int j = 0; j < players_notLost.Count; j++)
            {
                int total_money = players_notLost[j].player_money + players_notLost[j].moneyProperties();

                if (total_money > (player_winner.player_money + player_winner.moneyProperties()))
                {
                    player_winner = players_notLost[j];
                }
            }

            return player_winner;
        }
        #endregion


        #region Method - Gives an instruction to a chance card
        public void ChanceSquare(Chance c, Player player)
        {
            Console.Write("The card says:");
            int randomMove = c.RandomMove();
            int randomCash = c.RandomCash();
            Console.WriteLine("'" + c.message(randomMove, randomCash) + "'");
            switch (c.number_message)
            {
                case 1:
                    player.player_money += randomCash;
                    break;


                case 2:
                    this.Move(randomMove, player);
                    break;

                case 3:
                    // "Go to Jail. Go directly to Jail, do not pass Go, do not collect $200";
                    int index_Jail = 10;
                    player.player_position.square_index = index_Jail;
                    break;

                case 4:
                    // "Advance to Marlborough. If you pass Go, collect $200";
                    int index_Marlborough = 12;
                    this.MoveChance(index_Marlborough, player);
                    break;

                case 5:
                    // "Speeding fine! You must pay " + randomCash +  "$";
                    player.player_money -= randomCash;
                    break;

                case 6:
                    // "Advance to Go. If you pass Go, collect $200";
                    this.MoveChance(0, player);
                    break;


                default:
                    throw new CardTypeException("Error");
            }
            //Console.ReadKey(true);
        }

        #endregion


        #region Method - Gives an instruction to a community chest card
        public void CommunityChestSquare(CommunityChest c, Player player)
        {
            Console.Write("The card says:");
            int randomMove = c.RandomMove();
            int randomCash = c.RandomCash();
            Console.WriteLine("'" + c.message(randomMove, randomCash) + "'");
            switch (c.number_message)
            {
                case 1:
                    // Bank error in your favor. Collect $200
                    player.player_money += 200;
                    break;


                case 2:
                    // Doctor’s fee. Pay $50
                    player.player_money -= 50;
                    break;

                case 3:
                    // Go to Jail. Go directly to Jail, do not pass Go, do not collect $200;
                    int index_Jail = 10;
                    player.player_position.square_index = index_Jail;
                    break;

                case 4:
                    // Advance to Go. (Collect $200);
                    this.MoveChance(0, player);
                    break;

                case 5:
                    // From sale of stock you get $50;
                    player.player_money += 50;
                    break;

                case 6:
                    // Holiday fund matures. Receive $100;
                    player.player_money += 100;
                    break;

                case 7:
                    // Income tax refund. Collect $20;
                    player.player_money += 20;
                    break;

                case 8:
                    // Life insurance matures. Collect $100;
                    player.player_money += 100;
                    break;

                case 9:
                    // Pay hospital fees of $100;
                    player.player_money -= 100;
                    break;

                case 10:
                    // Pay school fees of $50;
                    player.player_money -= 50;
                    break;

                case 11:
                    // You have won second prize in a beauty contest. Collect $10;
                    player.player_money += 10;
                    break;

                case 12:
                    // You inherit $100;
                    player.player_money += 10;
                    break;

                default:
                    throw new CardTypeException("Error");
            }
            //Console.ReadKey(true);
        }

        #endregion


        #region Method - Display the game board 
        public override string ToString()
        {
            return this.game_board.ToString();
        }
        #endregion


    }
}

