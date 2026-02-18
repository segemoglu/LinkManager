using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkManager.Migrations
{
    /// <inheritdoc />
    public partial class AddIconColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconCssClass",
                table: "Links",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconCssClass",
                table: "Links");
        }
    }
}
