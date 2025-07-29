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
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Car> GetAll()
    {
        return _context.Car.ToList();
    }

    public IEnumerable<Car> GetByColor(string color)
    {
        throw new NotImplementedException();
    }

    public Car GetById(int id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
