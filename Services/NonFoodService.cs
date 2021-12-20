using AngularChallengeAPI.Data;
using AngularChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public class NonFoodService : INonFoodService
    {
        private readonly ShopContext _context;
        public NonFoodService(ShopContext context)
        {
            _context = context;
        }

        public async Task<NonFood> DeleteNonFood(int id)
        {
            var nonFood = await _context.NonFoods.FindAsync(id);

            if (nonFood == null)
            {
                return null;
            }

            _context.NonFoods.Remove(nonFood);
            await _context.SaveChangesAsync();

            return nonFood;
        }

        public async Task<NonFood> GetNonFood(int id)
        {
            return await _context.NonFoods.FindAsync(id)
;
        }

        public async Task<IEnumerable<NonFood>> GetNonFoods()
        {
            return await _context.NonFoods.ToListAsync();
        }

        public async Task<NonFood> PostNonFood(NonFood nonFood)
        {
            _context.NonFoods.Add(nonFood);
            await _context.SaveChangesAsync();
            return nonFood;
        }

        public async Task<NonFood> PutNonFood(int id, NonFood nonFood)
        {
            _context.Entry(nonFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return nonFood;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NonFoodExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool NonFoodExists(int id)
        {
            return _context.NonFoods.Any(e => e.Id == id);
        }
    }
}
