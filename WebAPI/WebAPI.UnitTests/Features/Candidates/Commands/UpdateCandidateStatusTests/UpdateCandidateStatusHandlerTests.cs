using Application.Features.Candidates.Commands.UpdateCandidateStatusCommand;
using Application.Repositories;
using Application.ViewModels.Input;
using Moq;

namespace WebAPI.UnitTests.Features.Candidates.Commands.UpdateCandidateStatusTests
{
    public class UpdateCandidateStatusHandlerTests
    {
        private Mock<ICandidateRepository> _mockCandidateRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        public UpdateCandidateStatusHandlerTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task UpdateCandidateStatus_ShouldSucces_WhenDataIsValid()
        {
            var request = new UpdateCandidateStatusRequest();
            _mockCandidateRepository.Setup(x => x.UpdateCandidateStatusAsync(It.IsAny<List<UpdateCandidatesStatusViewModel>>(), default)).ReturnsAsync(true);
            _mockUnitOfWork.Setup(x => x.SaveAsync(default)).ReturnsAsync(1);

            UpdateCandidateStatusHandler handler = new UpdateCandidateStatusHandler(_mockCandidateRepository.Object, _mockUnitOfWork.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.True(result.IsSuccess);
        }
    }
}
