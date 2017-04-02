using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.LocationEntities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ATSimData.MongoData.LocationGeoNear
{
    public class LocationGeoNearData : ILocationGeoNearData
    {
        private MongoDBCommand<LocationGeoNearEntity> mongoCommand;

        public LocationGeoNearData()
        {
            this.mongoCommand = new MongoDBCommand<LocationGeoNearEntity>("Location");
        }

        public LocationGeoNearEntity GetGeoNearLocationsByCoordinate(double[] location)
        {
            Command<LocationGeoNearEntity> command = new BsonDocumentCommand<LocationGeoNearEntity>(BsonDocument.Parse("{\"geoNear\":\"Location\",\"near\":[129.4915, 31.2646]}"));
            
            var result = mongoCommand.RunCommandAsync(command);

            result.Wait();
            return result.Result;
        }
    }
}
