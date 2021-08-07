using HomeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTest.Data.EFCore
{
    public class EfCoreBussRepository : EfCoreRepository<Buss, HomeTestContext>
    {
        private HomeTestContext context;

        public EfCoreBussRepository(HomeTestContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Buss> Add(Buss entity)
        {
            entity.Type = "Buss";
            entity.Color = entity.Color.ToLowerInvariant();
            context.Set<Buss>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Buss>> GetWithColor(string color)
        {
            return await context.Buss.Where(c => c.Color == color).ToListAsync();
        }
    }
}
