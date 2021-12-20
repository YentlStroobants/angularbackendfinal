using AngularChallengeAPI.Data;
using AngularChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Services
{
    public class StatusService : IStatusService
    {
        private readonly ShopContext _context;
        public StatusService(ShopContext context)
        {
            _context = context;
        }

        public async Task<Status> DeleteStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);

            if (status == null)
            {
                return null;
            }

            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return status;
        }

        public async Task<Status> GetStatus(int id)
        {
            return await _context.Statuses.FindAsync(id)
;
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            return await _context.Statuses.ToListAsync();
        }

        public async Task<Status> PostStatus(Status status)
        {
            _context.Statuses.Add(status);
            await _context.SaveChangesAsync();
            return status;
        }

        public async Task<Status> PutStatus(int id, Status status)
        {
            _context.Entry(status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return status;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }
    }
}
