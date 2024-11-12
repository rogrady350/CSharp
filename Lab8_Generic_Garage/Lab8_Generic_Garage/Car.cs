using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Generic_Garage
{
    class Car : Vehicle  //Car subclass, extends vehicle
    {
        //Car constructor. Vehicle attributes + car specific attributes
        public Car(String make, String model, String trim) :
            base(make, model)
        {
            if (string.IsNullOrEmpty(trim))
            {
                throw new ArgumentException();
            }

            this.trim = trim;
        }

        //attributes, getters, setters
        private String trim;
        public String Trim { get { return trim; } set { trim = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" {Trim}";
        }

        //Equals
        public override bool Equals(object? obj)
        {
            return obj is Car car &&
                base.Equals(car) &&
                Trim == car.Trim;
                
        }

        //HashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), Trim);
        }
    }
}
