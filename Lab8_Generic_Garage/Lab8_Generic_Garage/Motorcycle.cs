using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Generic_Garage
{
    class Motorcycle : Vehicle //Motorcycle subclass, extends vehicle
    {
        //Motorcycle constructor. Vehicle attributes + motorcycle specific attributes
        public Motorcycle(String make, String model, int? engineSize) :
            base(make, model)
        {
            if (engineSize == null || engineSize <= 0)
            {
                throw new ArgumentException();
            }

            this.engineSize = engineSize.Value;
        }

        //attributes, getters, setters
        private int engineSize;
        public int EngineSize { get { return engineSize; } set { engineSize = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" with {EngineSize}cc engine";
        }

        //Equals
        public override bool Equals(object? obj)
        {
            return obj is Motorcycle motorcycle &&
                base.Equals(motorcycle) &&
                EngineSize == motorcycle.engineSize;

        }

        //HashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), EngineSize);
        }
    }
}
