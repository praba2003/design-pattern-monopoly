using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class Property : Square
    {

        #region Attributs and accessors
        public string property_name { get; set; }
        public int property_buyingCost { get; set; }
        public bool property_bought { get; set; }
        public int property_taxes { get; set; }
        public Player property_owner { get; set; }
        public int property_nb_houses { get; set; }
        public bool property_has_hotel { get; set; }

        #endregion


        #region Constructors
        public Property(int square_index, string property_name, int property_buyingCost)
            : base(square_index)
        {
            this.property_name = property_name;
            this.property_buyingCost = property_buyingCost;
            // At the beginning of the game, the property is not occupied
            this.property_bought = false;
            // If the property is bought by a player in the future, a taxes of 150$ has to be paid by the others 
            this.property_taxes = 150;
            this.property_owner = null;
            this.property_nb_houses = 0;
            this.property_has_hotel = false;
        }

        public Property()
        {

        }
        #endregion


        #region Method - Display the parameter of the property
        public override string ToString()
        {
            return "square number: " + square_index + "\n"
                + "property name: " + property_name + "\n"
                + "property cost: " + property_buyingCost + "\n"
                + "property has been bought: " + property_bought + "\n"
                + "property owner: " + property_owner + "\n";
        }
        #endregion

    }
}
