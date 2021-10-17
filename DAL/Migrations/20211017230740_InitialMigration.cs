using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evl",
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
                    table.PrimaryKey("PK_evl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "leeruitkomst",
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
                    table.PrimaryKey("PK_leeruitkomst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leeruitkomst_evl_EvlId",
                        column: x => x.EvlId,
                        principalTable: "evl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tentaminering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aanmeldingstype = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Hulpmiddelen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Weging = table.Column<int>(type: "int", nullable: false),
                    MinimaalOordeel = table.Column<double>(type: "float", nullable: false),
                    Tentamenvorm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EvlId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tentaminering", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tentaminering_evl_EvlId",
                        column: x => x.EvlId,
                        principalTable: "evl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "beoordelingsdimensie",
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
                    table.PrimaryKey("PK_beoordelingsdimensie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beoordelingsdimensie_tentaminering_TentamineringId",
                        column: x => x.TentamineringId,
                        principalTable: "tentaminering",
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
                        name: "FK_LeeruitkomstTentaminering_leeruitkomst_LeeruitkomstenId",
                        column: x => x.LeeruitkomstenId,
                        principalTable: "leeruitkomst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_LeeruitkomstTentaminering_tentaminering_TentamineringenId",
                        column: x => x.TentamineringenId,
                        principalTable: "tentaminering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "beoordelingscriterium",
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
                    table.PrimaryKey("PK_beoordelingscriterium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_beoordelingscriterium_beoordelingsdimensie_BeoordelingsdimensieId",
                        column: x => x.BeoordelingsdimensieId,
                        principalTable: "beoordelingsdimensie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_beoordelingscriterium_BeoordelingsdimensieId",
                table: "beoordelingscriterium",
                column: "BeoordelingsdimensieId");

            migrationBuilder.CreateIndex(
                name: "IX_beoordelingsdimensie_TentamineringId",
                table: "beoordelingsdimensie",
                column: "TentamineringId");

            migrationBuilder.CreateIndex(
                name: "IX_leeruitkomst_EvlId",
                table: "leeruitkomst",
                column: "EvlId");

            migrationBuilder.CreateIndex(
                name: "IX_LeeruitkomstTentaminering_TentamineringenId",
                table: "LeeruitkomstTentaminering",
                column: "TentamineringenId");

            migrationBuilder.CreateIndex(
                name: "IX_tentaminering_EvlId",
                table: "tentaminering",
                column: "EvlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "beoordelingscriterium");

            migrationBuilder.DropTable(
                name: "LeeruitkomstTentaminering");

            migrationBuilder.DropTable(
                name: "beoordelingsdimensie");

            migrationBuilder.DropTable(
                name: "leeruitkomst");

            migrationBuilder.DropTable(
                name: "tentaminering");

            migrationBuilder.DropTable(
                name: "evl");
        }
    }
}
