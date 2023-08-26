using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addDelayQueue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RegisterTime",
                table: "Order",
                newName: "OrderTime");

            migrationBuilder.CreateTable(
                name: "DelayQueue",
                columns: table => new
                {
                    DelayQueueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DelayQueue", x => x.DelayQueueId);
                    table.ForeignKey(
                        name: "FK_DelayQueue_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DelayQueue_OrderId",
                table: "DelayQueue",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DelayQueue");

            migrationBuilder.RenameColumn(
                name: "OrderTime",
                table: "Order",
                newName: "RegisterTime");
        }
    }
}
