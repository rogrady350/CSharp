using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_DreamGarage
{
    //1 Create Vehicle classes
    abstract class Vehicle   //Vehicle class (base class)
    {
        //Vehicle constructor. Attributes had by all vehicle types
        public Vehicle(String make, String model, int year)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        //methods
        public abstract Vehicle newVehicle();

        //attributes, getters, setters
        private String make;
        public String Make { get { return make; } set { make = value; } }

        private String model;
        public String Model { get { return model; } set { model = value; } }

        private int year;
        public int Year { get { return year; } set { year = value; } }

        //toString
        public override string ToString()
        {
            return $"{Year} {Make} {Model}";
        }
    }
}
