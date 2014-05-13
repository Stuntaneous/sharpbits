using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharpbits
{

    class Transistor : Component
    {
        // The point at which defines the transistor being in a 'high' state. 
        double threshold;
        
        public Transistor (materialType material, double resistance, double threshold, double current, double voltage, Component previous, Component next) : base(material, resistance, current, voltage, previous, next)
        {
            this.threshold = threshold;
        }

        /// <summary>
        /// Whether or not the passing voltage has been sufficient enough to surpass any specified threshold. 
        /// </summary>
        /// <returns>false, true; 0, 1; LOW, HIGH</returns>
        new public bool state()
        {
            return (voltage >= threshold);
        }

    }

    class Component : IComponent
    {
   
        protected materialType material;

        protected static materialType copper = new materialType("copper", 1);
        protected static materialType tungsten = new materialType("tungsten", 5);

        protected double resistance;

        protected double current;
        protected double voltage;

        protected Component previous;
        protected Component next;
        
        /// <param name="material">E.g. copper, tungsten.</param>
        /// <param name="resistance">Specific to this component, in addition to its material's base resistance.</param>
        /// <param name="current">In amps.</param>
        /// <param name="voltage">In volts.</param>
        public Component (materialType material, double resistance, double current, double voltage, Component previous, Component next)
        {
            this.material = material;
            this.resistance = resistance;
            this.current = current;
            this.voltage = voltage;

            this.previous = previous;
            this.next = next;
        }
        
        public bool state()
        {
            return false;
        }
    }

    interface IComponent
    {        
        bool state();
    }

    struct materialType
    {
        string name;
        double baseResistance;

        /// <param name="baseResistance">The resistance inherent in this material.</param>
        public materialType (string name, double baseResistance)
        {
            this.name = name;
            this.baseResistance = baseResistance;
        }
    }

}
