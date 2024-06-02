using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Application.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "anduranta",
                table: "Exercitiu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "greutati",
                table: "Exercitiu",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "anduranta",
                table: "Exercitiu");

            migrationBuilder.DropColumn(
                name: "greutati",
                table: "Exercitiu");
        }
    }
}
