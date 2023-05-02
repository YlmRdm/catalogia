using CAT.Wishlist.Application.Dtos;
using MediatR;
using Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Queries
{
    public class GetWishlistsByUserIdQuery:IRequest<Response<List<WishlistDto>>>
    {
        public string UserId { get; set; }
    }
}
