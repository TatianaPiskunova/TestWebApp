using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestWebApp.Migrations
{
    /// <inheritdoc />
    public partial class one : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtistTitleOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    artist = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    media = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    starring = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    director = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    originalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistTitleOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AudiobookOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    performedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    performanceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    storage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    format = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    recordingLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudiobookOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BookOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    author = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    publisher = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    series = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    part = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    binding = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pageExtent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    downloadable = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EventTicketOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    place = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hall = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hallPlan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hallPart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    date = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isPremiere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isKids = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTicketOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TourOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    worldRegion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    days = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataTour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotelStars = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    included = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    transport = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourOffers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "VendorModelOffers",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    cbid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    delivery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    localDeliveryCost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    typePrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vendor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vendorCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    manufacturerWarranty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    countryOforigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    available = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    currencyId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    categoryIdType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    picture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorModelOffers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistTitleOffers");

            migrationBuilder.DropTable(
                name: "AudiobookOffers");

            migrationBuilder.DropTable(
                name: "BookOffers");

            migrationBuilder.DropTable(
                name: "EventTicketOffers");

            migrationBuilder.DropTable(
                name: "TourOffers");

            migrationBuilder.DropTable(
                name: "VendorModelOffers");
        }
    }
}
