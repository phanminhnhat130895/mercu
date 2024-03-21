using Application.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InterviewerRepository : BaseRepository<Interviewer>, IInterviewerRepository
    {
        public InterviewerRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Interviewer>> GetInterviewersAsync(CancellationToken token)
        {
            var interviewers = await _context.Interviewers.Where(_ => _.DateDeleted == null).ToListAsync(token);

            return interviewers;
        }
    }
}
