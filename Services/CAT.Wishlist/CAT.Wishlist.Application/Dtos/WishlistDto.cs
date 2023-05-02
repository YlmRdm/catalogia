using CAT.Wishlist.Domain.WishlistAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Dtos
{
    public class WishlistDto
    {
        public int Id { set; get; }
        public DateTime CreatedDate { get; set; }

        public LabelDto Label { get; set; }

        public string CreatorId { get; set; }

        public List<WishlistItemDto> WishlistItems { get; set; }
    }
}
