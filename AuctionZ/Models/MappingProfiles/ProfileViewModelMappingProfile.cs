﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTO;
using AuctionZ.Models.Account;
using AutoMapper;

namespace AuctionZ.Models.MappingProfiles
{
    public class ProfileViewModelMappingProfile : Profile
    {
        public ProfileViewModelMappingProfile()
        {
            CreateMap<ProfileViewModel, UserDto>()
                .ForMember(x => x.Money, opt => opt.Ignore());
            CreateMap<ProfileViewModel, RegisterViewModel>()
                .ForSourceMember(x => x.Money, opt => opt.Ignore());
        }

    }
}
