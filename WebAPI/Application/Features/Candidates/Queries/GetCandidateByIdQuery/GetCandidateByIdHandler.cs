using Application.Common.Exceptions;
using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries.GetCandidateByIdQuery
{
    public class GetCandidateByIdHandler : IRequestHandler<GetCandidateByIdRequest, GetCandidateByIdResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;
        public GetCandidateByIdHandler(ICandidateRepository candidateRepository, IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<GetCandidateByIdResponse> Handle(GetCandidateByIdRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCandidateByIdResponse();

            var candidate = await _candidateRepository.GetCandidateByIdAsync(request.Id, cancellationToken);

            if (candidate == null) throw new NotFoundException("Candidate not found.");

            var data = _mapper.Map<CandidateViewModel>(candidate);
            result.Candidate = data;

            return result;
        }
    }
}
