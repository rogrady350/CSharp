namespace Lab8_Generic_Garage
{
    //Part 3: Testing the Garage
    internal class Program
    {
        //1. Main Method
        static void Main(string[] args)
        {
            //Create instance of GenericGarage
            GenericGarage<Vehicle> myGarage = new GenericGarage<Vehicle>();

            //2. Add 3 vehicles
            myGarage.AddVehicle(new Car("Dodge", "Caliber", "srt4"));
            myGarage.AddVehicle(new Motorcycle("Harley", "Street Glide", 1746));
            myGarage.AddVehicle(new Bicycle("GT", "Performer", "Steel"));

            //Display the garage
            myGarage.DisplayVehicles();

            //3. Remove 1 vehicle by make and model
            myGarage.RemoveVehicle("Dodge", "Caliber");

            //Display vehicles
            myGarage.DisplayVehicles();

            //atempt to add incorrect details
            //myGarage.AddVehicle(new Car("", "", ""));

            myGarage.RemoveVehicle("Chevy", "Suburban");
            myGarage.AddVehicle(new Bicycle("GT", "Performer", "Steel"));

            //remove vehicles to empty garage
            myGarage.RemoveVehicle("Harley", "Street Glide");
            myGarage.RemoveVehicle("GT", "Performer");

            myGarage.RemoveVehicle("GT", "Performer");
            

        }
    }
}
