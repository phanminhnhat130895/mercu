using Application.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.AutoMapper
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile() 
        {
            CreateMap<Job, JobViewModel>();
            CreateMap<CandidateJob, CandidateJobViewModel>();
            CreateMap<Candidate, CandidateViewModel>();
            CreateMap<Candidate, CandidatesViewModel>();
        }
    }
}
