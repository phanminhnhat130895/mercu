using Application.ViewModels;

namespace Application.Features.Interviewers.Queries.GetInterviewersQuery
{
    public class GetInterviewersResponse
    {
        public List<InterviewerViewModel> Interviewers { get; set; }
    }
}
