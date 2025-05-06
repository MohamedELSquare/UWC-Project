using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddJobOrderWithPalletTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationCustomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Palletss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DWarehouseId = table.Column<int>(type: "int", nullable: true),
                    JobOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Palletss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Palletss_JobOrders_JobOrderId",
                        column: x => x.JobOrderId,
                        principalTable: "JobOrders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Palletss_Warehouses_DWarehouseId",
                        column: x => x.DWarehouseId,
                        principalSchema: "Definitions",
                        principalTable: "Warehouses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Palletss_DWarehouseId",
                table: "Palletss",
                column: "DWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Palletss_JobOrderId",
                table: "Palletss",
                column: "JobOrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Palletss");

            migrationBuilder.DropTable(
                name: "JobOrders");
        }
    }
}
