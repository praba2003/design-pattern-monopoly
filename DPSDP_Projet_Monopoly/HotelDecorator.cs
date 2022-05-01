using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class HotelDecorator : PropertyDecorator
    {
        public HotelDecorator(Property decoratedProperty) : base(decoratedProperty)
        {
            decoratedProperty.property_nb_houses = 0;
            decoratedProperty.property_has_hotel = true;
        }
    }
}
