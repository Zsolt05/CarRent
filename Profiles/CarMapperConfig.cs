using AutoMapper;


namespace CarRent.Profiles
{
    public class CarMapperConfig : Profile
    {
        public CarMapperConfig()
        {
            CreateMap<Models.Entities.Car, Models.Car.CarDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category));
            CreateMap<Models.Car.CreateCarDto, Models.Entities.Car>();
            CreateMap<Models.Entities.Category, Models.Car.CarCategoryDto>();
        }
    }
}
