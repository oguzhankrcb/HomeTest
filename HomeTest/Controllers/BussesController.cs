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
    public class BussesController : VehiclesController<Buss, EfCoreBussRepository>
    {
        EfCoreBussRepository repository;
        public BussesController(EfCoreBussRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet("{color}")]
        public async Task<ActionResult<IEnumerable<Buss>>> Get(string color)
        {
            return await repository.GetWithColor(color);
        }
    }
}
