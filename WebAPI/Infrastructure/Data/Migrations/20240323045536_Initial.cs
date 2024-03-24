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
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_CandidateJobs_Interviewers_InterviewerId",
                        column: x => x.InterviewerId,
                        principalTable: "Interviewers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateJobs_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "LastName", "PhoneNumber", "Status" },
                values: new object[,]
                {
                    { new Guid("3116ba7e-1c7d-4469-a283-dddc812acc76"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2467), null, null, "nhi.nguyen@gmail.com", "Nhi", "Nguyen", "0123456786", 2 },
                    { new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2464), null, null, "nam.nguyen@gmail.com", "Nam", "Nguyen", "0123456789", 1 },
                    { new Guid("6e0d64ba-a4af-4306-afaa-9028dabdc5c5"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2469), null, null, "huy.nguyen@gmail.com", "Huy", "Nguyen", "0123456784", 1 },
                    { new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2452), null, null, "nhat.phan@gmail.com", "Nhat", "Phan", "0123456789", 0 },
                    { new Guid("aa9be609-2e88-40f2-8996-6e674fad71fb"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2468), null, null, "phong.van@gmail.com", "Phong", "Van", "0123456785", 0 },
                    { new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2465), null, null, "hang.truong@gmail.com", "Hang", "Truong", "0123456787", 3 }
                });

            migrationBuilder.InsertData(
                table: "Interviewers",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2559), null, null, "robert.sanchez@gmail.com", "Robert", "Sanchez", "0123456669" },
                    { new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2555), null, null, "adam.jobs@gmail.com", "Adam", "Jobs", "0123456667" },
                    { new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2557), null, null, "jack.reacher@gmail.com", "Jack", "Reacher", "0123456668" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "DateCreated", "DateDeleted", "DateUpdated", "Description", "ExpiredDate", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2580), null, null, "Job 3 Description", new DateTime(2024, 4, 22, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2580), 1, "Job 3" },
                    { new Guid("1727478b-172e-405a-a784-98d4a4db3cbf"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2579), null, null, "Job 2 Description", new DateTime(2024, 4, 22, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2578), 1, "Job 2" },
                    { new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2577), null, null, "Job 1 Description", new DateTime(2024, 4, 22, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2573), 1, "Job 1" }
                });

            migrationBuilder.InsertData(
                table: "CandidateJobs",
                columns: new[] { "Id", "CandidateId", "DateCreated", "DateDeleted", "DateUpdated", "InterviewerId", "JobId" },
                values: new object[,]
                {
                    { new Guid("1532ea6e-a51a-4b3c-bffb-399dc39c1665"), new Guid("6e0d64ba-a4af-4306-afaa-9028dabdc5c5"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2638), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") },
                    { new Guid("298611ac-9ae2-4799-a93c-6a2f11584ed8"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2609), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("2cef4eab-31cf-44ab-ba7c-dbdfa05baf96"), new Guid("aa9be609-2e88-40f2-8996-6e674fad71fb"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2635), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("351bf92a-7524-4276-b8e5-6b4cfdeec7a9"), new Guid("aa9be609-2e88-40f2-8996-6e674fad71fb"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2633), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") },
                    { new Guid("3ea2bd7c-8cb3-4d85-aebb-fa4fdaf52848"), new Guid("6e0d64ba-a4af-4306-afaa-9028dabdc5c5"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2640), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("53b74350-a351-4c8d-83b4-b80a39d42e2b"), new Guid("3116ba7e-1c7d-4469-a283-dddc812acc76"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2628), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("6a75c8d6-a0b5-41c3-840c-5bb7ee55f902"), new Guid("3116ba7e-1c7d-4469-a283-dddc812acc76"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2627), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") },
                    { new Guid("6a9b120b-e9c1-4bd2-bbff-251f914425cd"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2622), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") },
                    { new Guid("6dc147a9-2bc7-4c9c-bb4b-dafcbcaa1c67"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2603), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("86b24ec8-fb1d-491a-83a7-2dff10778a8d"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2611), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") },
                    { new Guid("8f2f528f-3ef6-4600-810d-c1383715265c"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2620), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("98ffb335-e334-4feb-8a64-92094b7b2359"), new Guid("e447210a-1e8c-47b9-b478-a9193c25e7e0"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2623), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("aa3b9534-c7d3-4708-ab09-12b0177674aa"), new Guid("aa9be609-2e88-40f2-8996-6e674fad71fb"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2630), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("b627d34f-1ee4-4f12-81db-e5510b3a60ec"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2607), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("c935f46c-1a50-49fe-9b57-ef562e4429d7"), new Guid("496818f0-f2d8-4229-99d8-90b4453a37ee"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2618), null, null, new Guid("2c6a098f-2f9b-433d-83c7-3d2459135eb5"), new Guid("0a2eb4cb-2db5-42a0-83be-e92b5b7ebd91") },
                    { new Guid("e6308d8d-67bd-4aaf-9bef-bd7bb7b75f49"), new Guid("6e0d64ba-a4af-4306-afaa-9028dabdc5c5"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2637), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("fb8a31af-c3b7-46b6-8a78-66c612cf9e65"), new Guid("3116ba7e-1c7d-4469-a283-dddc812acc76"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2625), null, null, new Guid("c862156f-66f7-469c-bcdd-5bde243da56b"), new Guid("f575d2b5-9631-487c-b3de-69f15fb2cb32") },
                    { new Guid("fcc59b50-e8e9-4b22-b11c-6aea127dec65"), new Guid("8669411c-4647-4861-9999-54ada55d1e9b"), new DateTime(2024, 3, 23, 11, 55, 35, 982, DateTimeKind.Local).AddTicks(2605), null, null, new Guid("eca9f192-dab0-4788-a1bf-462326645785"), new Guid("1727478b-172e-405a-a784-98d4a4db3cbf") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobs_CandidateId",
                table: "CandidateJobs",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobs_InterviewerId",
                table: "CandidateJobs",
                column: "InterviewerId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateJobs_JobId",
                table: "CandidateJobs",
                column: "JobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateJobs");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Interviewers");

            migrationBuilder.DropTable(
                name: "Jobs");
        }
    }
}
