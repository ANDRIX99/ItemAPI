using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemAPI.Migrations
{
    /// <inheritdoc />
    public partial class tableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
        }
    }
}
