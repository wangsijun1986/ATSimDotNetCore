using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.LocationEntities
{
    public class LocationEntity
    {
        public  ObjectId Id { get; set; }
        [BsonElement("Coordinate")]
        public double[] Coordinate { get; set; }
        [BsonElement("CarNumber")]
        public string CarNumber { get; set; }
        [BsonElement("CarId")]
        public long CarId { get; set; }
    }
}
