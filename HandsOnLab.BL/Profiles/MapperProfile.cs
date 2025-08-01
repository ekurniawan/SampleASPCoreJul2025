using AutoMapper;
using HandsOnLab.BL.DTO;
using HandsOnLab.BO;
using System;

namespace HandsOnLab.BL.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Car, CarDTO>();
        CreateMap<CarInsertDTO, Car>();
        CreateMap<CarUpdateDTO, Car>();

        CreateMap<Dealer, DealerDTO>();
        CreateMap<DealerInsertDTO, Dealer>();
        CreateMap<DealerUpdateDTO, Dealer>();

        CreateMap<DealerCar, DealerCarDTO>();
        CreateMap<DealerCarInsertDTO, DealerCar>();
        CreateMap<DealerCarUpdateDTO, DealerCar>();
    }
}
