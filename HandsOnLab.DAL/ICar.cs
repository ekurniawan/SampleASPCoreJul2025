using System;
using HandsOnLab.BO;

namespace HandsOnLab.DAL;

public interface ICar : ICrud<Car>
{
    // Additional methods specific to Car can be added here if needed
    IEnumerable<Car> GetByModel(string model);
    IEnumerable<Car> GetByType(string type);
    IEnumerable<Car> GetByColor(string color);
}
