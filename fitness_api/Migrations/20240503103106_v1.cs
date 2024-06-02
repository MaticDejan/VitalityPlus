using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fitness_Application.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meniuri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idProduseGramaje = table.Column<int>(type: "int", nullable: false),
                    idUtilizator = table.Column<int>(type: "int", nullable: false),
                    idCreator = table.Column<int>(type: "int", nullable: false),
                    kcal = table.Column<float>(type: "real", nullable: false),
                    proteine = table.Column<float>(type: "real", nullable: false),
                    carboohidrati = table.Column<float>(type: "real", nullable: false),
                    zahar = table.Column<float>(type: "real", nullable: false),
                    grasimi = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meniuri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categorie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prajit = table.Column<int>(type: "int", nullable: false),
                    fiert = table.Column<int>(type: "int", nullable: false),
                    proteine = table.Column<float>(type: "real", nullable: false),
                    carbohidrati = table.Column<float>(type: "real", nullable: false),
                    grasimi = table.Column<float>(type: "real", nullable: false),
                    zahar = table.Column<float>(type: "real", nullable: false),
                    kcal = table.Column<float>(type: "real", nullable: false),
                    proteineFiert = table.Column<float>(type: "real", nullable: true),
                    carbohidratiFiert = table.Column<float>(type: "real", nullable: true),
                    grasimiFiert = table.Column<float>(type: "real", nullable: true),
                    zaharFiert = table.Column<float>(type: "real", nullable: true),
                    kcalFiert = table.Column<float>(type: "real", nullable: true),
                    proteinePrajit = table.Column<float>(type: "real", nullable: true),
                    carbohidratiPrajit = table.Column<float>(type: "real", nullable: true),
                    grasimiPrajit = table.Column<float>(type: "real", nullable: true),
                    zaharPrajit = table.Column<float>(type: "real", nullable: true),
                    kcalPrajit = table.Column<float>(type: "real", nullable: true),
                    imagine = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    selectat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdusGramaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProdus = table.Column<int>(type: "int", nullable: false),
                    gramaj = table.Column<float>(type: "real", nullable: false),
                    idMeniu = table.Column<int>(type: "int", nullable: false),
                    prajit = table.Column<int>(type: "int", nullable: false),
                    fiert = table.Column<int>(type: "int", nullable: false),
                    crud = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdusGramaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Greutate = table.Column<float>(type: "real", nullable: true),
                    Inaltime = table.Column<int>(type: "int", nullable: true),
                    Varsta = table.Column<int>(type: "int", nullable: true),
                    Activitate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Antrenor = table.Column<int>(type: "int", nullable: true),
                    idAntrenor = table.Column<int>(type: "int", nullable: true),
                    talie = table.Column<float>(type: "real", nullable: true),
                    gat = table.Column<float>(type: "real", nullable: true),
                    antebrat = table.Column<float>(type: "real", nullable: true),
                    coapsa = table.Column<float>(type: "real", nullable: true),
                    sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    indiceMasaCorporala = table.Column<float>(type: "real", nullable: true),
                    procentDeGrasime = table.Column<float>(type: "real", nullable: true),
                    greutateIdeala = table.Column<float>(type: "real", nullable: true),
                    necesarCaloric = table.Column<float>(type: "real", nullable: true),
                    Admin = table.Column<bool>(type: "bit", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activ = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meniuri");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "ProdusGramaje");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
