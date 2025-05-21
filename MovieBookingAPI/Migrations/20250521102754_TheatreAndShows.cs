using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MovieBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class TheatreAndShows : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isNowShowing",
                table: "Movies",
                newName: "IsNowShowing");

            migrationBuilder.CreateTable(
                name: "Theatre",
                columns: table => new
                {
                    TheatreId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TheatreName = table.Column<string>(type: "text", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Theatre", x => x.TheatreId);
                });

            migrationBuilder.CreateTable(
                name: "Show",
                columns: table => new
                {
                    ShowId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MovieId = table.Column<int>(type: "integer", nullable: false),
                    TheatreId = table.Column<int>(type: "integer", nullable: false),
                    ShowDate = table.Column<DateOnly>(type: "date", nullable: false),
                    ShowTime = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Show", x => x.ShowId);
                    table.ForeignKey(
                        name: "FK_Show_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Show_Theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatre",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TheatreSeats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TheatreId = table.Column<int>(type: "integer", nullable: false),
                    Row = table.Column<string>(type: "text", nullable: false),
                    Column = table.Column<int>(type: "integer", nullable: false),
                    SeatName = table.Column<string>(type: "text", nullable: false),
                    CostInPounds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheatreSeats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_TheatreSeats_Theatre_TheatreId",
                        column: x => x.TheatreId,
                        principalTable: "Theatre",
                        principalColumn: "TheatreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShowId = table.Column<int>(type: "integer", nullable: false),
                    SeatId = table.Column<int>(type: "integer", nullable: false),
                    UserEmailAddress = table.Column<string>(type: "text", nullable: false),
                    BookingDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Show_ShowId",
                        column: x => x.ShowId,
                        principalTable: "Show",
                        principalColumn: "ShowId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_TheatreSeats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "TheatreSeats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_SeatId",
                table: "Booking",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ShowId",
                table: "Booking",
                column: "ShowId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_MovieId",
                table: "Show",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Show_TheatreId",
                table: "Show",
                column: "TheatreId");

            migrationBuilder.CreateIndex(
                name: "IX_TheatreSeats_TheatreId",
                table: "TheatreSeats",
                column: "TheatreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Show");

            migrationBuilder.DropTable(
                name: "TheatreSeats");

            migrationBuilder.DropTable(
                name: "Theatre");

            migrationBuilder.RenameColumn(
                name: "IsNowShowing",
                table: "Movies",
                newName: "isNowShowing");
        }
    }
}
