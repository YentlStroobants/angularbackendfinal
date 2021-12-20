using AngularChallengeAPI.Data;
using AngularChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public class FoodService : IFoodService
    {
        private readonly ShopContext _context;
        public FoodService(ShopContext context)
        {
            _context = context;
        }

        public async Task<Food> DeleteFood(int id)
        {
            var food = await _context.Foods.FindAsync(id);

            if (food == null)
            {
                return null;
            }

            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();

            return food;
        }

        public async Task<Food> GetFood(int id)
        {
            return await _context.Foods.FindAsync(id)
;
        }

        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> PostFood(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
            return food;
        }

        public async Task<Food> PutFood(int id, Food food)
        {
            _context.Entry(food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return food;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.Id == id);
        }
    }
}
