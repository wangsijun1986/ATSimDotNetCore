using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATSimEntity.Location;
using ATSimData.MongoData.Location;
using ATSimData.MongoData.LocationGeoNear;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace ATSimService.Location
{
    public class LocationService : ILocationService
    {
        private ILocationData locationData;
        private ILocationGeoNearData locationGetNearData;
        public LocationService(ILocationData locationData, ILocationGeoNearData locationGetNearData)
        {
            this.locationData = locationData;
            this.locationGetNearData = locationGetNearData;
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

        public LocationGeoNearEntity GetGeoNearLocationsByCoordinate(double[] location)
        {
            return locationGetNearData.GetGeoNearLocationsByCoordinate(location);
        }

        public void UpdateCarLocation(LocationEntity entity)
        {
            var builder = Builders<LocationEntity>.Update
                .Set(x=>x.Coordinate, entity.Coordinate);
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
