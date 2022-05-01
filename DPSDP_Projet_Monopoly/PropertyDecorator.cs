using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPSDP_Projet_Monopoly
{
    public abstract class PropertyDecorator
    {
        protected Property decoratedProperty;

        public PropertyDecorator(Property decoratedProperty)
        {
            this.decoratedProperty = decoratedProperty;
        }
    }
}
