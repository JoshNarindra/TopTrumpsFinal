using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TopTrumpsFinal.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatDeck",
                columns: table => new
                {
                    CatDeckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    GoodTemper = table.Column<int>(type: "int", nullable: false),
                    Cuteness = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatDeck", x => x.CatDeckID);
                });

            migrationBuilder.CreateTable(
                name: "DinoDeck",
                columns: table => new
                {
                    DinoDeckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    GoodTemper = table.Column<double>(type: "float", nullable: false),
                    KillerRating = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DinoDeck", x => x.DinoDeckID);
                });

            migrationBuilder.CreateTable(
                name: "DogDeck",
                columns: table => new
                {
                    DogDeckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Rarity = table.Column<int>(type: "int", nullable: false),
                    GoodTemper = table.Column<int>(type: "int", nullable: false),
                    Cuteness = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogDeck", x => x.DogDeckID);
                });

            migrationBuilder.CreateTable(
                name: "StarWarsDeck",
                columns: table => new
                {
                    StarWarsDeckID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    FirePower = table.Column<int>(type: "int", nullable: false),
                    Maneuvering = table.Column<int>(type: "int", nullable: false),
                    ForceFactor = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarWarsDeck", x => x.StarWarsDeckID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatDeck");

            migrationBuilder.DropTable(
                name: "DinoDeck");

            migrationBuilder.DropTable(
                name: "DogDeck");

            migrationBuilder.DropTable(
                name: "StarWarsDeck");
        }
    }
}
