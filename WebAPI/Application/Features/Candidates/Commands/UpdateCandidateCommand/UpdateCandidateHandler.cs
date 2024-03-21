using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Commands.UpdateCandidateCommand
{
    public class UpdateCandidateHandler : IRequestHandler<UpdateCandidateRequest, UpdateCandidateResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCandidateHandler(ICandidateRepository candidateRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCandidateResponse> Handle(UpdateCandidateRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCandidateResponse();

            var candidate = await _candidateRepository.UpdateCandidateAsync(request.Candidate, cancellationToken);
            await _unitOfWork.SaveAsync(cancellationToken);

            var data = _mapper.Map<CandidateViewModel>(candidate);

            result.Candidate = data;

            return result;
        }
    }
}
