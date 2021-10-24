using AutoMapper;
using LOGIC.Models;
using System;
using WEB_API.Schemas.Evl;

namespace WEB_API.Mapping
{
    public class LeeruitkomstMapping : Profile
    {
        public LeeruitkomstMapping()
        {
            CreateMap<CreateEvlSchema, Evl>();
            CreateMap<UpdateEvlSchema, Evl>();
            CreateMap<Evl, EvlResponse>();
            CreateMap<Evl, BasicEvlResponse>();

        }
    }
}
