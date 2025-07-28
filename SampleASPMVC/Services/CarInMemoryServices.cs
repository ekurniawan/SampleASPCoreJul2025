using System;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services;

public class CarInMemoryServices : ICar
{
    private List<Car> cars = new List<Car>();
    public CarInMemoryServices()
    {
        // Initialize with some sample data
        cars.Add(new Car { CarID = 1, Model = "Model S", Type = "Sedan", BasePrice = 79999, Color = "Red", Stock = 10 });
        cars.Add(new Car { CarID = 2, Model = "Model X", Type = "SUV", BasePrice = 89999, Color = "Blue", Stock = 5 });
        cars.Add(new Car { CarID = 3, Model = "Model 3", Type = "Sedan", BasePrice = 39999, Color = "White", Stock = 15 });
        cars.Add(new Car { CarID = 4, Model = "Model Y", Type = "SUV", BasePrice = 49999, Color = "Black", Stock = 8 });
        cars.Add(new Car { CarID = 5, Model = "Mitsubishi Eclipse", Type = "Coupe", BasePrice = 59999, Color = "Silver", Stock = 3 });
    }

    public Car Create(Car item)
    {
        // Implementation for creating a new car
        item.CarID = cars.Count + 1; // Simple ID assignment logic
        cars.Add(item);
        return item;
    }

    public Car Read(int id)
    {
        //var car = cars.FirstOrDefault(c => c.CarID == id);
        var car = (from c in cars
                   where c.CarID == id
                   select c).FirstOrDefault();

        if (car == null)
        {
            throw new KeyNotFoundException($"Car with ID {id} not found.");
        }
        return car;
    }

    public Car Update(Car item)
    {
        var result = Read(item.CarID);
        result.Model = item.Model;
        result.Type = item.Type;
        result.BasePrice = item.BasePrice;
        result.Color = item.Color;
        result.Stock = item.Stock;

        return result;
    }

    public void Delete(int id)
    {
        var car = Read(id);
        cars.Remove(car);
    }

    public IEnumerable<Car> GetAll()
    {
        return cars;
    }
}

