using AutoMapper;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class AboutMapping : Profile
    {
        public AboutMapping()
        {
            // About sınıfı ile ResultAboutDto arasında eşleme tanımlanıyor
            CreateMap<About, ResultAboutDto>().ReverseMap();

            // About sınıfı ile CreateAboutDto arasında eşleme tanımlanıyor
            CreateMap<About, CreateAboutDto>().ReverseMap();

            // About sınıfı ile GetAboutDto arasında eşleme tanımlanıyor
            CreateMap<About, GetAboutDto>().ReverseMap();

            // About sınıfı ile UpdateAboutDto arasında eşleme tanımlanıyor
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}

