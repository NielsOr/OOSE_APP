using AutoMapper;
using LOGIC.Models;
using WEB_API.Schemas.Leeruitkomst;

namespace WEB_API.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<CreateLeeruitkomstSchema, Leeruitkomst>();
            CreateMap<UpdateLeeruitkomstSchema, Leeruitkomst>();
            CreateMap<Leeruitkomst, LeeruitkomstResponse>();
        }
    }
}
