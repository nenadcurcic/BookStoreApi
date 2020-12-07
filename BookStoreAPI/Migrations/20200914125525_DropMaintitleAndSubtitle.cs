using Microsoft.EntityFrameworkCore.Migrations;

namespace BookStoreAPI.Migrations
{
    public partial class DropMaintitleAndSubtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Books",
                nullable: true);

            migrationBuilder.Sql(@"Update Books set Title = MainTitle + ' : ' + SubTitle");

            migrationBuilder.DropColumn(
                name: "MainTitle",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "SubTitle",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "MainTitle",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubTitle",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}