using Application.Common.Exceptions;
using Application.Features.Candidates.Queries.GetCandidateByIdQuery;
using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace WebAPI.UnitTests.Features.Candidates.Queries.GetCandidateByIdTests
{
    public class GetCandidateByIdHandlerTests
    {
        private Mock<ICandidateRepository> _mockCandidateRepository;
        private Mock<IMapper> _mockMapper;

        public GetCandidateByIdHandlerTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task GetCandidateById_ShouldSuccess_WhenCandidateExisting()
        {
            var request = new GetCandidateByIdRequest();
            var candidateViewModel = new CandidateViewModel();
            candidateViewModel.Id = Guid.NewGuid();
            var candidate = new Candidate(candidateViewModel.Id);
            _mockCandidateRepository.Setup(x => x.GetCandidateByIdAsync(It.IsAny<Guid>(), default)).ReturnsAsync(candidate);
            _mockMapper.Setup(x => x.Map<CandidateViewModel>(It.IsAny<Candidate>())).Returns(candidateViewModel);

            GetCandidateByIdHandler handler = new GetCandidateByIdHandler(_mockCandidateRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Candidate.Id, candidateViewModel.Id);
        }

        [Fact]
        public void GetCandidateById_ShouldThrowException_WhenCandidateNotExisting()
        {
            var request = new GetCandidateByIdRequest();
            var candidateViewModel = new CandidateViewModel();
            candidateViewModel.Id = Guid.NewGuid();
            var candidate = new Candidate(candidateViewModel.Id);
            _mockCandidateRepository.Setup(x => x.GetCandidateByIdAsync(It.IsAny<Guid>(), default)).ThrowsAsync(new NotFoundException("test"));
            _mockMapper.Setup(x => x.Map<CandidateViewModel>(It.IsAny<Candidate>())).Returns(candidateViewModel);

            GetCandidateByIdHandler handler = new GetCandidateByIdHandler(_mockCandidateRepository.Object, _mockMapper.Object);
            var exception = Assert.ThrowsAsync<NotFoundException>(() => handler.Handle(request, default));
            Assert.NotNull(exception);
            Assert.Equal("test", exception.Result.Message);
        }
    }
}
