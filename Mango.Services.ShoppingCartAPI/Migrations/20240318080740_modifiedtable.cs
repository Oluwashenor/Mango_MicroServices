using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mango.Services.ShoppingCartAPI.Migrations
{
    /// <inheritdoc />
    public partial class modifiedtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CardHeaders_CartHeaderId",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardHeaders",
                table: "CardHeaders");

            migrationBuilder.RenameTable(
                name: "CardHeaders",
                newName: "CartHeaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartHeaders",
                table: "CartHeaders",
                column: "CartHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails",
                column: "CartHeaderId",
                principalTable: "CartHeaders",
                principalColumn: "CartHeaderId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartDetails_CartHeaders_CartHeaderId",
                table: "CartDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartHeaders",
                table: "CartHeaders");

            migrationBuilder.RenameTable(
                name: "CartHeaders",
                newName: "CardHeaders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardHeaders",
                table: "CardHeaders",
                column: "CartHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetails_CardHeaders_CartHeaderId",
                table: "CartDetails",
                column: "CartHeaderId",
                principalTable: "CardHeaders",
                principalColumn: "CartHeaderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
