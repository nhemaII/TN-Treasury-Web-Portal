using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TN_Treasury_Web_Portal.Migrations
{
    public partial class AddSectionContent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "GuideSection",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "GuideSection");
        }
    }
}
