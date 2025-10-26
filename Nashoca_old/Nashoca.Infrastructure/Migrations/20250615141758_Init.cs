using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nashoca.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VerbsEn",
                columns: table => new
                {
                    VenSymbol = table.Column<string>(type: "CHAR(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenMainF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenPrefP = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenMinF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenPastF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenPpastF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenAdd = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VenExc = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbsEn", x => x.VenSymbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VerbsTr",
                columns: table => new
                {
                    VtrSymbol = table.Column<string>(type: "CHAR(5)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrPrefP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrMainF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrMinF = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrChgL = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrAoristS = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtrCase = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbsTr", x => x.VtrSymbol);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VerbsTrans",
                columns: table => new
                {
                    VtId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtEn = table.Column<string>(type: "CHAR(5)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtGr = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtPl = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtRu = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VtTr = table.Column<string>(type: "CHAR(5)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbsTrans", x => x.VtId);
                    table.ForeignKey(
                        name: "FK_VerbsTrans_VerbsEn_VtEn",
                        column: x => x.VtEn,
                        principalTable: "VerbsEn",
                        principalColumn: "VenSymbol",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VerbsTrans_VerbsTr_VtTr",
                        column: x => x.VtTr,
                        principalTable: "VerbsTr",
                        principalColumn: "VtrSymbol",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_VerbsTrans_VtEn",
                table: "VerbsTrans",
                column: "VtEn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VerbsTrans_VtTr",
                table: "VerbsTrans",
                column: "VtTr",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VerbsTrans");

            migrationBuilder.DropTable(
                name: "VerbsEn");

            migrationBuilder.DropTable(
                name: "VerbsTr");
        }
    }
}
