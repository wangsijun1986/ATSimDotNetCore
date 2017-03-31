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
        public IActionResult Get()
        {
            var result = locationService.GetNearByCarLocation(new double[] { 129.4905, 31.2646 });
            return Json(result);
        }
        [HttpPost]
        public IActionResult Post()
        {
            LocationEntity entity = new LocationEntity();
            entity.CarId = 2;
            entity.Coordinate = new double[] { 129.4905, 31.2646 };
            entity.CarNumber = "陕A75555";
            return Ok(locationService.InsertCarLocation(entity));
        }

        [HttpPut]
        public IActionResult Put()
        {
            LocationEntity entity = new LocationEntity();
            entity.CarId = 2;
            entity.Coordinate = new double[] { 109.4915, 51.2646 };
            entity.CarNumber = "陕A75555";
            locationService.UpdateCarLocation(entity);
            return Ok();
        }
    }
}
