using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimEntity.Location
{
    public class LocationGeoNearEntity
    {
        [BsonElement("results")]
        public IEnumerable<LocationGeoNearResult> Results { get; set; }
        [BsonElement("stats")]
        public LocationGeoNearStats Stats { get; set; }

        [BsonElement("ok")]
        public int OK { get; set; }
    }

    public class LocationGeoNearResult
    {
        [BsonElement("dis")]
        public double Dis { get; set; }
        [BsonElement("obj")]
        public LocationEntity Obj { get; set; }
    }

    public class LocationGeoNearStats
    {
        [BsonElement("nscanned")]
        public int NScanned { get; set; }

        [BsonElement("objectsLoaded")]
        public int ObjectsLoaded { get; set; }

        [BsonElement("avgDistance")]
        public double AvgDistance { get; set; }

        [BsonElement("maxDistance")]
        public double MaxDistance { get; set; }

        [BsonElement("time")]
        public int Time { get; set; }
    }
}
