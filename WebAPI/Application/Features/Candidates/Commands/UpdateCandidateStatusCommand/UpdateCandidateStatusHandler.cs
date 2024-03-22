using Application.Repositories;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateStatusCommand
{
    public class UpdateCandidateStatusHandler : IRequestHandler<UpdateCandidateStatusRequest, UpdateCandidateStatusResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateCandidateStatusHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork)
        {
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCandidateStatusResponse> Handle(UpdateCandidateStatusRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCandidateStatusResponse();

            var data = await _candidateRepository.UpdateCandidateStatusAsync(request.Data, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            result.IsSuccess = data;

            return result;
        }
    }
}
