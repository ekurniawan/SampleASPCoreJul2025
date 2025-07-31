using System;
using AutoMapper;
using HandsOnLab.BL.DTO;
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
        throw new NotImplementedException();
    }

    public void DeleteDealer(int id)
    {
        throw new NotImplementedException();
    }

    public DealerDTO GetById(int id)
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
