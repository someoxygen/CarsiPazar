using AutoMapper;
using CarsiPazarAPI.Dtos;
using CarsiPazarAPI.Models;

namespace CarsiPazarAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<City, CityForListDto>()
            //    .ForMember(dest => dest.PhotoUrl, opt =>
            //    {
            //        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
            //    });
            //CreateMap<City, CityForDetailDto>();
            CreateMap<User, UserForReturnDto>();
            //CreateMap<PhotoForCreationDto, Photo>();
            //CreateMap<Photo, PhotoForReturnDto>();
        }
    }
}
