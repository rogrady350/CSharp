using System.Runtime.Serialization.Formatters;
using System.Xml.Serialization;

namespace Lab4_DreamGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //2 Declare List to hold vehicles
            List<Vehicle> dreamGarage = new List<Vehicle>();

            //3 Populate garage with a few vehicles
            //Create vehicle objecs
            Car car1 = new Car(10000, "Dodge", "Caliber", "srt4");
            Motorcycle motorcycle1 = new Motorcycle(20000, 1746);
            Bicycle bicycle1 = new Bicycle(1000, "Steel");

            //default vehicle array
            Vehicle[] defaultVehicles = { car1, motorcycle1, bicycle1 };

            //loop to add vehicles
            foreach (Vehicle vehicle in defaultVehicles)
            {
                dreamGarage.Add(vehicle);
            }

            //4 Garage Manageent
            //Main program user input menu  
            int iChoice = 0;
            do
            {
                Console.WriteLine("-Dream Garage-\n" +
                "\tPlease choose from the following options\n" +
                "\t1. Add a Vehicle\n" +
                "\t2. Remove a Vehicle\n" +
                "\t3. View Garage\n" +
                "\t4. Exit\n" +
                "\nEnter the number for your selection: ");
                iChoice = int.Parse(Console.ReadLine());

                //
                switch(iChoice)
                {
                    case 1:addVehicle(dreamGarage); break;
                    case 2:removeVehicle(dreamGarage); break;
                    case 3:displayVehicles(dreamGarage); break;
                    case 4:Console.WriteLine("Exiting Program. Thank you for your entries."); break;
                    default: Console.WriteLine("Please enter a valid selection\n"); break;
                }

            } while (iChoice != 4);
        }

        //Garage management methods
        //Add a new vehicle
        static void addVehicle(List<Vehicle> dreamGarage)
        {
            int iChoice = 0;

            //Prompt user for type of vehicle to add
            Console.WriteLine("-Add Vehicle-\n" +
                "\t1.Car\n" +
                "\t2.Motorcycle\n" +
                "\t3.Bicycle\n" +
                "\tWhich vehicle did you buy?\n");

            iChoice = int.Parse(Console.ReadLine());

            //select type of vehicle to be added and create object
            Vehicle newVehicle = null;
            switch (iChoice)
            {
                case 1: newVehicle = new Car("","",0,0).newVehicle(); break;
                case 2: newVehicle = new Motorcycle("", "", 0, 0).newVehicle(); break;
                case 3: newVehicle = new Bicycle("", "", 0, "").newVehicle(); break;
                default: Console.WriteLine("Please enter a valid selection"); return;
            }

            //if valid selection ented, add vehicle to garage
            if (newVehicle != null) 
            { 
                dreamGarage.Add(newVehicle);
                Console.WriteLine($"{newVehicle} has been added to the garage\n");
            }  
        }

        //Remove a vehicle
        static void removeVehicle(List<Vehicle> dreamGarage)
        {
            //prompt user for info of vehicle to be removed
            Console.WriteLine("-Sell Vehicle-\n" +
                "Please enter the year, make and model " +
                "of the vehicle you would like to sell.");
            Console.WriteLine("Year:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Make:");
            string make = Console.ReadLine();

            Console.WriteLine("Model:");
            string model = Console.ReadLine();

            int index = -1; //initialize to -1 since no vehicle found yet
            
            /*find index of selected vehicle.
              used StringComparison so the vehicle will be found
              regardless if case matches */
            for (int i = 0; i < dreamGarage.Count; i++)
            {
                Vehicle selectedVehicle = dreamGarage[i];
                if (selectedVehicle.Year == year &&
                        selectedVehicle.Make.Equals(make, StringComparison.OrdinalIgnoreCase) &&
                        selectedVehicle.Model.Equals(model,StringComparison.OrdinalIgnoreCase))
                {
                   index = i; break;
                }
            }

            //remove from garage if found
            if (index != -1)
            {
                dreamGarage.RemoveAt(index);
                Console.WriteLine($"{year} {make} {model} has been sold.\n");
            }
            else
            {
                Console.WriteLine("This vehicle was not found in your garage\n");
            }
        }

        //View garage details
        static void displayVehicles(List<Vehicle> dreamGarage)
        {
            Console.WriteLine("-Your Garage-");

            if (dreamGarage.Count > 0)
            {
                //initialized index to 1 to eliminate need to add 1 inside loop
                int index = 1;
                //display vehicles currently in garage
                dreamGarage.ForEach(vehicle =>
                {
                    Console.WriteLine($"{index}: {vehicle}");
                    index++;
                });
                Console.WriteLine();
            }
            else { Console.WriteLine("Your garage is empty.\n"); }
            
        }
    }
}
