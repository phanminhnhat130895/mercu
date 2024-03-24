using Application.Features.Interviewers.Queries.GetInterviewersQuery;
using Application.Repositories;
using Application.ViewModels;
using AutoMapper;
using Domain.Entities;
using Moq;

namespace WebAPI.UnitTests.Features.Interviewers.Queries.GetInterviewersTests
{
    public class GetInterviewersHandlerTests
    {
        private Mock<IInterviewerRepository> _mockInterviewerRepository;
        private Mock<IMapper> _mockMapper;

        public GetInterviewersHandlerTests()
        {
            _mockInterviewerRepository = new Mock<IInterviewerRepository>();
            _mockMapper = new Mock<IMapper>();
        }

        [Fact]
        public async void GetInterviewers_ShouldReturnCorrectValue_WhenDataExisting()
        {
            var request = new GetInterviewersRequest();

            var dbData = new List<Interviewer>()
            {
                new Interviewer(Guid.NewGuid()) { FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan@gmail.com", PhoneNumber = "0123456789", DateCreated = DateTime.Now },
                new Interviewer(Guid.NewGuid()) { FirstName = "Hang", LastName = "Truong", Email = "hang.truong@gmail.com", PhoneNumber = "0123456788", DateCreated = DateTime.Now },
                new Interviewer(Guid.NewGuid()) { FirstName = "Nam", LastName = "Nguyen", Email = "nam.nguyen@gmail.com", PhoneNumber = "0123456787", DateCreated = DateTime.Now },

            };

            var data = new List<InterviewerViewModel>()
            {
                new InterviewerViewModel() { Id = dbData[0].Id, FirstName = "Nhat", LastName = "Phan" },
                new InterviewerViewModel() { Id = dbData[1].Id, FirstName = "Hang", LastName = "Truong" },
                new InterviewerViewModel() { Id = dbData[2].Id, FirstName = "Nam", LastName = "Nguyen" }
            };

            _mockInterviewerRepository.Setup(x => x.GetInterviewersAsync(default)).ReturnsAsync(dbData);
            _mockMapper.Setup(x => x.Map<List<InterviewerViewModel>>(It.IsAny<List<Interviewer>>())).Returns(data);

            GetInterviewersHandler handler = new GetInterviewersHandler(_mockInterviewerRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Interviewers.Count, data.Count);
        }

        [Fact]
        public async void GetInterviewers_ShouldReturnCorrectValue_WhenDataNotExisting()
        {
            var request = new GetInterviewersRequest();

            var dbData = new List<Interviewer>();

            var data = new List<InterviewerViewModel>();

            _mockInterviewerRepository.Setup(x => x.GetInterviewersAsync(default)).ReturnsAsync(dbData);
            _mockMapper.Setup(x => x.Map<List<InterviewerViewModel>>(It.IsAny<List<Interviewer>>())).Returns(data);

            GetInterviewersHandler handler = new GetInterviewersHandler(_mockInterviewerRepository.Object, _mockMapper.Object);
            var result = await handler.Handle(request, default);

            Assert.NotNull(result);
            Assert.Equal(result.Interviewers.Count, data.Count);
        }
    }
}
