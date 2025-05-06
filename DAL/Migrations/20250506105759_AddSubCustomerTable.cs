using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddSubCustomerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubCustomerId",
                table: "JobOrders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SubCustomers",
                schema: "Definitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DCustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubCustomers_Customers_DCustomerId",
                        column: x => x.DCustomerId,
                        principalSchema: "Definitions",
                        principalTable: "Customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobOrders_SubCustomerId",
                table: "JobOrders",
                column: "SubCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCustomers_DCustomerId",
                schema: "Definitions",
                table: "SubCustomers",
                column: "DCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobOrders_SubCustomers_SubCustomerId",
                table: "JobOrders",
                column: "SubCustomerId",
                principalSchema: "Definitions",
                principalTable: "SubCustomers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobOrders_SubCustomers_SubCustomerId",
                table: "JobOrders");

            migrationBuilder.DropTable(
                name: "SubCustomers",
                schema: "Definitions");

            migrationBuilder.DropIndex(
                name: "IX_JobOrders_SubCustomerId",
                table: "JobOrders");

            migrationBuilder.DropColumn(
                name: "SubCustomerId",
                table: "JobOrders");
        }
    }
}
