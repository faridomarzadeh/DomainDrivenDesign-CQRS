﻿using AutoMapper;
using Clean_arch.Query.Models.Products;
using Endpoint.Api.ViewModels.Products;

namespace Endpoint.Api.ViewModels
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<ProductReadModel,ProductViewModel>().ReverseMap();
        }
    }
}
