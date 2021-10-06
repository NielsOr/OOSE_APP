using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialDBCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Evls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Studiepunten = table.Column<double>(type: "float", nullable: false),
                    Beroepstaken = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Eindkwalificaties = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leeruitkomsten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    EvlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leeruitkomsten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Leeruitkomsten_Evls_EvlId",
                        column: x => x.EvlId,
                        principalTable: "Evls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tentamineringen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aanmeldingstype = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Hulpmiddelen = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Weging = table.Column<int>(type: "int", nullable: false),
                    MinimaalOordeel = table.Column<double>(type: "float", maxLength: 100, nullable: false),
                    Tentamenvorm = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EvlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tentamineringen", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tentamineringen_Evls_EvlId",
                        column: x => x.EvlId,
                        principalTable: "Evls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beoordelingsdimensies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weging = table.Column<int>(type: "int", nullable: false),
                    MinimaalOordeel = table.Column<double>(type: "float", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    TentamineringId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beoordelingsdimensies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beoordelingsdimensies_Tentamineringen_TentamineringId",
                        column: x => x.TentamineringId,
                        principalTable: "Tentamineringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeeruitkomstTentaminering",
                columns: table => new
                {
                    LeeruitkomstenId = table.Column<int>(type: "int", nullable: false),
                    TentamineringenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeeruitkomstTentaminering", x => new { x.LeeruitkomstenId, x.TentamineringenId });
                    table.ForeignKey(
                        name: "FK_LeeruitkomstTentaminering_Leeruitkomsten_LeeruitkomstenId",
                        column: x => x.LeeruitkomstenId,
                        principalTable: "Leeruitkomsten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LeeruitkomstTentaminering_Tentamineringen_TentamineringenId",
                        column: x => x.TentamineringenId,
                        principalTable: "Tentamineringen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Beoordelingscriteria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oordeel = table.Column<int>(type: "int", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    BeoordelingsdimensieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beoordelingscriteria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beoordelingscriteria_Beoordelingsdimensies_BeoordelingsdimensieId",
                        column: x => x.BeoordelingsdimensieId,
                        principalTable: "Beoordelingsdimensies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beoordelingscriteria_BeoordelingsdimensieId",
                table: "Beoordelingscriteria",
                column: "BeoordelingsdimensieId");

            migrationBuilder.CreateIndex(
                name: "IX_Beoordelingsdimensies_TentamineringId",
                table: "Beoordelingsdimensies",
                column: "TentamineringId");

            migrationBuilder.CreateIndex(
                name: "IX_Leeruitkomsten_EvlId",
                table: "Leeruitkomsten",
                column: "EvlId");

            migrationBuilder.CreateIndex(
                name: "IX_LeeruitkomstTentaminering_TentamineringenId",
                table: "LeeruitkomstTentaminering",
                column: "TentamineringenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tentamineringen_EvlId",
                table: "Tentamineringen",
                column: "EvlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beoordelingscriteria");

            migrationBuilder.DropTable(
                name: "LeeruitkomstTentaminering");

            migrationBuilder.DropTable(
                name: "Beoordelingsdimensies");

            migrationBuilder.DropTable(
                name: "Leeruitkomsten");

            migrationBuilder.DropTable(
                name: "Tentamineringen");

            migrationBuilder.DropTable(
                name: "Evls");
        }
    }
}
