using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebTech_Lab.Migrations
{
    /// <inheritdoc />
    public partial class type2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EnemyDescription",
                table: "Enemies",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnemyDescription",
                table: "Enemies");
        }
    }
}
