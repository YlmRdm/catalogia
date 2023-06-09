﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CAT.Catalog.Models
{
	public class Product
	{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        // TODO: This will be converted as non-null reference later.
        public string? UserId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.Double)]
        public float Quantity { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

        public Feature Feature { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime UpdatedTime { get; internal set; }
    }
}

