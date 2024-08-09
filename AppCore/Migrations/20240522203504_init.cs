using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppCore.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Auditoriums",
                columns: table => new
                {
                    AuditoriumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auditoriums", x => x.AuditoriumId);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInstitutions",
                columns: table => new
                {
                    EducationalInstitutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalInstitutionType = table.Column<int>(type: "int", nullable: true),
                    ParentEducationalInstitutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitutions", x => x.EducationalInstitutionId);
                    table.ForeignKey(
                        name: "FK_EducationalInstitutions_EducationalInstitutions_ParentEducationalInstitutionId",
                        column: x => x.ParentEducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId");
                });

            migrationBuilder.CreateTable(
                name: "Specialities",
                columns: table => new
                {
                    SpecialityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    EducationalInstitutionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialities", x => x.SpecialityId);
                    table.ForeignKey(
                        name: "FK_Specialities_EducationalInstitutions_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationalInstitutionId = table.Column<int>(type: "int", nullable: false),
                    AdministrationFunction = table.Column<int>(type: "int", nullable: true),
                    ChiefId = table.Column<int>(type: "int", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    IDNP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.PersonId);
                    table.CheckConstraint("CK_Teachers_IDNP", "LEN(IDNP) = 13 AND IDNP NOT LIKE '%[^0-9]%'");
                    table.ForeignKey(
                        name: "FK_Teachers_EducationalInstitutions_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeDistributions",
                columns: table => new
                {
                    TimeDistributionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PairNumber = table.Column<int>(type: "int", nullable: false),
                    Begin = table.Column<TimeSpan>(type: "TIME(0)", nullable: false),
                    End = table.Column<TimeSpan>(type: "TIME(0)", nullable: false),
                    EducationalInstitutionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeDistributions", x => x.TimeDistributionId);
                    table.CheckConstraint("CK_TimeDistributions_Begin_End", "[Begin] < [End]");
                    table.ForeignKey(
                        name: "FK_TimeDistributions_EducationalInstitutions_EducationalInstitutionId",
                        column: x => x.EducationalInstitutionId,
                        principalTable: "EducationalInstitutions",
                        principalColumn: "EducationalInstitutionId");
                });

            migrationBuilder.CreateTable(
                name: "AcademicGroups",
                columns: table => new
                {
                    AcademicGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    StudyYear = table.Column<int>(type: "int", nullable: true),
                    SpecialityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicGroups", x => x.AcademicGroupId);
                    table.ForeignKey(
                        name: "FK_AcademicGroups_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId");
                });

            migrationBuilder.CreateTable(
                name: "Disciplines",
                columns: table => new
                {
                    DisciplineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TotalHours = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    DirectContactHours = table.Column<int>(type: "int", nullable: false),
                    IndividualStudyHours = table.Column<int>(type: "int", nullable: false),
                    CourseHours = table.Column<int>(type: "int", nullable: false),
                    SeminarHours = table.Column<int>(type: "int", nullable: false),
                    PracticalWorkHours = table.Column<int>(type: "int", nullable: false),
                    ProjectHours = table.Column<int>(type: "int", nullable: false),
                    EvaluationForm = table.Column<int>(type: "int", nullable: false),
                    SpecialityId = table.Column<int>(type: "int", nullable: false),
                    ECTS = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplines", x => x.DisciplineId);
                    table.ForeignKey(
                        name: "FK_Disciplines_Specialities_SpecialityId",
                        column: x => x.SpecialityId,
                        principalTable: "Specialities",
                        principalColumn: "SpecialityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LivesInADorm = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    FinancingForm = table.Column<int>(type: "int", nullable: true),
                    AcademicGroupId = table.Column<int>(type: "int", nullable: false),
                    IDNP = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Students_AcademicGroups_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "AcademicGroups",
                        principalColumn: "AcademicGroupId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pairs",
                columns: table => new
                {
                    PairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PairNumber = table.Column<int>(type: "int", nullable: true),
                    PairType = table.Column<int>(type: "int", nullable: true),
                    DisciplineId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true),
                    AuditoriumId = table.Column<int>(type: "int", nullable: true),
                    WeekDay = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pairs", x => x.PairId);
                    table.ForeignKey(
                        name: "FK_Pairs_Auditoriums_AuditoriumId",
                        column: x => x.AuditoriumId,
                        principalTable: "Auditoriums",
                        principalColumn: "AuditoriumId");
                    table.ForeignKey(
                        name: "FK_Pairs_Disciplines_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Disciplines",
                        principalColumn: "DisciplineId");
                    table.ForeignKey(
                        name: "FK_Pairs_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "PersonId");
                });

            migrationBuilder.CreateTable(
                name: "Attendance",
                columns: table => new
                {
                    AttendanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PairId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance", x => x.AttendanceId);
                    table.ForeignKey(
                        name: "FK_Attendance_Pairs_PairId",
                        column: x => x.PairId,
                        principalTable: "Pairs",
                        principalColumn: "PairId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Students_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Students",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PairAcademicGroup",
                columns: table => new
                {
                    PairId = table.Column<int>(type: "int", nullable: false),
                    AcademicGroupId = table.Column<int>(type: "int", nullable: false),
                    PairAcademicGroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PairAcademicGroup", x => new { x.PairId, x.AcademicGroupId });
                    table.ForeignKey(
                        name: "FK_PairAcademicGroup_AcademicGroups_AcademicGroupId",
                        column: x => x.AcademicGroupId,
                        principalTable: "AcademicGroups",
                        principalColumn: "AcademicGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PairAcademicGroup_Pairs_PairId",
                        column: x => x.PairId,
                        principalTable: "Pairs",
                        principalColumn: "PairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_Name",
                table: "AcademicGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AcademicGroups_SpecialityId",
                table: "AcademicGroups",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PairId",
                table: "Attendance",
                column: "PairId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_PersonId_Date_PairId",
                table: "Attendance",
                columns: new[] { "PersonId", "Date", "PairId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_SpecialityId",
                table: "Disciplines",
                column: "SpecialityId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalInstitutions_ParentEducationalInstitutionId",
                table: "EducationalInstitutions",
                column: "ParentEducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_PairAcademicGroup_AcademicGroupId",
                table: "PairAcademicGroup",
                column: "AcademicGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_AuditoriumId",
                table: "Pairs",
                column: "AuditoriumId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_DisciplineId",
                table: "Pairs",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_PairNumber_AuditoriumId_WeekDay",
                table: "Pairs",
                columns: new[] { "PairNumber", "AuditoriumId", "WeekDay" },
                unique: true,
                filter: "[PairNumber] IS NOT NULL AND [AuditoriumId] IS NOT NULL AND [WeekDay] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_PairNumber_WeekDay_TeacherId",
                table: "Pairs",
                columns: new[] { "PairNumber", "WeekDay", "TeacherId" },
                unique: true,
                filter: "[PairNumber] IS NOT NULL AND [WeekDay] IS NOT NULL AND [TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Pairs_TeacherId",
                table: "Pairs",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Specialities_EducationalInstitutionId",
                table: "Specialities",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AcademicGroupId",
                table: "Students",
                column: "AcademicGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Email",
                table: "Students",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_IDNP",
                table: "Students",
                column: "IDNP",
                unique: true,
                filter: "[IDNP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Students_Phone",
                table: "Students",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_EducationalInstitutionId",
                table: "Teachers",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Email",
                table: "Teachers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_IDNP",
                table: "Teachers",
                column: "IDNP",
                unique: true,
                filter: "[IDNP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_Phone",
                table: "Teachers",
                column: "Phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeDistributions_EducationalInstitutionId",
                table: "TimeDistributions",
                column: "EducationalInstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_TimeDistributions_PairNumber_EducationalInstitutionId",
                table: "TimeDistributions",
                columns: new[] { "PairNumber", "EducationalInstitutionId" },
                unique: true,
                filter: "[EducationalInstitutionId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance");

            migrationBuilder.DropTable(
                name: "PairAcademicGroup");

            migrationBuilder.DropTable(
                name: "TimeDistributions");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Pairs");

            migrationBuilder.DropTable(
                name: "AcademicGroups");

            migrationBuilder.DropTable(
                name: "Auditoriums");

            migrationBuilder.DropTable(
                name: "Disciplines");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Specialities");

            migrationBuilder.DropTable(
                name: "EducationalInstitutions");
        }
    }
}
