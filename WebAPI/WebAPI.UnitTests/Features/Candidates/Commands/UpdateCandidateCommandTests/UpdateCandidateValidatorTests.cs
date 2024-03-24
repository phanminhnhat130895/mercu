using Application.Features.Candidates.Commands.UpdateCandidateCommand;
using Application.ViewModels.Input;
using FluentValidation.TestHelper;
using System.Text;

namespace WebAPI.UnitTests.Features.Candidates.Commands.UpdateCandidateCommandTests
{
    public class UpdateCandidateValidatorTests
    {
        private UpdateCandidateRequest BuildRequest()
        {
            var request = new UpdateCandidateRequest();
            request.Candidate = new UpdateCandidateViewModel();
            request.Candidate.FirstName = "Nhat";
            request.Candidate.LastName = "Phan";
            request.Candidate.Email = "nhat.phan@gmail.com";
            request.Candidate.PhoneNumber = "0123456789";

            return request;
        }

        private string BuildInvalidMaxLengthString(int length)
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < length; i++)
            {
                builder.Append('a');
            }
            return builder.ToString();
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateIsNull()
        {
            UpdateCandidateRequest request = new UpdateCandidateRequest();

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateFirstNameHasInvalidMaxlength()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.FirstName = BuildInvalidMaxLengthString(101);

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.FirstName);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateLastNameHasInvalidMaxlength()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.LastName = BuildInvalidMaxLengthString(101);

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.LastName);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateEmailHasInvalidMaxlength()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.Email = BuildInvalidMaxLengthString(256);

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.Email);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidatePhoneNumberHasInvalidMaxlength()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.PhoneNumber = BuildInvalidMaxLengthString(16);

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.PhoneNumber);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateFirstNameIsEmpty()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.FirstName = string.Empty;

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.FirstName);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateLastNameIsEmpty()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.LastName = string.Empty;

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.LastName);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateEmailIsEmpty()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.Email = string.Empty;

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.Email);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidatePhoneNumberIsEmpty()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.PhoneNumber = string.Empty;

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.PhoneNumber);
        }

        [Fact]
        public void Validation_ShouldFail_WhenCandidateEmailIsInvalid()
        {
            UpdateCandidateRequest request = BuildRequest();
            request.Candidate.Email = "nhat.phan";

            UpdateCandidateValidator validator = new UpdateCandidateValidator();

            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Candidate.Email);
        }
    }
}
