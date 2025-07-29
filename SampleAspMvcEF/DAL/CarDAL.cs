using System;
using Microsoft.EntityFrameworkCore;
using SampleAspMvcEF.Models;

namespace SampleAspMvcEF.DAL;

public class CarDAL : ICar
{
    private readonly ApplicationDbContext _context;
    public CarDAL(ApplicationDbContext context)
    {
        _context = context;
    }

    public Car Create(Car item)
    {
        try
        {
            _context.Car.Add(item);
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
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetAll()
    {
        //var cars = _context.Car.OrderByDescending(c => c.Model).ThenByDescending(c => c.Color).ToList();
        var cars = from c in _context.Car
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
        var result = _context.Car.Where(c => c.CarID == id).FirstOrDefault();
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
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetByType(string type)
    {
        throw new NotImplementedException();
    }

    public Car Update(Car item)
    {
        var result = GetById(item.CarID);
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
