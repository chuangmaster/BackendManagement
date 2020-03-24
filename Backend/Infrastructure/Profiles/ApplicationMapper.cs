using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Backend.Infrastructure.Profiles
{
    public class ApplicationMapper
    {
        internal static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<AccountProfile>();
        }).CreateMapper();
    }
}