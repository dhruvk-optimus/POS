using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POS.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemovedRowVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "Items");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "Items",
                type: "rowversion",
                rowVersion: true,
                nullable: true);
        }
    }
}
