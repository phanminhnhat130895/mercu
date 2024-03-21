using Domain.Entities;

namespace Application.Repositories
{
    public interface IInterviewerRepository : IBaseRepository<Interviewer>
    {
        Task<List<Interviewer>> GetInterviewersAsync(CancellationToken token);
    }
}
