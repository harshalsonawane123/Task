using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class nodetomigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
