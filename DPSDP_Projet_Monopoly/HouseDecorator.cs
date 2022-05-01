using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public class HouseDecorator : PropertyDecorator
    {
        public HouseDecorator(Property decoratedProperty) : base(decoratedProperty)
        {
            decoratedProperty.property_nb_houses += 1;
        }
    }
}
