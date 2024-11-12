using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Generic_Garage
{
    class Bicycle : Vehicle //Bicycle subclass, extends vehicle
    {
        //Bicycle constructor. vehicle attributes + bicycle specific attributes
        public Bicycle(String make, String model, String frameMaterial) :
            base(make, model)
        {
            if (string.IsNullOrEmpty(frameMaterial))
            {
                throw new ArgumentException();
            }

            this.frameMaterial = frameMaterial;
        }

        //attributes, getters, setters
        private String frameMaterial;
        public String FrameMaterial { get { return frameMaterial; } set { frameMaterial = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" with {FrameMaterial} frame";
        }

        //Equals
        public override bool Equals(object? obj)
        {
            return obj is Bicycle bicycle &&
                base.Equals(bicycle) &&
                FrameMaterial == bicycle.FrameMaterial;

        }

        //HashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), FrameMaterial);
        }
    }
}
