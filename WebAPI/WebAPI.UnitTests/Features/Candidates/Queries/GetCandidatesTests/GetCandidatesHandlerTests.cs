using Application.Features.Candidates.Queries.GetAllCandidateQuery;
using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using Domain.Common.Enum;
using Domain.Entities;
using Moq;

namespace WebAPI.UnitTests.Features.Candidates.Queries.GetCandidatesTests
{
    public class GetCandidatesHandlerTests
    {
        private Mock<ICandidateRepository> _mockCandidateRepository;
        private Mock<IMapper> _mockMapper;

        public GetCandidatesHandlerTests()
        {
            _mockCandidateRepository = new Mock<ICandidateRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void GetCandidates_ShouldReturnCorrectValue_WhenDataExisting()
        {
            var request = new GetCandidatesRequest();

            var dbData = new List<Candidate>()
            {
                new Candidate(Guid.NewGuid()) { FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan@gmail.com", PhoneNumber = "0123456789", Status = CandidateStatusEnum.Applied, DateCreated = DateTime.Now },
                new Candidate(Guid.NewGuid()) { FirstName = "Hang", LastName = "Truong", Email = "hang.truong@gmail.com", PhoneNumber = "0123456788", Status = CandidateStatusEnum.Hired, DateCreated = DateTime.Now },
                new Candidate(Guid.NewGuid()) { FirstName = "Nam", LastName = "Nguyen", Email = "nam.nguyen@gmail.com", PhoneNumber = "0123456787", Status = CandidateStatusEnum.Interviewing, DateCreated = DateTime.Now },

            };

            var data = new List<CandidatesViewModel>()
            {
                new CandidatesViewModel() { Id = dbData[0].Id, FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan@gmail.com", PhoneNumber = "0123456789", Status = CandidateStatusEnum.Applied, DateCreated = DateTime.Now },
                new CandidatesViewModel() { Id = dbData[1].Id, FirstName = "Hang", LastName = "Truong", Email = "hang.truong@gmail.com", PhoneNumber = "0123456788", Status = CandidateStatusEnum.Hired, DateCreated = DateTime.Now },
                new CandidatesViewModel() { Id = dbData[2].Id, FirstName = "Nam", LastName = "Nguyen", Email = "nam.nguyen@gmail.com", PhoneNumber = "0123456787", Status = CandidateStatusEnum.Interviewing, DateCreated = DateTime.Now }
            };

            _mockCandidateRepository.Setup(x => x.GetCandidatesAsync(It.IsAny<string>(), It.IsAny<DateTime?>(), It.IsAny<Guid>(), default)).ReturnsAsync(dbData);
            _mockMapper.Setup(x => x.Map<List<CandidatesViewModel>>(It.IsAny<List<Candidate>>())).Returns(data);

            GetCandidatesHandler handler = new GetCandidatesHandler(_mockCandidateRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Candidates.Count, data.Count);
        }

        [Fact]
        public async void GetCandidates_ShouldReturnCorrectValue_WhenDataNotExisting()
        {
            var request = new GetCandidatesRequest();

            var dbData = new List<Candidate>();

            var data = new List<CandidatesViewModel>();

            _mockCandidateRepository.Setup(x => x.GetCandidatesAsync(It.IsAny<string>(), It.IsAny<DateTime?>(), It.IsAny<Guid>(), default)).ReturnsAsync(dbData);
            _mockMapper.Setup(x => x.Map<List<CandidatesViewModel>>(It.IsAny<List<Candidate>>())).Returns(data);

            GetCandidatesHandler handler = new GetCandidatesHandler(_mockCandidateRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Candidates.Count, data.Count);
        }
    }
}
