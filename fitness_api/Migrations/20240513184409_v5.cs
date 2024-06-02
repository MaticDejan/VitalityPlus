using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Application.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Antrenament",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calorii = table.Column<float>(type: "real", nullable: false),
                    idUtilizator = table.Column<int>(type: "int", nullable: false),
                    idCreator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Antrenament", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exercitiu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    caloriiPer10Minute = table.Column<float>(type: "real", nullable: true),
                    caloriiPerRepetare = table.Column<float>(type: "real", nullable: true),
                    imagine = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    selectat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exercitiu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExercitiuEfort",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idExercitiu = table.Column<int>(type: "int", nullable: false),
                    idAntrenament = table.Column<int>(type: "int", nullable: false),
                    timp = table.Column<int>(type: "int", nullable: false),
                    serii = table.Column<int>(type: "int", nullable: false),
                    repetari = table.Column<int>(type: "int", nullable: false),
                    greutati = table.Column<int>(type: "int", nullable: false),
                    anduranta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercitiuEfort", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Antrenament");

            migrationBuilder.DropTable(
                name: "Exercitiu");

            migrationBuilder.DropTable(
                name: "ExercitiuEfort");
        }
    }
}
