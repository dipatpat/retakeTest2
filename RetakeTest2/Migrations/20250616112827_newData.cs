using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RetakeTest2.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 2 },
                column: "Amount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 3 },
                column: "Amount",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "Amount",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 2, 2 },
                column: "Amount",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Backpacks",
                keyColumns: new[] { "CharacterId", "ItemId" },
                keyValues: new object[] { 3, 3 },
                column: "Amount",
                value: 4);
        }
    }
}
