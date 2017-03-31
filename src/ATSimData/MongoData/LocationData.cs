using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.LocationEntities;
using MongoDB.Driver;

namespace ATSimData.MongoData
{
    public class LocationData : ILocationData
    {
        private MongoDBCommand<LocationEntity> mongoCommand; 

        public LocationData()
        {
            this.mongoCommand = new MongoDBCommand<LocationEntity>("Location");
        }

        public async Task<IEnumerable<LocationEntity>> GetNearByCarLocation(double[] location)
        {
            IEnumerable<LocationEntity> locationList = await mongoCommand.SelectMore(x => x.Coordinate == location);
            return locationList;
        }

        public IEnumerable<LocationEntity> SelectMoreLocationNear(double[] location) {
            var filter = Builders<LocationEntity>.Filter.Near(x => x.Coordinate, location[0], location[1]);
            LocationEntity entity = new LocationEntity();
            entity.CarId = 1;
            entity.Coordinate = new double[] { 129.4915, 31.2646 };
            entity.CarNumber = "陕A78878";

            var result = mongoCommand.SelectMoreLocationNear(filter);
            
            result.Wait();
            return result.Result;
        }
        public async Task<LocationEntity> InsertCarLocation(LocationEntity entity)
        {
            await mongoCommand.InsertAsync(entity);
            return await mongoCommand.SelectOneAsync(x => x.CarId.Equals(entity.CarId));
        }

        public async Task<LocationEntity> UpdateCarLocation(LocationEntity entity,UpdateDefinition<LocationEntity> builder)
        {
            return await mongoCommand.SelectOneAndUpdate(x=>x.CarId.Equals(entity.CarId), builder);
        }
    }
}
