using CAT.Wishlist.Application.Dtos;
using CAT.Wishlist.Application.Mapping;
using CAT.Wishlist.Application.Queries;
using CAT.Wishlist.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Dtos;

namespace CAT.Wishlist.Application.Handlers
{
    public class GetWishlistsByUserIdQueryHandler : IRequestHandler<GetWishlistsByUserIdQuery,Response<List<WishlistDto>>>
    {
        private readonly WishlistDbContext _context;

        public GetWishlistsByUserIdQueryHandler(WishlistDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<WishlistDto>>> Handle(GetWishlistsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var wishlists = await _context.Wishlists.Include(x => x.WishlistItems).Where(x => x.CreatorId==request.UserId).ToListAsync();
            
            if (!wishlists.Any())
            {
                return Response<List<WishlistDto>>.Success(new List<WishlistDto>(), 200);
            }

            var wishlistsDto = ObjectMapper.Mapper.Map<List<WishlistDto>>(wishlists);

            return Response<List<WishlistDto>>.Success(wishlistsDto, 200);
        }
    }
}
