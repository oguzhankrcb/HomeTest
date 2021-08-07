using HomeTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeTest.Data.EFCore
{
    public class EfCoreCarRepository : EfCoreRepository<Car, HomeTestContext>
    {
        private HomeTestContext context;
        public EfCoreCarRepository(HomeTestContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Car> Add(Car entity)
        {
            entity.Type = "Car";
            entity.Color = entity.Color.ToLowerInvariant();
            context.Set<Car>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task<List<Car>> GetWithColor(string color)
        {
            List<Car> cars = context.Car.Include(w => w.Wheels).Include(h => h.Headlights).Where(c => c.Color == color).ToList();
            return await context.Car.Where(c => c.Color == color).ToListAsync();
        }

        public async Task<Car> SetHeadlightsOnOff(int carId, bool onOff)
        {
            Car car = context.Car.Include(h => h.Headlights).Include(w => w.Wheels).Where(c => c.Id == carId).FirstOrDefault();

            if (car != null)
            {
                foreach(Headlight headlight in car.Headlights)
                {
                    headlight.IsOn = onOff;
                }
            }

            await context.SaveChangesAsync();
            return car;
        }


    }
}
