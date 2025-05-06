using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class editdirection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                schema: "RealTime",
                table: "TagDirections");

            migrationBuilder.RenameColumn(
                name: "To",
                schema: "RealTime",
                table: "TagDirections",
                newName: "Direction");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Direction",
                schema: "RealTime",
                table: "TagDirections",
                newName: "To");

            migrationBuilder.AddColumn<string>(
                name: "From",
                schema: "RealTime",
                table: "TagDirections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
