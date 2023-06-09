﻿using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CAT.Catalog.Models
{
	public class Category
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }

		public string Name { get; set; }

        public string? Description { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        public DateTime CreatedTime { get; set; }

		[BsonRepresentation(BsonType.DateTime)]
		public DateTime UpdatedTime { get; internal set;}
    }
}

