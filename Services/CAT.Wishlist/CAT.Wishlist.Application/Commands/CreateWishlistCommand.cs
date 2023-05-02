using CAT.Wishlist.Application.Dtos;
using Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Commands
{
    public class CreateWishlistCommand: IRequest<Response<CreatedWishlistDto>>
    {

        public string CreatorId { get; set; }

        public List<WishlistItemDto> WishlistItems { get; set; }

        public LabelDto Label { get; set; }
    }
}
