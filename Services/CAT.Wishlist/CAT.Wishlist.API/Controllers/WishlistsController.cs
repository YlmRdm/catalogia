using CAT.Shared.ControllerBases;
using CAT.Shared.Services;
using CAT.Wishlist.Application.Commands;
using CAT.Wishlist.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAT.Wishlist.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishlistsController : CustomBaseController
    {
        private readonly IMediator _mediator;
        private readonly ISharedIdentityService _sharedIdentityService;

        public WishlistsController(IMediator mediator, ISharedIdentityService sharedIdentityService)
        {
            _mediator = mediator;
            _sharedIdentityService = sharedIdentityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlists()
        {
            var response = await _mediator.Send(new GetWishlistsByUserIdQuery { UserId = _sharedIdentityService.GetUserId });

            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveWishlist(CreateWishlistCommand createWishlistCommand)
        {
            var response = await _mediator.Send(createWishlistCommand);

            return CreateActionResultInstance(response);
        }
    }
}
