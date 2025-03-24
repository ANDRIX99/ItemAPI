using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ItemAPI.Migrations
{
    /// <inheritdoc />
    public partial class ItemDetailRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<float>(type: "real", nullable: true),
                    IdItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDetails_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetails",
                column: "ItemId",
                unique: true,
                filter: "[ItemId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemDetails");
        }
    }
}
