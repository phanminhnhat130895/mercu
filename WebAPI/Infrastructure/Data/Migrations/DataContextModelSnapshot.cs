﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Candidate", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Candidates");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2985),
                            Email = "nhat.phan@gmail.com",
                            FirstName = "Nhat",
                            LastName = "Phan",
                            PhoneNumber = "0123456789"
                        },
                        new
                        {
                            Id = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2998),
                            Email = "nhat.phan1@gmail.com",
                            FirstName = "Nhat",
                            LastName = "Phan",
                            PhoneNumber = "0123456789"
                        },
                        new
                        {
                            Id = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2999),
                            Email = "nhat.phan2@gmail.com",
                            FirstName = "Nhat",
                            LastName = "Phan",
                            PhoneNumber = "0123456787"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CandidateJob", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CandidateId")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("InterviewerId")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)");

                    b.Property<Guid>("JobId")
                        .HasMaxLength(36)
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CandidateId");

                    b.ToTable("CandidateJobs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb2242e2-4c4e-4982-8f62-646a707c28eb"),
                            CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3125),
                            InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"),
                            JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"),
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("c005edeb-fac9-4da0-8d24-901be3995b73"),
                            CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3128),
                            InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"),
                            JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("8b255b63-fa73-4f4e-967d-1b9f8c0e5ed3"),
                            CandidateId = new Guid("8669411c-4647-4861-9999-54ada55d1e9b"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3130),
                            InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"),
                            JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"),
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("9de59fc2-9708-4085-ac3a-42d3019f5d08"),
                            CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3132),
                            InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"),
                            JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"),
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("1aa2ba4f-d8a6-48b1-b5eb-f3b243fe67f9"),
                            CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3133),
                            InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"),
                            JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"),
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("57a5fcb3-2b97-47aa-9660-b61b33d71ac9"),
                            CandidateId = new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3135),
                            InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"),
                            JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"),
                            Status = 3
                        },
                        new
                        {
                            Id = new Guid("7ae2e0f2-5bda-4636-adf2-2fda93b753af"),
                            CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3137),
                            InterviewerId = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"),
                            JobId = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"),
                            Status = 1
                        },
                        new
                        {
                            Id = new Guid("e381abb7-49a6-4026-ab5c-2da60ebe717d"),
                            CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3143),
                            InterviewerId = new Guid("eca9f192-dab0-4788-a1bf-462326645785"),
                            JobId = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"),
                            Status = 2
                        },
                        new
                        {
                            Id = new Guid("3fdcb2fc-5512-4da6-ae86-c8ea30988128"),
                            CandidateId = new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3145),
                            InterviewerId = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"),
                            JobId = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"),
                            Status = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.Interviewer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Interviewers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3082),
                            Email = "adam.jobs@gmail.com",
                            FirstName = "Adam",
                            LastName = "Jobs",
                            PhoneNumber = "0123456667"
                        },
                        new
                        {
                            Id = new Guid("eca9f192-dab0-4788-a1bf-462326645785"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3084),
                            Email = "jack.reacher@gmail.com",
                            FirstName = "Jack",
                            LastName = "Reacher",
                            PhoneNumber = "0123456668"
                        },
                        new
                        {
                            Id = new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3086),
                            Email = "robert.sanchez@gmail.com",
                            FirstName = "Robert",
                            LastName = "Sanchez",
                            PhoneNumber = "0123456669"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3103),
                            Description = "Job 1 Description",
                            ExpiredDate = new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3098),
                            Status = 1,
                            Title = "Job 1"
                        },
                        new
                        {
                            Id = new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3105),
                            Description = "Job 2 Description",
                            ExpiredDate = new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3104),
                            Status = 1,
                            Title = "Job 2"
                        },
                        new
                        {
                            Id = new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"),
                            DateCreated = new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3106),
                            Description = "Job 3 Description",
                            ExpiredDate = new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3105),
                            Status = 1,
                            Title = "Job 3"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CandidateJob", b =>
                {
                    b.HasOne("Domain.Entities.Candidate", null)
                        .WithMany("Jobs")
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Candidate", b =>
                {
                    b.Navigation("Jobs");
                });
#pragma warning restore 612, 618
        }
    }
}