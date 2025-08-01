using System;
using HandsOnLab.BL.DTO;
using HandsOnLab.DAL;

namespace HandsOnLab.BL;

public class DealerCarBL : IDealerCarBL
{
    private readonly IDealerCar _dealerCaDAL;
    public DealerCarBL(IDealerCar dealerCarDAL)
    {
        _dealerCaDAL = dealerCarDAL;
    }

    public DealerCarDTO AddDealerCar(DealerCarInsertDTO dealerCarInsertDTO)
    {
        throw new NotImplementedException();
    }

    public void DeleteDealerCar(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<DealerCarDTO> GetAllDealerCars()
    {
        List<DealerCarDTO> dealerCarDTOs = new List<DealerCarDTO>();
        var dealerCars = _dealerCaDAL.GetAll();
        foreach (var dealerCar in dealerCars)
        {
            var dealerCarDTO = new DealerCarDTO
            {
                DealerCarId = dealerCar.DealerCarId,
                CarId = dealerCar.CarId,
                DealerId = dealerCar.DealerId,
                Price = dealerCar.Price,
                CarDTO = new CarDTO
                {
                    CarId = dealerCar.Car.CarId,
                    Model = dealerCar.Car.Model
                },
                DealerDTO = new DealerDTO
                {
                    DealerId = dealerCar.Dealer.DealerId,
                    Name = dealerCar.Dealer.Name
                }
            };
            dealerCarDTOs.Add(dealerCarDTO);
        }
        return dealerCarDTOs;
    }

    public DealerCarDTO GetDealerCarById(int id)
    {
        throw new NotImplementedException();
    }

    public DealerCarDTO UpdateDealerCar(DealerCarUpdateDTO dealerCarUpdateDTO)
    {
        throw new NotImplementedException();
    }
}
