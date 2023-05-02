using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Application.Dtos
{
    public class WishlistItemDto
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductUrl { get; set; }

        public Decimal Price { get; set; }
    }
}
