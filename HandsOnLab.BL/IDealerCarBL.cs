using System;
using HandsOnLab.BL.DTO;

namespace HandsOnLab.BL;

public interface IDealerCarBL
{
    IEnumerable<DealerCarDTO> GetAllDealerCars();
    DealerCarDTO GetDealerCarById(int id);
    DealerCarDTO AddDealerCar(DealerCarInsertDTO dealerCarInsertDTO);
    DealerCarDTO UpdateDealerCar(DealerCarUpdateDTO dealerCarUpdateDTO);
    void DeleteDealerCar(int id);
}
