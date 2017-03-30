﻿using ATSimEntity.LocationEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimService.Location
{
    public interface ILocationService
    {
        IEnumerable<LocationEntity> GetNearByCarLocation(float[] location);

        void UpdateCarLocation(LocationEntity entity);

        LocationEntity InsertCarLocation(LocationEntity entity);
    }
}
