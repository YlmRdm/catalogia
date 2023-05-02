using AutoMapper;
using CAT.Wishlist.Application.Dtos;
using CAT.Wishlist.Domain.WishlistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Mapping
{
    public class CustomMapping: Profile
    {
        public CustomMapping()
        {
            CreateMap<Domain.WishlistAggregate.Wishlist,WishlistDto>().ReverseMap();
            CreateMap<WishlistItem,WishlistItemDto>().ReverseMap();
            CreateMap<Label,LabelDto>().ReverseMap();
        }
    }
}
