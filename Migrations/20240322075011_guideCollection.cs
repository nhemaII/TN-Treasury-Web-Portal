using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN_Treasury_Web_Portal.Migrations
{
    public partial class guideCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Guide",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guide_GuideId",
                table: "Guide",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guide_Guide_GuideId",
                table: "Guide",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guide_Guide_GuideId",
                table: "Guide");

            migrationBuilder.DropIndex(
                name: "IX_Guide_GuideId",
                table: "Guide");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Guide");
        }
    }
}
