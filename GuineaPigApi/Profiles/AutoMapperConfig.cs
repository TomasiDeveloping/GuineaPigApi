using AutoMapper;
using GuineaPigApi.DTO_s;
using GuineaPigApi.Models;

namespace GuineaPigApi.Profiles
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<GuineaPig, GuineaPigDTO>().ReverseMap();
            CreateMap<HealthCheck, HealthCheckDTO>().ReverseMap();
        }
    }
}
