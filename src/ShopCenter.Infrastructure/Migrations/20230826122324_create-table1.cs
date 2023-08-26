using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createtable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Consumer",
                columns: table => new
                {
                    ConsumerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumer", x => x.ConsumerId);
                });

            migrationBuilder.CreateTable(
                name: "TripStatus",
                columns: table => new
                {
                    TripStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripStatusTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStatus", x => x.TripStatusId);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                columns: table => new
                {
                    VendorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor", x => x.VendorId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryTime = table.Column<int>(type: "int", nullable: false),
                    VendorId = table.Column<int>(type: "int", nullable: false),
                    ConsumerId = table.Column<int>(type: "int", nullable: false),
                    RegisterTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_Consumer_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumer",
                        principalColumn: "ConsumerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Vendor_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Vendor",
                        principalColumn: "VendorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Delay_Reports",
                columns: table => new
                {
                    DelayReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delay_Reports", x => x.DelayReportId);
                    table.ForeignKey(
                        name: "FK_Delay_Reports_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    TripId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TripStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.TripId);
                    table.ForeignKey(
                        name: "FK_Trip_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_TripStatus_TripStatusId",
                        column: x => x.TripStatusId,
                        principalTable: "TripStatus",
                        principalColumn: "TripStatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TripStatus",
                columns: new[] { "TripStatusId", "TripStatusTitle" },
                values: new object[,]
                {
                    { 1, "ASSIGNED" },
                    { 2, "AT_VENDOR" },
                    { 3, "PICKED" },
                    { 4, "DELIVERED" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Delay_Reports_OrderId",
                table: "Delay_Reports",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ConsumerId",
                table: "Order",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VendorId",
                table: "Order",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_OrderId",
                table: "Trip",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripStatusId",
                table: "Trip",
                column: "TripStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agent");

            migrationBuilder.DropTable(
                name: "Delay_Reports");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "TripStatus");

            migrationBuilder.DropTable(
                name: "Consumer");

            migrationBuilder.DropTable(
                name: "Vendor");
        }
    }
}
