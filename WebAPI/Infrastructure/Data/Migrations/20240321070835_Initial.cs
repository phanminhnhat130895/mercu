using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Interviewers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExpiredDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CandidateJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    JobId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    CandidateId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    InterviewerId = table.Column<Guid>(type: "char(36)", maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateJobs_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2998), null, null, "nhat.phan1@gmail.com", "Nhat", "Phan", "0123456789" },
                    { new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2985), null, null, "nhat.phan@gmail.com", "Nhat", "Phan", "0123456789" },
                    { new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(2999), null, null, "nhat.phan2@gmail.com", "Nhat", "Phan", "0123456787" }
                });

            migrationBuilder.InsertData(
                table: "Interviewers",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3086), null, null, "robert.sanchez@gmail.com", "Robert", "Sanchez", "0123456669" },
                    { new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3082), null, null, "adam.jobs@gmail.com", "Adam", "Jobs", "0123456667" },
                    { new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3084), null, null, "jack.reacher@gmail.com", "Jack", "Reacher", "0123456668" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Description", "ExpiredDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3106), null, null, "Job 3 Description", new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3105), 1, "Job 3" },
                    { new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3105), null, null, "Job 2 Description", new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3104), 1, "Job 2" },
                    { new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3103), null, null, "Job 1 Description", new DateTime(2024, 4, 20, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3098), 1, "Job 1" }
                });

            migrationBuilder.InsertData(
                table: "CandidateJobs",
                columns: new[] { "Id", "CandidateId", "DateCreated", "DateDeleted", "DateUpdated", "InterviewerId", "JobId", "Status" },
                values: new object[,]
                {
                    { new Guid("1aa2ba4f-d8a6-48b1-b5eb-f3b243fe67f9"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3133), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), 2 },
                    { new Guid("3fdcb2fc-5512-4da6-ae86-c8ea30988128"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3145), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), 3 },
                    { new Guid("57a5fcb3-2b97-47aa-9660-b61b33d71ac9"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3135), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), 3 },
                    { new Guid("7ae2e0f2-5bda-4636-adf2-2fda93b753af"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3137), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), 1 },
                    { new Guid("8b255b63-fa73-4f4e-967d-1b9f8c0e5ed3"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3130), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), 3 },
                    { new Guid("9de59fc2-9708-4085-ac3a-42d3019f5d08"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3132), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), 0 },
                    { new Guid("c005edeb-fac9-4da0-8d24-901be3995b73"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3128), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), 1 },
                    { new Guid("e381abb7-49a6-4026-ab5c-2da60ebe717d"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3143), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), 2 },
                    { new Guid("fb2242e2-4c4e-4982-8f62-646a707c28eb"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 21, 14, 8, 34, 935, DateTimeKind.Local).AddTicks(3125), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobs_CandidateId",
                table: "CandidateJobs",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateJobs");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
