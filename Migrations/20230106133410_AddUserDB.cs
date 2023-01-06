using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CourseWorkFactoryAutomatization.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountantDetailCatalog_Accountants_AccountantsId",
                table: "AccountantDetailCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperVisorTechnicManual_SuperVisors_SuperVisorsId",
                table: "SuperVisorTechnicManual");

            migrationBuilder.DropTable(
                name: "Accountants");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperVisors",
                table: "SuperVisors");

            migrationBuilder.RenameTable(
                name: "SuperVisors",
                newName: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "IdCatalog",
                table: "Users",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserCatalogId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCatalogId",
                table: "Users",
                column: "UserCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountantDetailCatalog_Users_AccountantsId",
                table: "AccountantDetailCatalog",
                column: "AccountantsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperVisorTechnicManual_Users_SuperVisorsId",
                table: "SuperVisorTechnicManual",
                column: "SuperVisorsId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users",
                column: "UserCatalogId",
                principalTable: "UserCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountantDetailCatalog_Users_AccountantsId",
                table: "AccountantDetailCatalog");

            migrationBuilder.DropForeignKey(
                name: "FK_SuperVisorTechnicManual_Users_SuperVisorsId",
                table: "SuperVisorTechnicManual");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCatalogId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IdCatalog",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCatalogId",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "SuperVisors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperVisors",
                table: "SuperVisors",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Accountants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserCatalogId = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IdCatalog = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserCatalogId",
                table: "Admins",
                column: "UserCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountantDetailCatalog_Accountants_AccountantsId",
                table: "AccountantDetailCatalog",
                column: "AccountantsId",
                principalTable: "Accountants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SuperVisorTechnicManual_SuperVisors_SuperVisorsId",
                table: "SuperVisorTechnicManual",
                column: "SuperVisorsId",
                principalTable: "SuperVisors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
