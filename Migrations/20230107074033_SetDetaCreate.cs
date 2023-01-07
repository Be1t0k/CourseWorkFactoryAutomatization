using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkFactoryAutomatization.Migrations
{
    /// <inheritdoc />
    public partial class SetDetaCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technics_TechnicManuals_TechnicManualId",
                table: "Technics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserCatalogId1",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreate",
                table: "UserCatalogs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<long>(
                name: "TechnicManualId",
                table: "Technics",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Details",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserCatalogId1",
                table: "Users",
                column: "UserCatalogId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Technics_TechnicManuals_TechnicManualId",
                table: "Technics",
                column: "TechnicManualId",
                principalTable: "TechnicManuals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users",
                column: "UserCatalogId",
                principalTable: "UserCatalogs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId1",
                table: "Users",
                column: "UserCatalogId1",
                principalTable: "UserCatalogs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Technics_TechnicManuals_TechnicManualId",
                table: "Technics");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserCatalogId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserCatalogId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DateCreate",
                table: "UserCatalogs");

            migrationBuilder.AlterColumn<long>(
                name: "TechnicManualId",
                table: "Technics",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Details",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Technics_TechnicManuals_TechnicManualId",
                table: "Technics",
                column: "TechnicManualId",
                principalTable: "TechnicManuals",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserCatalogs_UserCatalogId",
                table: "Users",
                column: "UserCatalogId",
                principalTable: "UserCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
