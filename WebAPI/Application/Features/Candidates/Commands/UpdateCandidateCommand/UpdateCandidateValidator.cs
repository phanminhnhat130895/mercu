using FluentValidation;

namespace Application.Features.Candidates.Commands.UpdateCandidateCommand
{
    public class UpdateCandidateValidator : AbstractValidator<UpdateCandidateRequest>
    {
        public UpdateCandidateValidator() 
        {
            RuleFor(x => x.Candidate).NotNull().WithMessage("Candidate must be provided.");

            RuleFor(x => x.Candidate.FirstName).NotEmpty().WithMessage("FirstName cannot be empty.")
                                               .MaximumLength(100).WithMessage("");

            RuleFor(x => x.Candidate.LastName).NotEmpty().WithMessage("LastName cannot be empty.")
                                              .MaximumLength(100).WithMessage("");

            RuleFor(x => x.Candidate.Email).NotEmpty().WithMessage("Email cannot be empty.")
                                           .EmailAddress().WithMessage("Invalid email address.")
                                           .MaximumLength(255).WithMessage("");

            RuleFor(x => x.Candidate.PhoneNumber).NotEmpty().WithMessage("PhoneNumber cannot be empty.")
                                                 .MaximumLength(15).WithMessage("");
        }
    }
}
