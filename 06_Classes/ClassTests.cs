using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Classes
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void VehiclePropertyTests()
        {
            string me = "Amanda";
            string bff = "Katie";
            Vehicle firstVehicle = new Vehicle();
            firstVehicle.Color = "Yellow";
            Console.WriteLine(firstVehicle.Color);
            firstVehicle.Make = "Cadillac";
            firstVehicle.Model = "DTS";
            firstVehicle.Mileage = 7;
            firstVehicle.Year = 2018;
            firstVehicle.TypeOfVehicle = VehicleType.Car;

            string carDetails = $"{firstVehicle.Make} {firstVehicle.Color}";
            Console.WriteLine(carDetails);

            Vehicle myVehicle = new Vehicle();
            myVehicle.Year = 2025;

            Vehicle rocket = new Vehicle("SpaceX", "Falcon Heavy", 2015, 90000, "spce grey", VehicleType.Spaceship);
            Vehicle wrongV = new Vehicle("Purple", "Toyota", 2, 2, "Vera", VehicleType.Submarine);

            Vehicle testV = new Vehicle();
        }

        [TestMethod]
        public void PersonTests()
        {
            Person personTwo = new Person("Appa","YipYip",new DateTime(2001,06,11));
            Console.WriteLine(personTwo.AgeInYears);
            Console.WriteLine(personTwo.FullName);
        }
    }
}
