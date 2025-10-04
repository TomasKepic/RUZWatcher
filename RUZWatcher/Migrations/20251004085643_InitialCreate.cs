using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RUZWatcher.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UctovneJednotky",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NazovSubjektu = table.Column<string>(type: "TEXT", nullable: true),
                    PravnaForma = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaMesto = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaUlica = table.Column<string>(type: "TEXT", nullable: true),
                    AdresaPSC = table.Column<string>(type: "TEXT", nullable: true),
                    DatumVzniku = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Poznámka = table.Column<string>(type: "TEXT", nullable: true),
                    Hodnotenie = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UctovneJednotky", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UctovneZavierky",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUJ = table.Column<long>(type: "INTEGER", nullable: true),
                    Rok = table.Column<string>(type: "TEXT", nullable: true),
                    Typ = table.Column<string>(type: "TEXT", nullable: true),
                    LinkPdf = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UctovneZavierky", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UctovneZavierky_UctovneJednotky_IdUJ",
                        column: x => x.IdUJ,
                        principalTable: "UctovneJednotky",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UctovneZavierky_IdUJ",
                table: "UctovneZavierky",
                column: "IdUJ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UctovneZavierky");

            migrationBuilder.DropTable(
                name: "UctovneJednotky");
        }
    }
}
