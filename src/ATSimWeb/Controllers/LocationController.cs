using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ATSimService.Location;
using ATSimEntity.LocationEntities;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ATSimWeb.Controllers
{
    [Route("api/[controller]")]
    public class LocationController : ATSimApiController
    {
        private ILocationService locationService;
        public LocationController(ILocationService locationService)
        {
            this.locationService = locationService;
        }

        [HttpGet]
        public IActionResult Get([FromQuery(Name ="type")]int type)
        {
            if (type == 1)
            {
                var result = locationService.GetNearByCarLocation(new double[] { 129.490511, 31.264622 });
                return Json(result);
            }
            else
            {
                var result = locationService.GetGeoNearLocationsByCoordinate(new double[] { 129.490511, 31.264622 });
                return Json(result);
            }
            
        }

        [HttpPost]
        public IActionResult Post()
        {
            LocationEntity entity = new LocationEntity();
            entity.CarId = 1;
            entity.Coordinate = new double[] { 129.114905, 31.222646 };
            entity.CarNumber = "陕A11111";
            return Ok(locationService.InsertCarLocation(entity));
        }

        [HttpPut]
        public IActionResult Put()
        {
            LocationEntity entity = new LocationEntity();
            entity.CarId = 1;
            entity.Coordinate = new double[] { 109.334915, 51.442646 };
            entity.CarNumber = "陕A11111";
            locationService.UpdateCarLocation(entity);
            return Ok();
        }
    }
}
