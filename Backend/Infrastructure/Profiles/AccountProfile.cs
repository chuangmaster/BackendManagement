using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Backend.Models.Parameters;
using Repository.Dapper.Parameters;

namespace Backend.Infrastructure.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<LoginParameter, MemberAddRptParameter>();
            CreateMap<SignUpParameter, MemberAddRptParameter>()
                .ForMember(d => d.ID, o => o.MapFrom(s => Guid.NewGuid()))
                .ForMember(d => d.Account, o => o.MapFrom(s => s.Email))
                .ForMember(d => d.Enable, o => o.MapFrom(s => true));


        }
    }
}