using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.LocationEntities;
using ATSimData.MongoData;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace ATSimService.Location
{
    public class LocationService : ILocationService
    {
        private ILocationData locationData;
        public LocationService(ILocationData locationData)
        {
            this.locationData = locationData;
        }

        public IEnumerable<LocationEntity> GetNearByCarLocation(double[] location)
        {
            //Task<IEnumerable<LocationEntity>> result = locationData.GetNearByCarLocation(location);
            //TaskAwaiter<IEnumerable<LocationEntity>> awaiter = result.GetAwaiter();
            //result.Wait();
            //if (awaiter.IsCompleted)
            //{
            //    return awaiter.GetResult();
            //}
            //else
            //{
            //    return new List<LocationEntity>();
            //}

            return locationData.SelectMoreLocationNear(location);
        }

        public void UpdateCarLocation(LocationEntity entity)
        {
            var builder = Builders<LocationEntity>.Update
                .Set("Coordinate", entity.Coordinate);
            locationData.UpdateCarLocation(entity, builder);
        }

        public LocationEntity InsertCarLocation(LocationEntity entity)
        {
            Task<LocationEntity> result = locationData.InsertCarLocation(entity);
            TaskAwaiter<LocationEntity> awaiter = result.GetAwaiter();
            result.Wait();
            if (awaiter.IsCompleted)
            {
                return awaiter.GetResult();
            }
            else
            {
                return new LocationEntity();
            }
        }
    }
}
