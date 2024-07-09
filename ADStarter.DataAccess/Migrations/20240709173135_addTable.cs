using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    s_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    s_user = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_evaluator1 = table.Column<int>(type: "int", nullable: false),
                    s_evaluator2 = table.Column<int>(type: "int", nullable: false),
                    s_SV = table.Column<int>(type: "int", nullable: false),
                    s_statusSV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_academic_session = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_semester = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    s_SVagreement = table.Column<bool>(type: "bit", nullable: false),
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
                    p_title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    p_file = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    st_id = table.Column<int>(type: "int", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Proposals_Students_id",
                table: "Proposals",
                column: "Students_id");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Proposals");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
