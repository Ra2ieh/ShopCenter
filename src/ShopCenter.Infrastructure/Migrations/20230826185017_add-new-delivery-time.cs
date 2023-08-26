using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addnewdeliverytime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "DelayQueue",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsProgressed",
                table: "DelayQueue",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "NewDeliveryTime",
                table: "Delay_Reports",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DelayQueue_AgentId",
                table: "DelayQueue",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "AgentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue");

            migrationBuilder.DropIndex(
                name: "IX_DelayQueue_AgentId",
                table: "DelayQueue");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "DelayQueue");

            migrationBuilder.DropColumn(
                name: "IsProgressed",
                table: "DelayQueue");

            migrationBuilder.DropColumn(
                name: "NewDeliveryTime",
                table: "Delay_Reports");
        }
    }
}
