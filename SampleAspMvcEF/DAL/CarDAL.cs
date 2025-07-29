using Microsoft.EntityFrameworkCore;
using SampleAspMvcEF.Models;
using System;

namespace SampleAspMvcEF.DAL;

public class CarDAL : ICar
{
    private readonly AutomotiveDB3Context _context;
    public CarDAL(AutomotiveDB3Context context)
    {
        _context = context;
    }

    public Car Create(Car item)
    {
        try
        {
            _context.Cars.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating car: " + ex.Message);
        }
    }

    public void Delete(int id)
    {
        try
        {
            var car = GetById(id);
            if (car == null)
            {
                throw new Exception("Car not found");
            }
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting car: " + ex.Message);
        }
    }

    public IEnumerable<Car> GetAll()
    {
        //var cars = _context.Car.OrderByDescending(c => c.Model).ThenByDescending(c => c.Color).ToList();
        var cars = from c in _context.Cars
                   orderby c.Model descending, c.Color descending
                   select c;
        return cars;
    }

    public IEnumerable<Car> GetByColor(string color)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        var result = _context.Cars.Where(c => c.CarId == id).FirstOrDefault();
        // var result = (from c in _context.Car
        //               where c.CarID == id
        //               select c).FirstOrDefault();
        //var result = _context.Car.Find(id);
        if (result == null)
        {
            throw new Exception("Car not found");
        }
        return result;
    }

    public IEnumerable<Car> GetByModel(string model)
    {
        var results = _context.Cars.Where(c => c.Model.Contains(model)
        || c.Color.Contains(model) || c.Type.Contains(model)).ToList();
        if (results == null || !results.Any())
        {
            throw new Exception("No cars found with the specified model");
        }
        return results;
    }

    public IEnumerable<Car> GetByType(string type)
    {
        throw new NotImplementedException();
    }

    public Car Update(Car item)
    {
        var result = GetById(item.CarId);
        if (result == null)
        {
            throw new Exception("Car not found");
        }
        try
        {
            _context.Entry(result).CurrentValues.SetValues(item);
            /*result.Model = item.Model;
            result.Color = item.Color;
            result.Type = item.Type;
            result.BasePrice = item.BasePrice;
            result.Stock = item.Stock;*/
            _context.SaveChanges();
            return item;
        }
        catch (Exception ex)
        {
            throw new Exception("Error updating car: " + ex.Message);
        }
    }
}
