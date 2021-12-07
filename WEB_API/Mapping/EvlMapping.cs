using AutoMapper;
using LOGIC.Models;
using WEB_API.Contracts.Evl;

namespace WEB_API.Mapping
{
    public class EvlMapping : Profile
    {
        public EvlMapping()
        {
            CreateMap<Evl, EvlResponse>();
            CreateMap<CreateEvlRequest, Evl>();
        }
    }
}
