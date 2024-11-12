//Lab2

//Declare variables (2)
string vehicleType;
double fuelEfficiency;
double distance;
double time;
int option;   //value for selecting fuel cost or average speed

bool run = true;   //run program until user chooses to exit
do
{
    //Prompt user (3)
    //Ask user for vehicle type
    bool validInput = false;
    do   //valid input check
    {
        Console.WriteLine("Please enter your vehicle type. Select Car, Motorcyle, or Bicycle.");
        vehicleType = Console.ReadLine().ToLower();

        switch (vehicleType)
        {
            case "car":
            case "motorcycle":
            case "bicycle": validInput = true; break;
            default: Console.WriteLine("Invalid Option. Please try again \n"); break;
        }
    } while (!validInput);

    //Prompts for powered vehicles
    if (vehicleType == "car" || vehicleType == "motorcycle")
    {
        //Ask user if they'd like to calculate fuel cost or average speed
        do   //valid input check
        {
            Console.WriteLine("Would you like to calculate fuel cost or average speed? " +
                          "Enter 1 for fuel cost or 2 for average speed.");
            option = int.Parse(Console.ReadLine());

            if (option != 1 && option != 2)
            {
                Console.WriteLine("Please enter only 1 or 2");
                option = int.Parse(Console.ReadLine());
            }
        } while (option != 1 && option != 2);
    }
    else   //Bicycle can only calculate ave speed. Set to option 2.
    {
        option = 2;
    }

    //Calculations (4)
    //distance needed for both cost and ave speed.
    Console.WriteLine("How far did you travel in miles?");
    distance = double.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:   //fuel cost calculation
            {
                double fuelCost = 3.49; //constant determined by current fuel cost
                //Ask for fuel efficiency
                Console.WriteLine("What is your vehicles fuel efficiency in MPG");
                fuelEfficiency = double.Parse(Console.ReadLine());
                double totCost = (distance / fuelEfficiency) * fuelCost;

                //result for fuel cost(5)
                Console.WriteLine($"Your {vehicleType} costs {totCost.ToString("c")} to travel {distance} miles.");
                break;
            }
        case 2:   //average speed calculation
            {
                Console.WriteLine("How long was your trip in minutes?");
                time = double.Parse(Console.ReadLine());
                double aveSpeed = (distance / (time / 60));

                //result for average speed (5)
                Console.WriteLine($"Your average speed was {aveSpeed}");
                break;
            }
    }

    Console.WriteLine("Would you like to perform another calculation?" +
                      "Please enter y if yes or n if no");
    string selection = Console.ReadLine().ToLower();
    /* even though selection is a single character, I decided to make it a string.
     * the aditional complexity of the parse plus the error that would result if a user
     * entered more than 1 letter seemed to outweigh the benefit of useing the simpler data type
    */

    if (selection == "n")
    {
        run = false;
        Environment.Exit(0);
    }

} while (run == true);