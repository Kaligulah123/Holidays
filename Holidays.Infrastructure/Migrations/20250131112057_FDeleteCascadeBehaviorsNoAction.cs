using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holidays.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FDeleteCascadeBehaviorsNoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_apartments_ApartmentId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_apartments_ApartmentId",
                table: "reviews",
                column: "ApartmentId",
                principalTable: "apartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_apartments_ApartmentId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_apartments_ApartmentId",
                table: "reviews",
                column: "ApartmentId",
                principalTable: "apartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_users_UserId",
                table: "reviews",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
