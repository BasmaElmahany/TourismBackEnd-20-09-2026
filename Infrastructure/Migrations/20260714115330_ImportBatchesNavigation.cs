using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ImportBatchesNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_ManzomaImports_ImportBatchId",
                table: "ManzomaImports",
                column: "ImportBatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManzomaImports_ImportBatches_ImportBatchId",
                table: "ManzomaImports",
                column: "ImportBatchId",
                principalTable: "ImportBatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManzomaImports_ImportBatches_ImportBatchId",
                table: "ManzomaImports");

            migrationBuilder.DropIndex(
                name: "IX_ManzomaImports_ImportBatchId",
                table: "ManzomaImports");

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
    }
}
