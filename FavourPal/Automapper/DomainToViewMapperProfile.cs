using AutoMapper;
using FavourPal.Domain.Models;
using FavourPal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavourPal.Profiles
{
    public class DomainToViewMapperProfile : Profile
    {
        public DomainToViewMapperProfile()
        {
            CreateMap<Balance, BalanceViewModel>();
            CreateMap<Request, RequestViewModel>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(x => x.SenderUser != null ? x.SenderUser.Email : ""));
        }
    }
}
