using CAT.Wishlist.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Domain.WishlistAggregate
{
    public class WishlistItem: Entity
    {
        public string ProductId { get; private set; }

        public string ProductName { get; private set; }

        public string ProductUrl { get; private set; }

        public Decimal Price { get; private set; }

        public WishlistItem(string productId, string productName, string productUrl, decimal price)
        {
            ProductId = productId;
            ProductName = productName;
            ProductUrl = productUrl;
            Price = price;
        }

        public void UpdateWishlistItem(string productName, string productUrl, decimal price)
        {
            ProductName = productName;
            ProductUrl = productUrl;
            Price = price;
        }
    }
}
