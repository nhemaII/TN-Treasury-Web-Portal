using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN_Treasury_Web_Portal.Migrations
{
    public partial class deleteGuideSection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guide_Guide_GuideId",
                table: "Guide");

            migrationBuilder.DropTable(
                name: "GuideSection");

            migrationBuilder.DropIndex(
                name: "IX_Guide_GuideId",
                table: "Guide");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Guide");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Guide",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GuideSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuideId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuideSection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuideSection_Guide_GuideId",
                        column: x => x.GuideId,
                        principalTable: "Guide",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Guide_GuideId",
                table: "Guide",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_GuideSection_GuideId",
                table: "GuideSection",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guide_Guide_GuideId",
                table: "Guide",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id");
        }
    }
}
