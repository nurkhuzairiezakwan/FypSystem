using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class allowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "course_ID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers",
                column: "course_ID",
                principalTable: "Courses",
                principalColumn: "course_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "course_ID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers",
                column: "course_ID",
                principalTable: "Courses",
                principalColumn: "course_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
