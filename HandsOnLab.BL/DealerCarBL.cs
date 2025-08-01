using AutoMapper;
using HandsOnLab.BL.DTO;
using HandsOnLab.DAL;
using System;

namespace HandsOnLab.BL;

public class DealerCarBL : IDealerCarBL
{
    private readonly IDealerCar _dealerCaDAL;
    private readonly IMapper _mapper;

    public DealerCarBL(IDealerCar dealerCarDAL, IMapper mapper)
    {
        _dealerCaDAL = dealerCarDAL;
        _mapper = mapper;
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
        var dealerCars = _dealerCaDAL.GetAll();
        var dealerCarDTOs = _mapper.Map<IEnumerable<DealerCarDTO>>(dealerCars);
        return dealerCarDTOs;

        /*List<DealerCarDTO> dealerCarDTOs = new List<DealerCarDTO>();
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
        return dealerCarDTOs;*/
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
