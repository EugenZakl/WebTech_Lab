using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTech_Lab.Migrations
{
    /// <inheritdoc />
    public partial class type3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoBackgroundUrl",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoBackgroundUrl",
                table: "Photos");
        }
    }
}
