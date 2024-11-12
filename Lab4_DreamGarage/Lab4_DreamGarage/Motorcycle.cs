using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_DreamGarage
{
    class Motorcycle : Vehicle //Motorcycle subclass, extends vehicle
    {
        //Motorcycle constructor. Vehicle attributes + motorcycle specific attributes
        public Motorcycle(String make, String model, int year, int engineSize) :
            base(make, model, year)
        {
            this.engineSize = engineSize;
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

            Console.WriteLine("Enter Engine Size in cc: ");
            int engineSize = int.Parse(Console.ReadLine());

            return new Motorcycle(make, model, year, engineSize);
        }

        //attributes, getters, setters
        private int engineSize;
        public int EngineSize { get { return engineSize; } set { engineSize = value; } }

        //toString
        public override string ToString()
        {
            return base.ToString() + $" with {EngineSize}cc engine";
        }
    }
}
