﻿using ATSimEntity.LocationEntities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.MongoData
{
    public interface ILocationData
    {
        Task<IEnumerable<LocationEntity>> GetNearByCarLocation(float[] location);
        Task<LocationEntity> UpdateCarLocation(LocationEntity entity,UpdateDefinition<LocationEntity> builder);

        Task<LocationEntity> InsertCarLocation(LocationEntity entity);

        IEnumerable<LocationEntity> SelectMoreLocationNear(float[] location);
    }
}
