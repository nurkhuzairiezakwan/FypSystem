using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addcourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "course_ID", "course_code", "course_count", "course_desc" },
                values: new object[,]
                {
                    { 1, "SECPH", null, "Data Engineering" },
                    { 2, "SECJ", null, "Software Engineering" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "course_ID",
                keyValue: 2);
        }
    }
}
