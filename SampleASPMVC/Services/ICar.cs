using System;
using SampleASPMVC.Models;

namespace SampleASPMVC.Services;

public interface ICar : ICrud<Car>
{
    // Additional methods specific to Car can be added here if needed
}
