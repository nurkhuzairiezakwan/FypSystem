using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADStarter.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class deletePt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ProjectTypes_pt_ID",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_pt_ID",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "pt_ID",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "pt_ID",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_pt_ID",
                table: "AspNetUsers",
                column: "pt_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ProjectTypes_pt_ID",
                table: "AspNetUsers",
                column: "pt_ID",
                principalTable: "ProjectTypes",
                principalColumn: "pt_ID");
        }
    }
}
