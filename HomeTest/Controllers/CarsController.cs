using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeTest.Models;
using HomeTest.Data.EFCore;

namespace HomeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : VehiclesController<Car, EfCoreCarRepository>
    {
        EfCoreCarRepository repository;

        public CarsController(EfCoreCarRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("{color}")]
        public async Task<ActionResult<IEnumerable<Car>>> Get(string color)
        {
            return await repository.GetWithColor(color);
        }

        [HttpGet("{carid}/{onoff}")]
        public async Task<ActionResult<Car>> Get(int carid, bool onoff)
        {
            return await repository.SetHeadlightsOnOff(carid, onoff);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> Delete(int id)
        {
            var vehicle = await repository.Delete(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }
    }
}
