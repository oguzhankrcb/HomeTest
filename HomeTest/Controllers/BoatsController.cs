using HomeTest.Data.EFCore;
using HomeTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatsController : VehiclesController<Boat, EfCoreBoatRepository>
    {
        private EfCoreBoatRepository repository;

        public BoatsController(EfCoreBoatRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("{color}")]
        public async Task<ActionResult<IEnumerable<Boat>>> Get(string color)
        {
            return await repository.GetWithColor(color);
        }
    }
}
