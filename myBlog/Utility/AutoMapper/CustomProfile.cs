using System;
using AutoMapper;
using MyModel.Dto;
using MyModel.Model;

namespace myBlogDemo.Utility.AutoMapper
{
    public class CustomProfile:Profile
    {
        public CustomProfile()
        {
            CreateMap<WriterInfo,WriterInfoDto>();
            CreateMap<BlogNews,BlogNewsDto>()
            .ForMember(d=>d.WriteName,s=>s.MapFrom(src=>src.WriterInfo.Name));
            //.ForMember(d=>d.TypeName,s=>s.MapFrom(src=>src.TypeInfo.Name))
            //.ForMember(d=>d.UserName,s=>s.MapFrom(src=>src.WriterInfo.UserName));
        }
    }
}
