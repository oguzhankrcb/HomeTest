using HomeTest.Data;
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
    public abstract class VehiclesController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IRepository<TEntity>
    {
        private readonly TRepository repository;

        public VehiclesController(TRepository repository)
        {
            this.repository = repository;
        }
    }
}
