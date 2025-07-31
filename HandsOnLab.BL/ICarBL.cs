using System;
using HandsOnLab.BL.DTO;

namespace HandsOnLab.BL;

public interface ICarBL
{
    IEnumerable<CarDTO> GetCars();
    CarDTO GetById(int id);
    CarDTO AddCar(CarInsertDTO car);
    CarDTO UpdateCar(CarUpdateDTO car);
    void DeleteCar(int id);
}
