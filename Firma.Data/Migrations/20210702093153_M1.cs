using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Firma.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pakiety",
                columns: table => new
                {
                    IdPokoju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Czas = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Posilki = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IloscOsob = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UrlZdjecia = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pakiety", x => x.IdPokoju);
                });

            migrationBuilder.CreateTable(
                name: "Pokoje",
                columns: table => new
                {
                    IdPokoju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Powierzchnia = table.Column<int>(nullable: false),
                    IloscLozek = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    IloscOsob = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UrlZdjecia = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokoje", x => x.IdPokoju);
                });

            migrationBuilder.CreateTable(
                name: "Posilki",
                columns: table => new
                {
                    IdPosilku = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaPolska = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    NazwaAngielska = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    UrlZdjecia = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posilki", x => x.IdPosilku);
                });

            migrationBuilder.CreateTable(
                name: "Rodzaj",
                columns: table => new
                {
                    IdRodzaju = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(maxLength: 15, nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rodzaj", x => x.IdRodzaju);
                });

            migrationBuilder.CreateTable(
                name: "Towar",
                columns: table => new
                {
                    IdTowaru = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Cena = table.Column<decimal>(type: "money", nullable: false),
                    UrlZdjecia = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    KrotkiOpis = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    IdRodzaju = table.Column<int>(nullable: false),
                    RodzajIdRodzaju = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towar", x => x.IdTowaru);
                    table.ForeignKey(
                        name: "FK_Towar_Rodzaj_RodzajIdRodzaju",
                        column: x => x.RodzajIdRodzaju,
                        principalTable: "Rodzaj",
                        principalColumn: "IdRodzaju",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElementKoszyka",
                columns: table => new
                {
                    IdElementuKoszyka = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSesjiKoszyka = table.Column<string>(nullable: true),
                    IdTowaru = table.Column<int>(nullable: false),
                    TowarIdTowaru = table.Column<int>(nullable: true),
                    Ilosc = table.Column<int>(nullable: false),
                    DataUtworzenia = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementKoszyka", x => x.IdElementuKoszyka);
                    table.ForeignKey(
                        name: "FK_ElementKoszyka_Towar_TowarIdTowaru",
                        column: x => x.TowarIdTowaru,
                        principalTable: "Towar",
                        principalColumn: "IdTowaru",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementKoszyka_TowarIdTowaru",
                table: "ElementKoszyka",
                column: "TowarIdTowaru");

            migrationBuilder.CreateIndex(
                name: "IX_Towar_RodzajIdRodzaju",
                table: "Towar",
                column: "RodzajIdRodzaju");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementKoszyka");

            migrationBuilder.DropTable(
                name: "Pakiety");

            migrationBuilder.DropTable(
                name: "Pokoje");

            migrationBuilder.DropTable(
                name: "Posilki");

            migrationBuilder.DropTable(
                name: "Towar");

            migrationBuilder.DropTable(
                name: "Rodzaj");
        }
    }
}
