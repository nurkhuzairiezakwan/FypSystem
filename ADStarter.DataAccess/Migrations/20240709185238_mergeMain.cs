using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mergeMain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "course_ID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pt_ID",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_IC",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_contact",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_matric",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_count = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    course_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.course_ID);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    pt_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pt_desc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.pt_ID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    s_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_evaluator1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_evaluator2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_SV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_statusSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_academic_session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_SVagreement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.s_id);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Proposals",
                columns: table => new
                {
                    p_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_id = table.Column<int>(type: "int", nullable: false),
                    p_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_file = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    st_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    p_sv_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_evaluator1_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_evaluator2_comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Students_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proposals", x => x.p_id);
                    table.ForeignKey(
                        name: "FK_Proposals_Students_Students_id",
                        column: x => x.Students_id,
                        principalTable: "Students",
                        principalColumn: "s_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "course_ID", "course_code", "course_count", "course_desc" },
                values: new object[,]
                {
                    { 1, "SECPH", "41", "Data Engineering" },
                    { 2, "SECJ", "41", "Software Engineering" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_course_ID",
                table: "AspNetUsers",
                column: "course_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_pt_ID",
                table: "AspNetUsers",
                column: "pt_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_Students_id",
                table: "Proposals",
                column: "Students_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers",
                column: "course_ID",
                principalTable: "Courses",
                principalColumn: "course_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectTypes_pt_ID",
                table: "AspNetUsers",
                column: "pt_ID",
                principalTable: "ProjectTypes",
                principalColumn: "pt_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Courses_course_ID",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectTypes_pt_ID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_course_ID",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_pt_ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "course_ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "pt_ID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_IC",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_contact",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_matric",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "AspNetUsers");
        }
    }
}
