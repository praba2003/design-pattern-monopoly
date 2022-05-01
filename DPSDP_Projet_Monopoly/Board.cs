using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    // We create a class Board
    public class Board
    {
        #region Attributs and accesors
        // Attributs & accessors
        public static Board instance = null;
        public Square board_head { get; set; } // Beginning of the circular list == Liste chainée circulaire
        public Square board_tail { get; set; } // Ending of the circular list

        static readonly object myVarlock = new object();
        #endregion


        #region Constructors
        // Constructors
        public Board(Square board_head, Square board_tail)
        {
            this.board_head = board_head;
            this.board_tail = board_tail;
        }

        public Board()
        {
            this.board_head = null;
            this.board_tail = null;
        }
        #endregion


        #region Method - Calculate the length of the game board = the number of squares on the game board
        public int Length()
        {
            int cpt = 0;
            Square board_head_bis = new Square(board_head.square_index, board_head.square_next);

            while (board_head_bis != null && board_tail != board_head_bis)
            {
                cpt++;
                board_head_bis = board_head_bis.square_next;
            }

            return cpt;
        }
        #endregion


        #region Method - Add a square on the game board
        public void addSquare(int square_index)
        {
            Square square_created = new Square(square_index);


            if (this.board_head == null && this.board_tail == null)
            {
                this.board_head = square_created;
                this.board_tail = square_created;
                square_created.square_next = square_created;
            }
            else
            {
                square_created.square_next = this.board_head;
                this.board_tail.square_next = square_created;
                this.board_tail = square_created;
            }
        }
        #endregion


        #region Method - Singleton Pattern
        // Singleton Pattern, pour n'avoir qu'un seul plateau (le valock sert à ce qu'un seul thread crée le plateau)
        public static Board Instance
        {
            get
            {
                lock (myVarlock)
                {
                    if (instance == null)
                    {
                        instance = new Board();
                    }
                    return instance;
                }
            }
        }
        #endregion


        #region Method - Add a property on the game board
        public void addProperty(int square_index, string property_name, int property_cost)
        {
            Property property_created = new Property(square_index, property_name, property_cost);

            if (this.board_head == null && this.board_tail == null)
            {
                this.board_head = property_created;
                this.board_tail = property_created;
                property_created.square_next = property_created;
            }
            else
            {
                property_created.square_next = this.board_head;
                this.board_tail.square_next = property_created;
                this.board_tail = property_created;
            }
        }
        #endregion


        #region Method - Add a jail on the game board
        public void addJail(int square_index, string jail_name)
        {
            Jail jail_created = new Jail(square_index, jail_name);

            if (this.board_head == null && this.board_tail == null)
            {
                this.board_head = jail_created;
                this.board_tail = jail_created;
                jail_created.square_next = jail_created;
            }
            else
            {
                jail_created.square_next = this.board_head;
                this.board_tail.square_next = jail_created;
                this.board_tail = jail_created;
            }
        }
        #endregion


        #region Method - Add a chance square on the game board
        public void addChance(int square_index)
        {
            MyCardFactory cf = new MyCardFactory();
            Chance chance_created = (Chance)cf.createCard(CardType.Chance);
            chance_created.square_index = square_index;

            if (this.board_head == null && this.board_tail == null)
            {
                this.board_head = chance_created;
                this.board_tail = chance_created;
                chance_created.square_next = chance_created;
            }
            else
            {
                chance_created.square_next = this.board_head;
                this.board_tail.square_next = chance_created;
                this.board_tail = chance_created;
            }
        }
        #endregion


        #region Method - Add a community chest square on the game board
        public void addCommunityChest(int square_index)
        {
            MyCardFactory cf = new MyCardFactory();
            CommunityChest communityChest_created = (CommunityChest)cf.createCard(CardType.CommunityChest);
            communityChest_created.square_index = square_index;

            if (this.board_head == null && this.board_tail == null)
            {
                this.board_head = communityChest_created;
                this.board_tail = communityChest_created;
                communityChest_created.square_next = communityChest_created;
            }
            else
            {
                communityChest_created.square_next = this.board_head;
                this.board_tail.square_next = communityChest_created;
                this.board_tail = communityChest_created;
            }
        }
        #endregion


        #region Method - Display the entire game board
        public override string ToString()
        {
            string sentence = "";
            Square t = this.board_head;
            int length = 40;

            for (int i = 0; i < length; i++)
            {
                sentence = sentence + '\n' + t;
                t = t.square_next;
            }

            return sentence;
        }
        #endregion


    }
}
