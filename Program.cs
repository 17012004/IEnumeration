using System;
using System.Collections;
using System.Collections.Generic;

// Abstract class representing a vehicle
public abstract class Vehicle
{
    protected string _make;   // Store the make of the vehicle
    protected string _model;  // Store the model of the vehicle
    protected int _year;      // Store the year of the vehicle

    public Vehicle(string make, string model, int year)
    {
        _make = make;
        _model = model;
        _year = year;
    }

    public abstract void Start(); // Abstract method for starting the vehicle

    public abstract void Stop();  // Abstract method for stopping the vehicle

    public void DisplayDetails()
    {
        Console.WriteLine("Vehicle Details:");
        Console.WriteLine("Make: " + _make);
        Console.WriteLine("Model: " + _model);
        Console.WriteLine("Year: " + _year);
    }
}

// Derived class representing a car
public class Car : Vehicle, IEnumerable<int>
{
    private int[] _mileageData; // Store the mileage data of the car

    public Car(string make, string model, int year, int[] mileageData) : base(make, model, year)
    {
        _mileageData = mileageData;
    }

    public override void Start()
    {
        Console.WriteLine("Car engine started.");
    }

    public override void Stop()
    {
        Console.WriteLine("Car engine stopped.");
    }

    public IEnumerator<int> GetEnumerator()
    {
        foreach (int mileage in _mileageData)
        {
            yield return mileage;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> mileageData = new List<int>(); // Create a list to store the mileage data

        Console.WriteLine("Enter the mileage data for the car (enter 'done' when finished):");
        string mileageInput = Console.ReadLine(); // Read the mileage input

        while (mileageInput != "done")
        {
            if (int.TryParse(mileageInput, out int mileage)) // Attempt to parse the input as an integer
            {
                mileageData.Add(mileage); // Add the parsed mileage to the list
            }

            mileageInput = Console.ReadLine(); // Read the next mileage input
        }

        Car myCar = new Car("Toyota", "Camry", 2020, mileageData.ToArray()); // Create a new Car object with the mileage data

        myCar.DisplayDetails(); // Display the details of the car

        myCar.Start(); // Start the car's engine

        foreach (int mileage in myCar) // Iterate over the mileage values using foreach loop
        {
            Console.WriteLine("Mileage: " + mileage);
        }

        myCar.Stop(); // Stop the car's engine
    }
}
