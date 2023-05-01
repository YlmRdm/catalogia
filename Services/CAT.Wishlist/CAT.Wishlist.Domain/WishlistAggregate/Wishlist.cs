using CAT.Wishlist.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Domain.WishlistAggregate
{
    public class Wishlist: Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Label Label { get; private set; }

        public string CreatorId { get; private set; }

        // Backing Field
        private readonly List<WishlistItem> _wishlistItems;

        public IReadOnlyCollection<WishlistItem> WishlistItems => _wishlistItems;

        public Wishlist(string creatorId, Label label) 
        {
            _wishlistItems = new List<WishlistItem>();
            CreatedDate = DateTime.Now;
            CreatorId = creatorId;
            Label = label;
        }

        public void AddWishlistItem(string productId, string productName, string productUrl, decimal price)
        {
            var existProduct = _wishlistItems.Any(x => x.ProductId == productId);

            if (!existProduct)
            {
                var newWishlistItem = new WishlistItem(productId, productName, productUrl, price);

                _wishlistItems.Add(newWishlistItem);
            }

        }

        public decimal GetTotalPrice => _wishlistItems.Sum(x => x.Price);
    } 
}
