using Application.Abstraction;
using Domain.Entities.OportunityEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OportunityRepository : IOportunityRepository
    {
        private readonly ApplicationContext _context;

        public OportunityRepository(ApplicationContext context)
        {
            _context= context;
        }

        public async Task<Oportunity> CreateAsync(Oportunity oportunity)
        {
            var task=await _context.Oportunities.AddAsync(oportunity);
            return task.Entity;
        }

        public async Task Delete(int id)
        {
            var oportunity = await _context.Oportunities.Where(op => op.Id == id).FirstOrDefaultAsync();
            _context.Oportunities.Remove(oportunity);
        }

        public async Task <IEnumerable<Oportunity>> GetAllAsync()
        {
            return await _context.Oportunities.ToListAsync<Oportunity>();
        }

        public async Task<Oportunity> GetAsync(int id)
        {
            return await _context.Oportunities.Where(op => op.Id == id).Include(op=>op.Positions).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Oportunity>> GetOportunitiesPageAsync(int page)
        {
            return await _context.Oportunities.Skip((page - 1) * 3).Take(3).ToListAsync();
        }


        public async Task UpdateAsync(int id, Oportunity oportunity)
        {
            var op = await _context.Oportunities.FindAsync(id);
            op.Title = oportunity.Title;
            op.Location = oportunity.Location;
            op.StartDate = oportunity.StartDate;
            op.EndDate = oportunity.EndDate;
            op.ApplicationDeadline = oportunity.ApplicationDeadline;
            op.Description = oportunity.Description;
        }
    }
}
