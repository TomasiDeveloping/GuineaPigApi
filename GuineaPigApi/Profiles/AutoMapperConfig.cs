using AutoMapper;
using GuineaPigApi.DTOs;
using GuineaPigApi.Models;

namespace GuineaPigApi.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<GuineaPig, GuineaPigDto>().ReverseMap();
            CreateMap<HealthCheck, HealthCheckDto>().ReverseMap();
        }
    }
}
