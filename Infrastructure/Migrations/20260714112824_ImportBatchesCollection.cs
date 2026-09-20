using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImportBatchesCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ImportBatchesId",
                table: "ManzomaImports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ManzomaImports_ImportBatchesId",
                table: "ManzomaImports",
                column: "ImportBatchesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManzomaImports_ImportBatches_ImportBatchesId",
                table: "ManzomaImports",
                column: "ImportBatchesId",
                principalTable: "ImportBatches",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManzomaImports_ImportBatches_ImportBatchesId",
                table: "ManzomaImports");

            migrationBuilder.DropIndex(
                name: "IX_ManzomaImports_ImportBatchesId",
                table: "ManzomaImports");

            migrationBuilder.DropColumn(
                name: "ImportBatchesId",
                table: "ManzomaImports");
        }
    }
}
