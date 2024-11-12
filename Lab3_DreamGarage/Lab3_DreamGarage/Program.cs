using System.Xml.Schema;

namespace Lab3_DreamGarage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3 Vehicle instances
            //Car objects
            Car car1 = new Car("Dodge", "Caliber", "Orange", "SRT4", 5);
            Car car2 = new Car("Plymouth", "Laser", "Red", "RS", 3);
            Car car3 = new Car("Pontiac", "Firebird", "White", "Trans Am", 2);
            Car car4 = new Car("Chrysler", "300", "Black", "SRT", 4);
            Car car5 = new Car("Ram", "2500", "Cherry", "Limited", 4);

            //Motorcycle objects
            Motorcycle motorcycle1 = new Motorcycle("Harley", "Streetglide", "Burgandy", 1746);
            Motorcycle motorcycle2 = new Motorcycle("Honda", "CM400", "Grey", 395);

            //Bicycle objects
            Bicycle bicycle1 = new Bicycle("GT", "Performer", "Black", "Steel");
            Bicycle bicycle2 = new Bicycle("Huron", "Hyper", "Titanium", "Aluminum");

            //A few tests for assigned values
            Console.WriteLine($"Car1 Make: {car1.Make}");
            Console.WriteLine($"Car5 trim level: {car5.TrimLevel}");
            Console.WriteLine($"Motorcycle2 engine size: {motorcycle2.EngineSize}");
            Console.WriteLine($"Bicycle1 frame material: {bicycle1.FrameMaterial}");

            //print vehicle counts
            Console.WriteLine($"In my garage is {car5.Count} cars, " +
                $"{motorcycle2.Count} motorcycles, " +
                $"and {bicycle2.Count} bicycles");

            //call sound methods which print each vehicle sound
            car1.makeSound();
            motorcycle1.makeSound();
            bicycle1.makeSound();
        }
    }

    abstract class Vehicle   //1 Define Vehicle class (base class)
    {
        //Vehicle constructor. Attributes had by all vehicle types
        public Vehicle(String make, String model, String color)
        {
            this.Make = make;
            this.Model = model;
            this.Color = color;
        }

        //abstract sound method
        public abstract void makeSound();

        //Vehicle attributes, getters, setters
        private String make;
        public String Make { get { return make; } set { make = value; } }

        private String model;
        public String Model { get { return model; } set { model = value; } }

        private String color;
        public String Color { get { return color; } set { color = value; } }
        
        /*Abstract getter for counting each vehicle. Done for additional practice.
         * Using polymorphism here may be overcomplicating
         * since a simple static count of each instance would have sufficed.
         * But since this is a hw I figured it was good practice.
         */
        public abstract int Count { get; }
    }

    class Car : Vehicle   //2 Car subclass, extends vehicle
    {
        private static int carCount = 0; //counter to keep track of how many cars created

        //Car constructor. Vehicle attributes + car specific attributes
        public Car(String make, String model, String color, String trimLevel, int numDoors):
            base(make, model, color)
        {
            this.trimLevel = trimLevel;
            this.NumDoors = numDoors;

            carCount++;
        }

        //overridden car sound method
        public override void makeSound()
        {
            Console.WriteLine("Car horn: Beep beep");
        }

        //attributes, getters, setters
        private String trimLevel;
        public String TrimLevel { get { return trimLevel; } set { trimLevel = value; } }

        private int numDoors;
        public int NumDoors { get { return numDoors; } set { numDoors = value; } }

        //overridden car count getter
        public override int Count { get { return carCount; } }
    }

    class Motorcycle:Vehicle //2 Motorcycle subclass, extends vehicle
    {
        private static int motorcycleCount = 0;

        //Motorcycle constructor. Vehicle attributes + motorcycle specific attributes
        public Motorcycle(String make, String model, String color, int engineSize) :
            base(make, model, color)
        {
            this.engineSize = engineSize;

            motorcycleCount++;
        }

        //overridden motorcycle sound method
        public override void makeSound()
        {
            Console.WriteLine("Motorcycle engine: Vrrm Vrmm");
        }

        //attributes, getters, setters
        private int engineSize;
        public int EngineSize { get { return engineSize; } set { engineSize = value; } }

        //overridden motorcycle count getter
        public override int Count {  get { return motorcycleCount; } }
    }

    class Bicycle:Vehicle //2 Bicycle subclass, extends vehicle
    {
        private static int bicycleCount = 0;

        //Bicycle constructor. vehicle attributes + bicycle specific attributes
        public Bicycle (String make, String model, String color, String frameMaterial) :
            base(make, model, color)
        {
            this.frameMaterial = frameMaterial;

            bicycleCount++;
        }

        //overridden Bicycle sound method
        public override void makeSound()
        {
            Console.WriteLine("Bicycle bell: Ding Ding");
        }

        //attributes, getters, setters
        private String frameMaterial;
        public String FrameMaterial { get { return frameMaterial; } set { frameMaterial = value; } }

        //overridden bicycle count getter
        public override int Count { get { return bicycleCount; } }
    }
}