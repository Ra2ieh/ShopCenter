using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopCenter.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addagentnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "DelayQueue",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "AgentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue");

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "DelayQueue",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DelayQueue_Agent_AgentId",
                table: "DelayQueue",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "AgentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
