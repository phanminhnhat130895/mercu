using Application.Common.Exceptions;
using Application.Repositories;
using Application.ViewModels.Input;
using Domain.Common.Enum;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(DataContext context) : base(context)
        {
        }

        public async Task<List<Candidate>> GetCandidatesAsync(string searchName, DateTime? searchDate, Guid? interviewerId, CancellationToken token)
        {
            var query = _context.Candidates.AsNoTracking()
                                           .Include(_ => _.Jobs)
                                           .Where(_ => _.DateDeleted == null);

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(_ => _.FirstName.Contains(searchName));
            }

            if (searchDate != null)
            {
                query = query.Where(_ => _.DateCreated >= searchDate && _.DateCreated <= searchDate.Value.AddHours(23).AddMinutes(59).AddSeconds(59));
            }

            if (interviewerId != null && interviewerId != Guid.Empty)
            {
                query = query.Where(_ => _.Jobs.Any(j => j.InterviewerId == interviewerId));
            }

            var candidates = await query.ToListAsync(token);
            return candidates;
        }

        public async Task<Candidate?> GetCandidateByIdAsync(Guid id, CancellationToken token)
        {
            var candidate = await _context.Candidates
                                    .AsNoTracking()
                                    .Include(_ => _.Jobs)
                                    .ThenInclude(_ => _.Job)
                                    .Include(_ => _.Jobs)
                                    .ThenInclude(_ => _.Interviewer)
                                    .FirstOrDefaultAsync(_ => _.Id == id, token);

            return candidate;
        }

        public async Task<Candidate> UpdateCandidateAsync(UpdateCandidateViewModel candidate, CancellationToken token)
        {
            var updateCandidate = await _context.Candidates
                                            .FirstOrDefaultAsync(_ => _.Id == candidate.Id, token);

            if (updateCandidate == null) throw new NotFoundException("Candidate not found.");

            updateCandidate.FirstName = candidate.FirstName;
            updateCandidate.LastName = candidate.LastName;
            updateCandidate.PhoneNumber = candidate.PhoneNumber;
            updateCandidate.Email = candidate.Email;
            updateCandidate.DateUpdated = DateTime.Now;

            return updateCandidate;
        }

        public async Task<bool> UpdateCandidateStatusAsync(List<UpdateCandidatesStatusViewModel> data, CancellationToken token)
        {
            var updateDate = DateTime.Now;
            var listId = data.Select(_ => _.Id).ToList();
            var updateCandidates = await _context.Candidates.Where(_ => listId.Contains(_.Id)).ToListAsync(token);

            foreach(var updateCandidate in updateCandidates)
            {
                var updateData = data.FirstOrDefault(_ => _.Id == updateCandidate.Id);
                if (updateData == null) continue;
                updateCandidate.Status = updateData.Status;
                updateCandidate.DateUpdated = updateDate;
            }

            return true;
        }
    }
}
