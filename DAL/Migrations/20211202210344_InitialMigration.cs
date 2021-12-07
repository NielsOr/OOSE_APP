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
                    EvlId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
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
                    EvlId = table.Column<int>(type: "int", nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Aanmeldingstype = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Hulpmiddelen = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Weging = table.Column<int>(type: "int", nullable: false),
                    MinimaalOordeel = table.Column<double>(type: "float", nullable: false),
                    Tentamenvorm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
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
                name: "rubric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TentamineringId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weging = table.Column<int>(type: "int", nullable: false),
                    MinimaalOordeel = table.Column<double>(type: "float", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubric", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rubric_tentaminering_TentamineringId",
                        column: x => x.TentamineringId,
                        principalTable: "tentaminering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tentaminering_leeruitkomst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beoordelingcriteria = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    TentamineringId = table.Column<int>(type: "int", nullable: false),
                    LeeruitkomstId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tentaminering_leeruitkomst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tentaminering_leeruitkomst_leeruitkomst_LeeruitkomstId",
                        column: x => x.LeeruitkomstId,
                        principalTable: "leeruitkomst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tentaminering_leeruitkomst_tentaminering_TentamineringId",
                        column: x => x.TentamineringId,
                        principalTable: "tentaminering",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rubric_criterium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RubricId = table.Column<int>(type: "int", nullable: false),
                    Oordeel = table.Column<int>(type: "int", nullable: false),
                    Beschrijving = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rubric_criterium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rubric_criterium_rubric_RubricId",
                        column: x => x.RubricId,
                        principalTable: "rubric",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leeruitkomst_EvlId",
                table: "leeruitkomst",
                column: "EvlId");

            migrationBuilder.CreateIndex(
                name: "IX_rubric_TentamineringId",
                table: "rubric",
                column: "TentamineringId");

            migrationBuilder.CreateIndex(
                name: "IX_rubric_criterium_RubricId",
                table: "rubric_criterium",
                column: "RubricId");

            migrationBuilder.CreateIndex(
                name: "IX_tentaminering_EvlId",
                table: "tentaminering",
                column: "EvlId");

            migrationBuilder.CreateIndex(
                name: "IX_tentaminering_leeruitkomst_LeeruitkomstId",
                table: "tentaminering_leeruitkomst",
                column: "LeeruitkomstId");

            migrationBuilder.CreateIndex(
                name: "IX_tentaminering_leeruitkomst_TentamineringId",
                table: "tentaminering_leeruitkomst",
                column: "TentamineringId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rubric_criterium");

            migrationBuilder.DropTable(
                name: "tentaminering_leeruitkomst");

            migrationBuilder.DropTable(
                name: "rubric");

            migrationBuilder.DropTable(
                name: "leeruitkomst");

            migrationBuilder.DropTable(
                name: "tentaminering");

            migrationBuilder.DropTable(
                name: "evl");
        }
    }
}
