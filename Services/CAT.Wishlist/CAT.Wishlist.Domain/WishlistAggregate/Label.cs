using CAT.Wishlist.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAT.Wishlist.Domain.WishlistAggregate
{
    public class Label: ValueObject
    {
        public string Color { get; private set; }
        public string Text { get; private set; }
        public int Amount { get; private set; }

        public Label(string color, string text, int amount)
        {
            Color = color;
            Text = text;
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Color;
            yield return Text;
            yield return Amount;
        }
    }
}
