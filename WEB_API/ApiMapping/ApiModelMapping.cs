using AutoMapper;
using LOGIC.Models;
using WEB_API.ApiModels;

namespace WEB_API.Mapping
{
    public class ApiModelMapping : Profile
    {
        public ApiModelMapping()
        {
            CreateMap<EvlRequest, Evl>();
            CreateMap<Evl, EvlResponse>();

            CreateMap<CreateLeeruitkomstRequest, Leeruitkomst>();
            CreateMap<UpdateLeeruitkomstRequest, Leeruitkomst>();
            CreateMap<Leeruitkomst, LeeruitkomstResponse>();

            CreateMap<EindkwalificatieRequest, Eindkwalificatie>();
            CreateMap<Eindkwalificatie, EindkwalificatieResponse>();

            CreateMap<CreateTentamineringRequest, Tentaminering>();
            CreateMap<UpdateTentamineringRequest, Tentaminering>();
            CreateMap<Tentaminering, TentamineringResponse>();

            CreateMap<TentamineringLeeruitkomstRequest, TentamineringLeeruitkomst>();
            CreateMap<TentamineringLeeruitkomst, TentamineringLeeruitkomstResponse>();

            CreateMap<CreateRubricRequest, Rubric>();
            CreateMap<UpdateRubricRequest, Rubric>();
            CreateMap<Rubric, RubricResponse>();

            CreateMap<RubricCriteriumRequest, RubricCriterium>();
            CreateMap<RubricCriterium, RubricCriteriumResponse>();
        }
    }
}
