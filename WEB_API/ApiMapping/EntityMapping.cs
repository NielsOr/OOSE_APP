using AutoMapper;
using DAL.Entities;
using LOGIC.Models;

namespace WEB_API.Mapping
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            CreateMap<Evl, EvlEntity>().ReverseMap();
            CreateMap<Leeruitkomst, LeeruitkomstEntity>().ReverseMap();
            CreateMap<Eindkwalificatie, EindkwalificatieEntity>().ReverseMap();
            CreateMap<Tentaminering, TentamineringEntity>().ReverseMap();
            CreateMap<TentamineringLeeruitkomst, TentamineringLeeruitkomstEntity>().ReverseMap();
            CreateMap<Rubric, RubricEntity>().ReverseMap();
            CreateMap<RubricCriterium, RubricCriteriumEntity>().ReverseMap();
            CreateMap<EvlRevisie, EvlRevisieEntity>().ReverseMap();
        }
    }
}
