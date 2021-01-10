using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleCommands.WebAPI.Migrations
{
    public partial class InitialDataLoading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "edu");

            migrationBuilder.EnsureSchema(
                name: "b2c");

            migrationBuilder.CreateSequence<int>(
                name: "NationalIndentificationSequence",
                startValue: 1010101L,
                incrementBy: 137);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false, defaultValueSql: "NEXT VALUE FOR NationalIndentificationSequence"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Nationality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "B2C_Customer",
                schema: "b2c",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modified_By = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    Created_By = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Date_Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Middle_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Citizenship_Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Loyalty_Member = table.Column<bool>(type: "bit", nullable: true),
                    EmploymentStatus = table.Column<int>(nullable: false),
                    Email_Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(type: "decimal (18,2)", nullable: true),
                    Credit_Score = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_B2C_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "EDU_Course",
                schema: "edu",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Course_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Course_Number = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Course_Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDU_Course", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "EDU_Student",
                schema: "edu",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Middle_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date_of_Birth = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EDU_Student", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentCourses_EDU_Course_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "edu",
                        principalTable: "EDU_Course",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_EDU_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "edu",
                        principalTable: "EDU_Student",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "B2C_Customer",
                schema: "b2c");

            migrationBuilder.DropTable(
                name: "EDU_Course",
                schema: "edu");

            migrationBuilder.DropTable(
                name: "EDU_Student",
                schema: "edu");

            migrationBuilder.DropSequence(
                name: "NationalIndentificationSequence");
        }
    }
}
