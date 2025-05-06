using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class RemoveSensorId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SensorId",
                schema: "RealTime",
                table: "TagDirections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SensorId",
                schema: "RealTime",
                table: "TagDirections",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
