using System;
using AutoMapper;
using HandsOnLab.BL.DTO;
using HandsOnLab.BO;
using HandsOnLab.DAL;

namespace HandsOnLab.BL;

public class DealerBL : IDealerBL
{
    private readonly IMapper _mapper;
    private readonly IDealer _dealerDAL;
    public DealerBL(IMapper mapper, IDealer dealerDAL)
    {
        _mapper = mapper;
        _dealerDAL = dealerDAL;
    }

    public DealerDTO AddDealer(DealerInsertDTO dealerInsertDto)
    {
        try
        {
            var newDealer = _mapper.Map<Dealer>(dealerInsertDto);
            _dealerDAL.Create(newDealer);
            var result = _mapper.Map<DealerDTO>(newDealer);
            return result;
        }
        catch (System.Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            throw new ArgumentException($"An error occurred while adding the dealer. {ex.Message}", ex);
        }
    }

    public void DeleteDealer(int id)
    {
        try
        {
            _dealerDAL.Delete(id);
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            throw new ArgumentException($"An error occurred while deleting the dealer. {ex.Message}", ex);
        }
    }

    public DealerDTO GetById(int id)
    {
        var dealer = _dealerDAL.GetById(id);
        if (dealer == null)
        {
            throw new ArgumentException($"Dealer with ID {id} not found.");
        }
        var dealerDto = _mapper.Map<DealerDTO>(dealer);
        return dealerDto;
    }

    public IEnumerable<DealerDTO> GetDealers()
    {
        var dealers = _dealerDAL.GetAll();
        var dealerDtos = _mapper.Map<IEnumerable<DealerDTO>>(dealers);
        if (dealerDtos == null)
        {
            throw new ArgumentException("No dealers found.");
        }
        return dealerDtos;
    }

    public DealerDTO UpdateDealer(DealerUpdateDTO dealerUpdateDto)
    {
        try
        {
            var editDealer = _mapper.Map<Dealer>(dealerUpdateDto);
            _dealerDAL.Update(editDealer);
            var result = _mapper.Map<DealerDTO>(editDealer);
            return result;
        }
        catch (Exception ex)
        {
            // Log the exception (logging mechanism not shown here)
            throw new ArgumentException($"An error occurred while updating the dealer. {ex.Message}", ex);
        }
    }
}
