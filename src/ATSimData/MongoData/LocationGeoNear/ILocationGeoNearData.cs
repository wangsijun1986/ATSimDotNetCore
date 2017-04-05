using ATSimEntity.Location;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATSimData.MongoData.LocationGeoNear
{
    public interface ILocationGeoNearData
    {
        LocationGeoNearEntity GetGeoNearLocationsByCoordinate(double[] location);
    }
}
