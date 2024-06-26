﻿using Domain.Common.Enum;
using Domain.Entities;

namespace Application.ViewModels
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public CandidateStatusEnum Status { get; set; }

        public List<CandidateJobViewModel> Jobs { get; set; }
    }

    public class CandidateJobViewModel
    {
        public Guid Id { get; set; }
        public JobViewModel Job { get; set; }
        public InterviewerViewModel Interviewer { get; set; }
    }
}
