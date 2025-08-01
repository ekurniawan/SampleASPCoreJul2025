using AutoMapper;
using HandsOnLab.BL.DTO;
using HandsOnLab.BO;
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
        try
        {
            var newDealerCar = _mapper.Map<DealerCar>(dealerCarInsertDTO);
            var addedDealerCar = _dealerCaDAL.Create(newDealerCar);
            if (addedDealerCar == null)
            {
                throw new Exception("Failed to add the dealer car.");
            }
            var dealerCarDTO = _mapper.Map<DealerCarDTO>(addedDealerCar);
            return dealerCarDTO;
        }
        catch (ArgumentException aEx)
        {
            throw new ArgumentException(aEx.Message);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while adding the dealer car.", ex);
        }
    }

    public void DeleteDealerCar(int id)
    {
        try
        {
            _dealerCaDAL.Delete(id);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
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
        var dealerCar = _dealerCaDAL.GetById(id);
        if (dealerCar == null)
        {
            throw new ArgumentException($"DealerCar with ID {id} not found.");
        }
        var dealerCarDTO = _mapper.Map<DealerCarDTO>(dealerCar);
        return dealerCarDTO;
    }

    public DealerCarDTO UpdateDealerCar(DealerCarUpdateDTO dealerCarUpdateDTO)
    {
        try
        {
            var updateDealerCar = _mapper.Map<DealerCar>(dealerCarUpdateDTO);
            var updatedDealerCar = _dealerCaDAL.Update(updateDealerCar);
            if (updatedDealerCar == null)
            {
                throw new Exception("Failed to update the dealer car.");
            }
            var dealerCarDTO = _mapper.Map<DealerCarDTO>(updatedDealerCar);
            return dealerCarDTO;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
