using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using MediatR;

namespace Application.Features.Interviewers.Queries.GetInterviewersQuery
{
    public class GetInterviewersHandler : IRequestHandler<GetInterviewersRequest, GetInterviewersResponse>
    {
        private readonly IInterviewerRepository _interviewerRepository;
        private readonly IMapper _mapper;
        public GetInterviewersHandler(IInterviewerRepository interviewerRepository, IMapper mapper)
        {
            _interviewerRepository = interviewerRepository;
            _mapper = mapper;
        }

        public async Task<GetInterviewersResponse> Handle(GetInterviewersRequest request, CancellationToken cancellationToken)
        {
            var result = new GetInterviewersResponse();

            var interviewers = await _interviewerRepository.GetInterviewersAsync(cancellationToken);

            var data = _mapper.Map<List<InterviewerViewModel>>(interviewers);
            result.Interviewers = data;

            return result;
        }
    }
}
