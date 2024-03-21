using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class InterviewerProfile : Profile
    {
        public InterviewerProfile() 
        {
            CreateMap<Interviewer, InterviewerViewModel>();
        }
    }
}
