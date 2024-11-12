using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8_Generic_Garage
{
    abstract class Vehicle   //Vehicle class (base class)
    {
        //Vehicle constructor. Attributes had by all vehicle types
        public Vehicle(String make, String model)
        {
            if(string.IsNullOrEmpty(make) || string.IsNullOrEmpty(model))
            {
                throw new ArgumentException();
            }

            this.make = make;
            this.model = model;
        }

        //attributes, getters, setters
        private String make;
        public String Make { get { return make; } set { make = value; } }

        private String model;
        public String Model { get { return model; } set { model = value; } }

        //toString
        public override string ToString()
        {
            return $"{Make} {Model}";
        }

        //Equals
        public override bool Equals(object? obj)
        {
            return obj is Vehicle vehicle &&
                Make == vehicle.Make &&
                Model == vehicle.Model;
        }

        //HashCode
        public override int GetHashCode()
        {
            return HashCode.Combine(Make, Model);
        }
    }
}
