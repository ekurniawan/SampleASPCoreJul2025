using System;
using HandsOnLab.BL.DTO;

namespace HandsOnLab.BL;

public interface ICarBL
{
    IEnumerable<CarDTO> GetCars();
    CarDTO GetById(int id);
    CarDTO AddCar(CarInsertDTO carInsertDto);
    CarDTO UpdateCar(CarUpdateDTO carUpdateDto);
    void DeleteCar(int id);
    IEnumerable<CarDTO> GetCarsBySearch(string searchTerm);
}
