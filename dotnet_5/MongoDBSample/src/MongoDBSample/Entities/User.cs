using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace MongoDBSample.Entities
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId), BsonId]
        public string Id { get; set; }
        public string Name { get; set; }
        public string MutableField { get; set; }

        public override string ToString()
        {
            return $"{{ \"Id\": \"{Id}\", \"Name\": \"{Name}\", \"MutableField\": \"{MutableField}\" }}";
        }
    }
}
