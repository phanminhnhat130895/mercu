using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<CandidateJob> CandidateJobs { get; set; }
        public virtual DbSet<Interviewer> Interviewers { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate(new Guid("8669411c-4647-4861-9999-54ada55d1e9b")) { FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan@gmail.com", PhoneNumber = "0123456789", DateCreated = DateTime.Now },
                new Candidate(new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee")) { FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan1@gmail.com", PhoneNumber = "0123456789", DateCreated = DateTime.Now },
                new Candidate(new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0")) { FirstName = "Nhat", LastName = "Phan", Email = "nhat.phan2@gmail.com", PhoneNumber = "0123456787", DateCreated = DateTime.Now }
            );

            modelBuilder.Entity<Interviewer>().HasData(
                new Interviewer(new Guid("c862156f-66f7-469c-bcdd-5bde243da56b")) { FirstName = "Adam", LastName = "Jobs", Email = "adam.jobs@gmail.com", PhoneNumber = "0123456667", DateCreated = DateTime.Now },
                new Interviewer(new Guid("eca9f192-dab0-4788-a1bf-462326645785")) { FirstName = "Jack", LastName = "Reacher", Email = "jack.reacher@gmail.com", PhoneNumber = "0123456668", DateCreated = DateTime.Now },
                new Interviewer(new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5")) { FirstName = "Robert", LastName = "Sanchez", Email = "robert.sanchez@gmail.com", PhoneNumber = "0123456669", DateCreated = DateTime.Now }
            );

            modelBuilder.Entity<Job>().HasData(
                new Job(new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32")) { Title = "Job 1", Description = "Job 1 Description", ExpiredDate = DateTime.Now.AddDays(30), Status = Domain.Common.Enum.JobStatusEnum.Opening, DateCreated = DateTime.Now },
                new Job(new Guid("1727478b-172e-405a-a784-98d4a4db3cbf")) { Title = "Job 2", Description = "Job 2 Description", ExpiredDate = DateTime.Now.AddDays(30), Status = Domain.Common.Enum.JobStatusEnum.Opening, DateCreated = DateTime.Now },
                new Job(new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91")) { Title = "Job 3", Description = "Job 3 Description", ExpiredDate = DateTime.Now.AddDays(30), Status = Domain.Common.Enum.JobStatusEnum.Opening, DateCreated = DateTime.Now }
            );

            modelBuilder.Entity<CandidateJob>().HasData(
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Applied, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"), JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Interviewing, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Hired, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Applied, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"), JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Offered, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Hired, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Interviewing, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"), JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Offered, DateCreated = DateTime.Now },
                new CandidateJob(Guid.NewGuid()) { CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), Status = Domain.Common.Enum.CandidateJobStatusEnum.Hired, DateCreated = DateTime.Now }
            );
        }
    }
}
