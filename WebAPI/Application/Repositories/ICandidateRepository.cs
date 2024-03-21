using Application.ViewModels.Input;
using Domain.Common.Enum;
using Domain.Entities;

namespace Application.Repositories
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<List<Candidate>> GetCandidatesAsync(string searchName, DateTime? searchDate, Guid? interviewerId, CancellationToken token);
        Task<Candidate?> GetCandidateByIdAsync(Guid id, CancellationToken token);
        Task<Candidate> UpdateCandidateAsync(UpdateCandidateViewModel candidate, CancellationToken token);
        Task<bool> UpdateCandidateStatusAsync(Guid id, CandidateJobStatusEnum status, CancellationToken token);
    }
}
