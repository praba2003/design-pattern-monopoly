using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    // We create a class Square
    public class Square
    {
        #region Attributs and accessors
        // Attributs & accessors
        public int square_index { get; set; }
        public Square square_next { get; set; }
        #endregion


        #region Constructors
        // Constructor
        public Square(int square_index)
        {
            this.square_index = square_index;
            this.square_next = null;
        }
        public Square(int square_index, Square square_next)
        {
            this.square_index = square_index;
            this.square_next = square_next;
        }
        public Square()
        {
            this.square_index = 0;
            this.square_next = null;
        }
        #endregion


        #region Method - Display the parameters of the square
        // Method ToString()
        public override string ToString()
        {
            return "square number: " + square_index;
        }
        #endregion


    }
}
