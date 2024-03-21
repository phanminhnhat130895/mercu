using Application.Repositories;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateStatusCommand
{
    public class UpdateCandidateJobStatusHandler : IRequestHandler<UpdateCandidateJobStatusRequest, UpdateCandidateJobStatusResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCandidateJobStatusHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork)
        {
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCandidateJobStatusResponse> Handle(UpdateCandidateJobStatusRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCandidateJobStatusResponse();

            var data = await _candidateRepository.UpdateCandidateStatusAsync(request.Id, request.Status, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            result.IsSuccess = data;

            return result;
        }
    }
}
