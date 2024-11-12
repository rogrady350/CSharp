using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Part 2: Generic Garage
namespace Lab8_Generic_Garage
{
    //1. Generic garage class. T is type parameter representing vehicle stored
    internal class GenericGarage<T> where T : Vehicle
    {
        //2. Internal storage. List to store vehicles
        List<T> vehicles = new List<T>();

        //3. Garage methods
        //Add vehicle of type T
        public void AddVehicle(T vehicle)
        {
            try
            {
               if (vehicles.Contains(vehicle))   //check if vehicle already in garage
                {
                    Console.WriteLine($"{vehicle.Make} {vehicle.Model} is already in your garage\n");
                    return;
                }

                if (vehicle == null)   //check if no details were entered
                {
                    throw new ArgumentNullException($"No {vehicle.GetType().Name} details entered");
                }

                vehicles.Add(vehicle); //add vehicle to garage
            }
            catch (ArgumentException)  //catch invalid type of details entered
            {
                Console.WriteLine($"Invalid {vehicle.GetType().Name} details");
            }

        }

        public void RemoveVehicle(string make, string model) 
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine($"Your garage is empty. {make} {model} not in garage\n");
                return;
            }

            foreach (T vehicle in vehicles)
            {
                //Remove vehicle based on make and model
                if (vehicle.Make == make && vehicle.Model == model)
                {
                    vehicles.Remove(vehicle);
                    Console.WriteLine($"{make} {model} removed\n");
                    return;
                } 
            }

            Console.WriteLine($"{make} {model} not in garage\n");
        }

        //Display list of vehicles currently in garage
        public void DisplayVehicles()
        {
            Console.WriteLine("-=Vehicles in garage=-");
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
            Console.WriteLine();
        }
    }
}
