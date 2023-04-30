using System;
using CAT.Catalog.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CAT.Catalog.Dtos
{
	public class ProductDto
	{
        public string Id { get; set; }

        public string? CategoryId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public float Quantity { get; set; }

        public DateTime CreatedTime { get; set; }

        public FeatureDto Feature { get; set; }

        public CategoryDto Category { get; set; }

        public string? UserId { get; set; }
    }
}

