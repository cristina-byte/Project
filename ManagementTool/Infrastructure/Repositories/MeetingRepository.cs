using Application.Abstraction;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly ApplicationContext _context;

        public MeetingRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Meeting> CreateAsync(Meeting meeting)
        {
            var task=await _context.AddAsync(meeting);
            return task.Entity;
        }

        public async Task Delete(int id)
        {
            var meeting = await _context.Meetings.FirstOrDefaultAsync(me => me.Id == id);
            _context.Meetings.Remove(meeting);
        }

        public async Task<Meeting> GetAsync(int id)
        {
            return await _context.Meetings.Include(meeting=>meeting.Organizator).Include(meeting=>meeting.MeetingInvited)
                .ThenInclude(mI=>mI.User).Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Meeting>> GetAllAsync(int userId)
        {
            return await _context.MeetingInviteds.Where(mI=>mI.UserId==userId).Join(
             _context.Meetings,
              meetingInvited => meetingInvited.MeetingId,
              meeting => meeting.Id,
               (meetingInvited, meeting) => meeting).Include(meeting=>meeting.Organizator).ToListAsync();
        }

        public async Task UpdateAsync(int id, Meeting meeting)
        {
           throw new NotImplementedException();
        }

        public async Task AddGuests(int meetingId,IEnumerable<int> guests)
        {
            List<MeetingInvited> meetingInviteds = new List<MeetingInvited>();
            foreach(var guest in guests)
            {
                var meetingInvited = new MeetingInvited(guest, meetingId);
                meetingInviteds.Add(meetingInvited);
            }
            await _context.MeetingInviteds.AddRangeAsync(meetingInviteds);
        }
    }
}
