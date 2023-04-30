using System;
namespace CAT.Catalog.Dtos
{
	public class ProductCreateDto
	{
        public string? CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Quantity { get; set; }

        public string? UserId { get; set; }

        public FeatureDto Feature { get; set; }
    }
}

