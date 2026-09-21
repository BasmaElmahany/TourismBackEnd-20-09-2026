using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class edititineraries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "ItineraryDays",
                newName: "Title_En");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ItineraryDays",
                newName: "Title_Ar");

            migrationBuilder.RenameColumn(
                name: "Accommodation",
                table: "ItineraryDays",
                newName: "Description_En");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Itineraries",
                newName: "Title_En");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Itineraries",
                newName: "Title_Ar");

            migrationBuilder.RenameColumn(
                name: "GroupSize",
                table: "Itineraries",
                newName: "Price_En");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Itineraries",
                newName: "Price_Ar");

            migrationBuilder.RenameColumn(
                name: "Difficulty",
                table: "Itineraries",
                newName: "GroupSize_En");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Itineraries",
                newName: "GroupSize_Ar");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Itineraries",
                newName: "Duration_En");

            migrationBuilder.RenameColumn(
                name: "BestTime",
                table: "Itineraries",
                newName: "Duration_Ar");

            migrationBuilder.AddColumn<string>(
                name: "Accommodation_Ar",
                table: "ItineraryDays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Accommodation_En",
                table: "ItineraryDays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ar",
                table: "ItineraryDays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BestTime_Ar",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BestTime_En",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category_Ar",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category_En",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_Ar",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description_En",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty_Ar",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty_En",
                table: "Itineraries",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accommodation_Ar",
                table: "ItineraryDays");

            migrationBuilder.DropColumn(
                name: "Accommodation_En",
                table: "ItineraryDays");

            migrationBuilder.DropColumn(
                name: "Description_Ar",
                table: "ItineraryDays");

            migrationBuilder.DropColumn(
                name: "BestTime_Ar",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "BestTime_En",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Category_Ar",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Category_En",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Description_Ar",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Description_En",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Difficulty_Ar",
                table: "Itineraries");

            migrationBuilder.DropColumn(
                name: "Difficulty_En",
                table: "Itineraries");

            migrationBuilder.RenameColumn(
                name: "Title_En",
                table: "ItineraryDays",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title_Ar",
                table: "ItineraryDays",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Description_En",
                table: "ItineraryDays",
                newName: "Accommodation");

            migrationBuilder.RenameColumn(
                name: "Title_En",
                table: "Itineraries",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Title_Ar",
                table: "Itineraries",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Price_En",
                table: "Itineraries",
                newName: "GroupSize");

            migrationBuilder.RenameColumn(
                name: "Price_Ar",
                table: "Itineraries",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "GroupSize_En",
                table: "Itineraries",
                newName: "Difficulty");

            migrationBuilder.RenameColumn(
                name: "GroupSize_Ar",
                table: "Itineraries",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Duration_En",
                table: "Itineraries",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "Duration_Ar",
                table: "Itineraries",
                newName: "BestTime");
        }
    }
}
