using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcoursecount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 1,
                column: "course_count",
                value: "41");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 2,
                column: "course_count",
                value: "41");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 1,
                column: "course_count",
                value: null);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 2,
                column: "course_count",
                value: null);
        }
    }
}
