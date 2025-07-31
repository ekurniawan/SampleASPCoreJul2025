using System;
using AutoMapper;
using HandsOnLab.BL.DTO;
using HandsOnLab.BO;

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
    }
}
