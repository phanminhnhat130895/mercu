using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.Candidates.Queries.GetAllCandidateQuery
{
    public class GetCandidatesHandler : IRequestHandler<GetCandidatesRequest, GetCandidatesResponse>
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IMapper _mapper;
        public GetCandidatesHandler(ICandidateRepository candidateRepository, IMapper mapper) 
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        public async Task<GetCandidatesResponse> Handle(GetCandidatesRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCandidatesResponse();

            var candidates = await _candidateRepository.GetCandidatesAsync(request.SearchString, request.SearchDate, request.InterviewerId, cancellationToken);

            var data = _mapper.Map<List<CandidatesViewModel>>(candidates);
            result.Candidates = data.OrderBy(_ => _.DateCreated).ToList();

            return result;
        }
    }
}
