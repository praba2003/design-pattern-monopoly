using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    class Jail : Square
    {
        #region Attributs and accessors
        // Attributs & accessors
        public string jail_name;
        #endregion


        #region Constructor
        // Constructor
        public Jail(int square_index, string jail_name)
            : base(square_index)
        {
            this.jail_name = jail_name;
        }
        #endregion


        #region Method - Display the parameters of the prison
        // Method ToString()
        public override string ToString()
        {
            return "square number: " + square_index + "\n"
                + "jail name: " + jail_name + "\n";
        }
        #endregion


    }
}
