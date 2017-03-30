using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.LocationEntities
{
    public class LocationEntity
    {
        public  ObjectId Id { get; set; }
        public float[] Coordinate { get; set; }

        public string CarNumber { get; set; }

        public long CarId { get; set; }
    }
}
