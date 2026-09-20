using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mainEnities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGallery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    OpeningHours_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHours_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketPrice_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    Category_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HistoricalPeriod_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HistoricalPeriod_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Significance_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Significance_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attractions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogPosts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excerpt_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Excerpt_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Category_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReadTime = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Guests = table.Column<int>(type: "int", nullable: false),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreferredContactMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    TicketPrice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGallery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    PriceRange_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRange_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarRating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Difficulty = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimatedCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Highlights = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncludedServices = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExcludedServices = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsletterSubscriptions",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Preferences = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscribeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsletterSubscriptions", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Photographers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageGallery = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false),
                    CuisineType_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CuisineType_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRange_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceRange_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHours_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHours_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Center_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Center_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    DistanceKm = table.Column<double>(type: "float", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    Is24h = table.Column<bool>(type: "bit", nullable: true),
                    IsEmergency = table.Column<bool>(type: "bit", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    Features = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeaturesAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentsCount = table.Column<int>(type: "int", nullable: true),
                    Specialty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasDelivery = table.Column<bool>(type: "bit", nullable: true),
                    AcceptsInsurance = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SouvenirCategories",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SouvenirCategories", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "SouvenirShops",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    DistanceKm = table.Column<double>(type: "float", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true),
                    ReviewCount = table.Column<int>(type: "int", nullable: true),
                    PriceRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpeningHoursAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: true),
                    AcceptsCreditCard = table.Column<bool>(type: "bit", nullable: true),
                    HasDelivery = table.Column<bool>(type: "bit", nullable: true),
                    HasOnlineStore = table.Column<bool>(type: "bit", nullable: true),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtiesAr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SouvenirShops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourGuides",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Languages = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Social = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rating = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourGuides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourismInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Climate_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestTimeToVisit_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestTimeToVisit_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatToWear_En = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatToWear_Ar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes_En = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes_Ar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourismInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VisitorInfos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitorInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meals = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Accommodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItineraryId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDays_Itineraries_ItineraryId",
                        column: x => x.ItineraryId,
                        principalTable: "Itineraries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SouvenirProducts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShopId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescriptionAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    Handmade = table.Column<bool>(type: "bit", nullable: true),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginAr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SouvenirProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SouvenirProducts_SouvenirShops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "SouvenirShops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDays_ItineraryId",
                table: "ItineraryDays",
                column: "ItineraryId");

            migrationBuilder.CreateIndex(
                name: "IX_SouvenirProducts_ShopId",
                table: "SouvenirProducts",
                column: "ShopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attractions");

            migrationBuilder.DropTable(
                name: "BlogPosts");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "ItineraryDays");

            migrationBuilder.DropTable(
                name: "NewsletterSubscriptions");

            migrationBuilder.DropTable(
                name: "Photographers");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "SouvenirCategories");

            migrationBuilder.DropTable(
                name: "SouvenirProducts");

            migrationBuilder.DropTable(
                name: "TourGuides");

            migrationBuilder.DropTable(
                name: "TourismInfos");

            migrationBuilder.DropTable(
                name: "VisitorInfos");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "SouvenirShops");
        }
    }
}
