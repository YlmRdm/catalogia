using CAT.Wishlist.Application.Commands;
using CAT.Wishlist.Application.Dtos;
using CAT.Wishlist.Domain.WishlistAggregate;
using CAT.Wishlist.Infrastructure;
using MediatR;
using Shared.Dtos;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Handlers
{
    public class CreateWishlistCommandHandler : IRequestHandler<CreateWishlistCommand, Response<CreatedWishlistDto>>
    {
        private readonly WishlistDbContext _context;

        public CreateWishlistCommandHandler(WishlistDbContext context)
        {
            _context = context;
        }

        public async Task<Response<CreatedWishlistDto>> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
        {
            var newLabel = new Label(request.Label.Color, request.Label.Text, request.Label.Amount);

            Domain.WishlistAggregate.Wishlist newWishlist = new Domain.WishlistAggregate.Wishlist(request.CreatorId, newLabel);

            request.WishlistItems.ForEach(x =>
            {
                newWishlist.AddWishlistItem(x.ProductId, x.ProductName, x.ProductUrl, x.Price);
            });

            await _context.Wishlists.AddAsync(newWishlist);

            await _context.SaveChangesAsync();
        
            return Response<CreatedWishlistDto>.Success(new CreatedWishlistDto { WishlistId=newWishlist.Id}, 200);
        }
    }
}
