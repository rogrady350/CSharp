using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_DreamGarage
{
    class Car : Vehicle  //Car subclass, extends vehicle
    {
        //Car constructor. Vehicle attributes + car specific attributes
        public Car(String make, String model, int year, int numDoors) :
            base(make, model, year)
        {
            this.NumDoors = numDoors;
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
            
            Console.WriteLine("Enter Number of doors: ");
            int numDoors = int.Parse(Console.ReadLine());

            return new Car(make, model, year, numDoors);
        }

        //attributes, getters, setters
        private int numDoors;
        public int NumDoors { get { return numDoors; } set { numDoors = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" with {NumDoors} doors";
        }
    }

    
}
