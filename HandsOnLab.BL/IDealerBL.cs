using System;
using HandsOnLab.BL.DTO;

namespace HandsOnLab.BL;

public interface IDealerBL
{
    IEnumerable<DealerDTO> GetDealers();
    DealerDTO GetById(int id);
    DealerDTO AddDealer(DealerInsertDTO dealerInsertDto);
    DealerDTO UpdateDealer(DealerUpdateDTO dealerUpdateDto);
    void DeleteDealer(int id);
}
