using AutoMapper;
using LOGIC.Models;
using WEB_API.Contracts.Leeruitkomst;

namespace WEB_API.Mapping
{
    public class LeeruitkomstMapping : Profile
    {
        public LeeruitkomstMapping()
        {
            CreateMap<Leeruitkomst, LeeruitkomstResponse>().ReverseMap();
            CreateMap<CreateLeeruitkomstRequest, Leeruitkomst>();
            CreateMap<UpdateLeeruitkomstRequest, Leeruitkomst>();
        }
    }
}
