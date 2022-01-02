using AutoMapper;
using LOGIC.Models;
using WEB_API.Contracts.Rubric;
using WEB_API.Contracts.RubricCriterium;

namespace WEB_API.Mapping
{
    public class RubricMapping : Profile
    {
        public RubricMapping()
        {
            CreateMap<UpdateRubricRequest, Rubric>();
            CreateMap<CreateRubricRequest, Rubric>();
            CreateMap<Rubric, RubricResponse>();
            CreateMap<RubricCriteriumContract, RubricCriterium>().ReverseMap();
        }
    }
}
