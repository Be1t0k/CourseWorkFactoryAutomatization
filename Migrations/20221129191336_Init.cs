using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CourseWorkFactoryAutomatization.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accountants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailCatalogs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuperVisors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperVisors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicManuals",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateCreate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicManuals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCatalogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCatalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountantDetailCatalog",
                columns: table => new
                {
                    AccountantsId = table.Column<long>(type: "bigint", nullable: false),
                    DetailCatalogsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountantDetailCatalog", x => new { x.AccountantsId, x.DetailCatalogsId });
                    table.ForeignKey(
                        name: "FK_AccountantDetailCatalog_Accountants_AccountantsId",
                        column: x => x.AccountantsId,
                        principalTable: "Accountants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountantDetailCatalog_DetailCatalogs_DetailCatalogsId",
                        column: x => x.DetailCatalogsId,
                        principalTable: "DetailCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperVisorTechnicManual",
                columns: table => new
                {
                    SuperVisorsId = table.Column<long>(type: "bigint", nullable: false),
                    TechnicManualsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperVisorTechnicManual", x => new { x.SuperVisorsId, x.TechnicManualsId });
                    table.ForeignKey(
                        name: "FK_SuperVisorTechnicManual_SuperVisors_SuperVisorsId",
                        column: x => x.SuperVisorsId,
                        principalTable: "SuperVisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperVisorTechnicManual_TechnicManuals_TechnicManualsId",
                        column: x => x.TechnicManualsId,
                        principalTable: "TechnicManuals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Technics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    TechnicManualId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technics_TechnicManuals_TechnicManualId",
                        column: x => x.TechnicManualId,
                        principalTable: "TechnicManuals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCatalog = table.Column<long>(type: "bigint", nullable: false),
                    UserCatalogId = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admins_UserCatalogs_UserCatalogId",
                        column: x => x.UserCatalogId,
                        principalTable: "UserCatalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<decimal>(type: "numeric", nullable: false),
                    TechnicId = table.Column<long>(type: "bigint", nullable: false),
                    DetailCatalogId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_DetailCatalogs_DetailCatalogId",
                        column: x => x.DetailCatalogId,
                        principalTable: "DetailCatalogs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Details_Technics_TechnicId",
                        column: x => x.TechnicId,
                        principalTable: "Technics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountantDetailCatalog_DetailCatalogsId",
                table: "AccountantDetailCatalog",
                column: "DetailCatalogsId");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserCatalogId",
                table: "Admins",
                column: "UserCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_DetailCatalogId",
                table: "Details",
                column: "DetailCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_TechnicId",
                table: "Details",
                column: "TechnicId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperVisorTechnicManual_TechnicManualsId",
                table: "SuperVisorTechnicManual",
                column: "TechnicManualsId");

            migrationBuilder.CreateIndex(
                name: "IX_Technics_TechnicManualId",
                table: "Technics",
                column: "TechnicManualId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountantDetailCatalog");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "SuperVisorTechnicManual");

            migrationBuilder.DropTable(
                name: "Accountants");

            migrationBuilder.DropTable(
                name: "UserCatalogs");

            migrationBuilder.DropTable(
                name: "DetailCatalogs");

            migrationBuilder.DropTable(
                name: "Technics");

            migrationBuilder.DropTable(
                name: "SuperVisors");

            migrationBuilder.DropTable(
                name: "TechnicManuals");
        }
    }
}
