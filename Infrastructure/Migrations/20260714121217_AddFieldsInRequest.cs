using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldsInRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AdvanceDate",
                table: "Requests",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Committee",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ContractAdvanceValue",
                table: "Requests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "InstallmentIntervalMonths",
                table: "Requests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Region",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "AdvanceDate",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Committee",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "ContractAdvanceValue",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "InstallmentIntervalMonths",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "Region",
                table: "Requests");
        }
    }
}
