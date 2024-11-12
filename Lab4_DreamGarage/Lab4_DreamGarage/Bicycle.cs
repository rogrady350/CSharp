using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6_CarPrice
{
    class Bicycle : Vehicle //Bicycle subclass, extends vehicle
    {
        private static int bicycleCount = 0;

        //Bicycle constructor. vehicle attributes + bicycle specific attributes
        public Bicycle(String make, String model, int year, String frameMaterial) :
            base(make, model, year)
        {
            this.frameMaterial = frameMaterial;
        }

        //methods
        public override Vehicle newVehicle()
        {
            Console.WriteLine("Enter Year: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Make: ");
            string make = Console.ReadLine();

            Console.WriteLine("Enter Model: ");
            string model = Console.ReadLine();

            Console.WriteLine("Enter Frame Material: ");
            string frameMaterial = Console.ReadLine();

            return new Bicycle(make, model, year, frameMaterial);
        }

        //attributes, getters, setters
        private String frameMaterial;
        public String FrameMaterial { get { return frameMaterial; } set { frameMaterial = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" with {FrameMaterial} frame";
        }
    }
}
