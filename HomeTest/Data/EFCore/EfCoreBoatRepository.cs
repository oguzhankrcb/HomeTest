using HomeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTest.Data.EFCore
{
    public class EfCoreBoatRepository : EfCoreRepository<Boat, HomeTestContext>
    {
        private HomeTestContext context;
        public EfCoreBoatRepository(HomeTestContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Boat> Add(Boat entity)
        {
            entity.Type = "Boat";
            entity.Color = entity.Color.ToLowerInvariant();
            context.Set<Boat>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Boat>> GetWithColor(string color)
        {
            return await context.Boat.Where(c => c.Color == color).ToListAsync();
        }
        // We can add new methods specific to the movie repository here in the future
    }
}
