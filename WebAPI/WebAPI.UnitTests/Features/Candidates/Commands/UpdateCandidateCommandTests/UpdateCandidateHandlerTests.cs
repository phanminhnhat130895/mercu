using Application.Common.Exceptions;
using Application.Features.Candidates.Commands.UpdateCandidateCommand;
using Application.Repositories;
using Application.ViewModels;
using Application.ViewModels.Input;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace WebAPI.UnitTests.Features.Candidates.Commands.UpdateCandidateCommandTests
{
    public class UpdateCandidateHandlerTests
    {
        private Mock<ICandidateRepository> _mockCandidateRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IMapper> _mockMapper;

        public UpdateCandidateHandlerTests() 
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task UpdateCandidate_ShouldSuccess_WhenDataIsValid()
        {
            var request = new UpdateCandidateRequest();
            var candidateViewModel = new CandidateViewModel();
            candidateViewModel.Id = Guid.NewGuid();
            var candidate = new Candidate(candidateViewModel.Id);
            _mockCandidateRepository.Setup(x => x.UpdateCandidateAsync(It.IsAny<UpdateCandidateViewModel>(), default)).ReturnsAsync(candidate);
            _mockUnitOfWork.Setup(x => x.SaveAsync(default)).ReturnsAsync(1);
            _mockMapper.Setup(x => x.Map<CandidateViewModel>(It.IsAny<Candidate>())).Returns(candidateViewModel);

            UpdateCandidateHandler handler = new UpdateCandidateHandler(_mockCandidateRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Candidate.Id, candidateViewModel.Id);
        }

        [Fact]
        public void UpdateCadidate_ShouldThrowException_WhenDataIsInvalid()
        {
            var request = new UpdateCandidateRequest();
            var candidateViewModel = new CandidateViewModel();
            candidateViewModel.Id = Guid.NewGuid();
            var candidate = new Candidate(candidateViewModel.Id);
            _mockCandidateRepository.Setup(x => x.UpdateCandidateAsync(It.IsAny<UpdateCandidateViewModel>(), default)).ThrowsAsync(new NotFoundException("test"));
            _mockUnitOfWork.Setup(x => x.SaveAsync(default)).ReturnsAsync(1);
            _mockMapper.Setup(x => x.Map<CandidateViewModel>(It.IsAny<Candidate>())).Returns(candidateViewModel);

            UpdateCandidateHandler handler = new UpdateCandidateHandler(_mockCandidateRepository.Object, _mockUnitOfWork.Object, _mockMapper.Object);
            var exception = Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, default));
            Assert.NotNull(exception);
            Assert.Equal("test", exception.Result.Message);
        }
    }
}
