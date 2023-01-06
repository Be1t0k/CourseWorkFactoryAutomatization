using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWorkFactoryAutomatization.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_DetailCatalogs_DetailCatalogId",
                table: "Details");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "TechnicManuals",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SuperVisors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "SuperVisors",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<long>(
                name: "DetailCatalogId",
                table: "Details",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "DetailCatalogs",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Admins",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Accountants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Accountants",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_DetailCatalogs_DetailCatalogId",
                table: "Details",
                column: "DetailCatalogId",
                principalTable: "DetailCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Details_DetailCatalogs_DetailCatalogId",
                table: "Details");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "SuperVisors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "SuperVisors");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Accountants");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Accountants");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "TechnicManuals",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<long>(
                name: "DetailCatalogId",
                table: "Details",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreate",
                table: "DetailCatalogs",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddForeignKey(
                name: "FK_Details_DetailCatalogs_DetailCatalogId",
                table: "Details",
                column: "DetailCatalogId",
                principalTable: "DetailCatalogs",
                principalColumn: "Id");
        }
    }
}
