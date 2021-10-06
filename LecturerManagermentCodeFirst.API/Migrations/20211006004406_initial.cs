using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LecturerManagermentCodeFirst.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DynamicClassFactors",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FromDynamic = table.Column<int>(type: "int", nullable: true),
                    ToDynamic = table.Column<int>(type: "int", nullable: true),
                    Coefficient = table.Column<double>(type: "float", nullable: false),
                    TeachesForm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicClassFactors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountPercent = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StandardTimes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardTimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectDepartments",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectDepartments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectTypes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSystems",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfLearningUnit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSystems", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Lecturers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StandardTimeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubjectDepartmentID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdentityCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Portrait = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AcademicLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PositionID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    YearStartWork = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lecturers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lecturers_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_StandardTimes_StandardTimeID",
                        column: x => x.StandardTimeID,
                        principalTable: "StandardTimes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lecturers_SubjectDepartments_SubjectDepartmentID",
                        column: x => x.SubjectDepartmentID,
                        principalTable: "SubjectDepartments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingSystemID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfStudent = table.Column<int>(type: "int", nullable: true),
                    FormsOfTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Classes_TrainingSystems_TrainingSystemID",
                        column: x => x.TrainingSystemID,
                        principalTable: "TrainingSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrainingSystemID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubjectTypeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantityUnit = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Subjects_SubjectTypes_SubjectTypeID",
                        column: x => x.SubjectTypeID,
                        principalTable: "SubjectTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_TrainingSystems_TrainingSystemID",
                        column: x => x.TrainingSystemID,
                        principalTable: "TrainingSystems",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.UserName);
                    table.ForeignKey(
                        name: "FK_Accounts_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AdvancedLearnings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvancedLearnings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AdvancedLearnings_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LecturerScientificResearches",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LevelOfResearch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfResearchParticipation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerScientificResearches", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LecturerScientificResearches_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MachineRooms",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    QantityRoom = table.Column<int>(type: "int", nullable: false),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineRooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MachineRooms_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ScientificResearchGuides",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    StudentYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScientificResearchGuides", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ScientificResearchGuides_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GraduationTheses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LecturerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TopicNumbers = table.Column<int>(type: "int", nullable: true),
                    RebuttalProjectNumbers = table.Column<int>(type: "int", nullable: true),
                    MarkSessionNumbers = table.Column<int>(type: "int", nullable: true),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GraduationTheses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GraduationTheses_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GraduationTheses_Lecturers_LecturerID",
                        column: x => x.LecturerID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachings",
                columns: table => new
                {
                    LectureID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClassID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NumberOfStudents = table.Column<int>(type: "int", nullable: false),
                    SchoolYear = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachings", x => new { x.SubjectID, x.LectureID, x.ClassID });
                    table.ForeignKey(
                        name: "FK_Teachings_Classes_ClassID",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachings_Lecturers_LectureID",
                        column: x => x.LectureID,
                        principalTable: "Lecturers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Teachings_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_LecturerID",
                table: "Accounts",
                column: "LecturerID",
                unique: true,
                filter: "[LecturerID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AdvancedLearnings_LecturerID",
                table: "AdvancedLearnings",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TrainingSystemID",
                table: "Classes",
                column: "TrainingSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationTheses_ClassID",
                table: "GraduationTheses",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_GraduationTheses_LecturerID",
                table: "GraduationTheses",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_PositionID",
                table: "Lecturers",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_StandardTimeID",
                table: "Lecturers",
                column: "StandardTimeID");

            migrationBuilder.CreateIndex(
                name: "IX_Lecturers_SubjectDepartmentID",
                table: "Lecturers",
                column: "SubjectDepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerScientificResearches_LecturerID",
                table: "LecturerScientificResearches",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_MachineRooms_LecturerID",
                table: "MachineRooms",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_ScientificResearchGuides_LecturerID",
                table: "ScientificResearchGuides",
                column: "LecturerID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectTypeID",
                table: "Subjects",
                column: "SubjectTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TrainingSystemID",
                table: "Subjects",
                column: "TrainingSystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_ClassID",
                table: "Teachings",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_Teachings_LectureID",
                table: "Teachings",
                column: "LectureID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AdvancedLearnings");

            migrationBuilder.DropTable(
                name: "DynamicClassFactors");

            migrationBuilder.DropTable(
                name: "GraduationTheses");

            migrationBuilder.DropTable(
                name: "LecturerScientificResearches");

            migrationBuilder.DropTable(
                name: "MachineRooms");

            migrationBuilder.DropTable(
                name: "ScientificResearchGuides");

            migrationBuilder.DropTable(
                name: "Teachings");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Lecturers");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "StandardTimes");

            migrationBuilder.DropTable(
                name: "SubjectDepartments");

            migrationBuilder.DropTable(
                name: "SubjectTypes");

            migrationBuilder.DropTable(
                name: "TrainingSystems");
        }
    }
}
