using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN_Treasury_Web_Portal.Migrations
{
    public partial class AddGuides : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuideSection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GuideId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_GuideSection_GuideId",
                table: "GuideSection",
                column: "GuideId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuideSection");

            migrationBuilder.DropTable(
                name: "Guide");
        }
    }
}
