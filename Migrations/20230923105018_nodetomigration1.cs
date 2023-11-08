using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class nodetomigration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_nodeId1",
                table: "Nodes");

            migrationBuilder.DropIndex(
                name: "IX_Nodes_nodeId1",
                table: "Nodes");

            migrationBuilder.DropColumn(
                name: "nodeId1",
                table: "Nodes");

            migrationBuilder.AlterColumn<int>(
                name: "parentNodeId",
                table: "Nodes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "parentNodeId",
                table: "Nodes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nodeId1",
                table: "Nodes",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Nodes_nodeId1",
                table: "Nodes",
                column: "nodeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_nodeId1",
                table: "Nodes",
                column: "nodeId1",
                principalTable: "Nodes",
                principalColumn: "nodeId");
        }
    }
}
