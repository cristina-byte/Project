using Application.Abstraction;
using Domain.Entities.TeamEntities;
using Domain.Entities;
using Task = System.Threading.Tasks.Task;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationContext _context;

        public TeamRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Team> CreateAsync(Team team)
        {

            var task=await _context.Teams.AddAsync(team);
            return task.Entity;
        }

        public async Task Delete(int id)
        {
            var team = await _context.Teams.Where(t => t.Id == id).FirstOrDefaultAsync();
            _context.Teams.Remove(team);
        }

        public async Task<Team> GetAsync(int id)
        {
            return await _context.Teams.Include(t => t.Admin).Include(t=>t.Chat)
                .Include(t=>t.MemberTeams).ThenInclude(mt=>mt.Member).Where(t => t.Id == id).FirstAsync();
        }

        public async Task UpdateNameAsync(int id, string name)
        {
            var team = await _context.Teams.FindAsync(id);
            team.Name = name;
        }

        public async Task AddMemberAsync(int userId, int teamId)
        {
            var teamMember = new MemberTeam(userId, teamId);
            await _context.TeamMembers.AddAsync(teamMember);
        }

        public async Task<IEnumerable<Team>> GetTeamsForUser(int userId)
        {
            var teams = await _context.TeamMembers.Where(tm => tm.MemberId == userId)
                .Include(tm => tm.Team).ThenInclude(team => team.Chat)
                .Select(tm => tm.Team).ToListAsync();
            return teams;
        }
    }
}
