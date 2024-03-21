using Domain.Entities;
using FluentValidation;

namespace Application.Features.Candidates.Commands.UpdateCandidateCommand
{
    public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateRequest>
    {
        public UpdateCandidateValidator() 
        {
            RuleFor(x => x.Candidate).NotNull().WithMessage("Candidate must be provided.");

            RuleFor(x => x.Candidate.FirstName).NotEmpty().WithMessage("FirstName cannot be empty.");

            RuleFor(x => x.Candidate.LastName).NotEmpty().WithMessage("LastName cannot be empty.");

            RuleFor(x => x.Candidate.Email).NotEmpty().WithMessage("Email cannot be empty.")
                                           .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(x => x.Candidate.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be empty.");

            RuleFor(x => x.Candidate.JobId).NotEmpty().WithMessage("JobId cannot be empty.");

            RuleFor(x => x.Candidate.InterviewerId).NotEmpty().WithMessage("InterviewerId cannot be empty.");
        }
    }
}
