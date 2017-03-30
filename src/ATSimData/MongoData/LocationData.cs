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

        public async Task<IEnumerable<LocationEntity>> GetNearByCarLocation(float[] location)
        {
            IEnumerable<LocationEntity> locationList = await mongoCommand.SelectMore(x => x.Coordinate == location);
            return locationList;
        }

        public IEnumerable<LocationEntity> SelectMoreLocationNear(float[] location) {
            FilterDefinitionBuilder<LocationEntity> builder = new FilterDefinitionBuilder<LocationEntity>();

            LocationEntity entity = new LocationEntity();
            entity.CarId = 1;
            entity.Coordinate = new float[] { 129.4915f, 31.2646f };
            entity.CarNumber = "陕A78878";

            var result = mongoCommand.SelectMoreLocationNear(x => "$near", builder, location[0], location[1]);
            return result.Limit(10).ToList();
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
