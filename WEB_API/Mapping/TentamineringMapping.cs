using AutoMapper;
using LOGIC.Models;
using WEB_API.Contracts.Tentaminering;
using WEB_API.Contracts.TentamineringLeeruitkomst;

namespace WEB_API.Mapping
{
    public class TentamineringMapping : Profile
    {
        public TentamineringMapping()
        {
            CreateMap<Tentaminering, TentamineringResponse>();
            CreateMap<CreateTentamineringRequest, Tentaminering>();
            CreateMap<UpdateTentamineringRequest, Tentaminering>();

            CreateMap<TentamineringLeeruitkomst, TentamineringLeeruitkomstResponse>();
            CreateMap<TentamineringLeeruitkomstRequest, TentamineringLeeruitkomst>();
        }
    }
}
