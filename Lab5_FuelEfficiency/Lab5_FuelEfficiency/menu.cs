using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_FuelEfficiency
{
    internal class Menu
    {
        public void startMenu()
        {
            //program keeps running until user selects to exit
            bool continueRunning = true;
            while (continueRunning)
            {
                //2. Menu. Prompt user for vehicle type
                Console.WriteLine("-Fuel Efficiency Calculator -");

                string input;

                Console.WriteLine("Select a vehicle Type (enter either number OR vehicle name");
                Console.WriteLine("1 Car");
                Console.WriteLine("2 Motorcycle");
                Console.WriteLine("3 Bicycle");
                Console.WriteLine("Type EXIT to exit");
                input = Console.ReadLine().ToUpper(); //always make capital

                string vehicleType = input;

                //switch statement to handle if user enters the number in front of the option
                switch (input)
                {
                    case "1": vehicleType = "CAR"; break;
                    case "2": vehicleType = "MOTORCYCLE"; break;
                    case "3": vehicleType = "BICYCLE"; break;
                    case "EXIT": Console.WriteLine("Thank you. Program exiting"); 
                                    continueRunning = false;
                                    continue;
                }

                //If exit is entered, do not ask for distance and fuel
                if (!continueRunning) { break; }

                //Prompt user for distance and fuel used
                Console.WriteLine("How far did you travel (in miles)?");
                string distance = Console.ReadLine().ToUpper();
                Console.WriteLine("How much fuel did you use (in gallons)?");
                string fuel = Console.ReadLine().ToUpper();

                //call function to calculate mpg
                double mpg = CalculateMpg(vehicleType, distance, fuel);
                
                //only show result if no exception thrown)
                if (mpg != -1)
                {
                    Console.WriteLine($"The fuel economy of your {vehicleType} is {mpg}");
                }

                Console.WriteLine(""); //space after program runsbi
            }
        }
        //3.Calculate MPG function
        public double CalculateMpg(string vehicleType, string distance, string fuel) 
        {
            //set default mpg to -1 so only will show value if exception not thrown
            double mpg = -1;

            try
            {
                //only calculate for car or motorcycle
                switch (vehicleType)
                {
                    case "CAR":break;
                    case "MOTORCYCLE":break;
                    case "BICYCLE": throw new InvalidVehicleException("Bicycles do not use fuel");
                    default: throw new InvalidVehicleException($"{vehicleType} is not a valid vehicle");
                }

                //convert values for input from string to doubles
                double dDistance = double.Parse(distance);
                double dFuel = double.Parse(fuel);

                //handle divide by 0 case so it throws exception rather than display infinite;
                if (dFuel == 0)
                {
                    throw new DivideByZeroException("Fuel used cannot be zero");
                }

                //calculate mpg
                mpg = dDistance / dFuel;
            }

            //catch exceptions
            //format exception: if user enters non-numeric values for distance or fuel.
            catch (FormatException)
            {
                Console.WriteLine("Exception: Invalid input. Entered values must be numeric");
            }
            //divide 0 exception: if user enters 0 for fuel consumed
            catch (DivideByZeroException ex) 
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            //exception if bicycle or other choice besides car or motorcycle is entered
            catch (InvalidVehicleException ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }

            /* Since C# does not require Console.ReadLine be closed like scanner in java does
             * and there is no database connection, I wasn't sure what resources needed to be released.
             * I just put a simulated statement for where resources would be released and a statement that always runs,
             * stating the completion of the calculation attempt
             */
            finally
            {
                Console.WriteLine("\nCalculation attempt finished.");
                Console.WriteLine("Thank you for using the fuel efficiency calculator!");
                Console.WriteLine("releasing resources");
            }

            //return calculated fuel economy
            return mpg;
        }
    }
}
