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
                query = query.Where(_ => _.DateCreated == searchDate);
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
                                    .FirstOrDefaultAsync(_ => _.Id == id, token);

            return candidate;
        }

        public async Task<Candidate> UpdateCandidateAsync(UpdateCandidateViewModel candidate, CancellationToken token)
        {
            if (candidate == null) throw new ArgumentNullException("Candidate cannot be null.");

            var updateCandidate = await _context.Candidates
                                            .Include(_ => _.Jobs)
                                            .FirstOrDefaultAsync(_ => _.Id == candidate.Id, token);

            if (updateCandidate == null) throw new NotFoundException("Candidate not found.");

            var interviewer = await _context.Interviewers.FirstOrDefaultAsync(_ => _.Id == candidate.InterviewerId);

            if (interviewer == null) throw new NotFoundException("Interviewer not found.");

            var job = updateCandidate.Jobs.FirstOrDefault(_ => _.JobId == candidate.JobId);

            if (job == null) throw new NotFoundException("Job not found.");

            var updatedDate = DateTime.Now;
            job.InterviewerId = candidate.InterviewerId;
            job.DateUpdated = updatedDate;

            updateCandidate.FirstName = candidate.FirstName;
            updateCandidate.LastName = candidate.LastName;
            updateCandidate.PhoneNumber = candidate.PhoneNumber;
            updateCandidate.Email = candidate.Email;
            updateCandidate.DateUpdated = updatedDate;

            return updateCandidate;
        }

        public async Task<bool> UpdateCandidateStatusAsync(Guid id, CandidateJobStatusEnum status, CancellationToken token)
        {
            var updateCandidateJob = await _context.CandidateJobs.FirstOrDefaultAsync(_ => _.Id == id, token);

            if (updateCandidateJob == null) throw new NotFoundException("Candidate job not found.");

            updateCandidateJob.Status = status;
            updateCandidateJob.DateUpdated = DateTime.Now;

            return true;
        }
    }
}
