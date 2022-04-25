using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC4.Migrations
{
    public partial class studentCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    Std_id = table.Column<int>(type: "int", nullable: false),
                    Crs_id = table.Column<int>(type: "int", nullable: false),
                    grade = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => new { x.Std_id, x.Crs_id });
                    table.ForeignKey(
                        name: "FK_StudentCourse_Courses_Crs_id",
                        column: x => x.Crs_id,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Students_Std_id",
                        column: x => x.Std_id,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_Crs_id",
                table: "StudentCourse",
                column: "Crs_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCourse");
        }
    }
}
