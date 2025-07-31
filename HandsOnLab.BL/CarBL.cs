using System;
using HandsOnLab.BL.DTO;
using HandsOnLab.BO;
using HandsOnLab.DAL;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace HandsOnLab.BL;

public class CarBL : ICarBL
{
    private readonly ICar _carDAL;
    public CarBL(ICar carDAL)
    {
        _carDAL = carDAL;
    }

    public CarDTO AddCar(CarInsertDTO carInsertDto)
    {
        try
        {
            var car = new Car
            {
                Model = carInsertDto.Model,
                Type = carInsertDto.Type,
                BasePrice = carInsertDto.BasePrice,
                Color = carInsertDto.Color,
                Stock = carInsertDto.Stock
            };
            var addedCar = _carDAL.Create(car);
            var result = new CarDTO
            {
                CarId = addedCar.CarId,
                Model = addedCar.Model,
                Type = addedCar.Type,
                BasePrice = addedCar.BasePrice,
                Color = addedCar.Color,
                Stock = addedCar.Stock
            };
            return result;
        }
        catch (Exception ex)
        {
            throw new ArgumentException($"Error adding car {ex.Message}");
        }
    }

    public void DeleteCar(int id)
    {
        throw new NotImplementedException();
    }

    public CarDTO GetById(int id)
    {
        var car = _carDAL.GetById(id);
        if (car == null)
        {
            throw new ArgumentException($"Car with id {id} not found.");
        }
        return new CarDTO
        {
            CarId = car.CarId,
            Model = car.Model,
            Type = car.Type,
            BasePrice = car.BasePrice,
            Color = car.Color,
            Stock = car.Stock
        };
    }

    public IEnumerable<CarDTO> GetCars()
    {
        var carDtos = new List<CarDTO>();
        var cars = _carDAL.GetAll();
        foreach (var car in cars)
        {
            carDtos.Add(new CarDTO
            {
                CarId = car.CarId,
                Model = car.Model,
                Type = car.Type,
                BasePrice = car.BasePrice,
                Color = car.Color,
                Stock = car.Stock
            });
        }
        return carDtos;
    }

    public CarDTO UpdateCar(CarUpdateDTO carUpdateDto)
    {
        throw new NotImplementedException();
    }
}
