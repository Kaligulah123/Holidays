using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Holidays.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews");

            migrationBuilder.AddColumn<Guid>(
                name: "BookingId1",
                table: "reviews",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_BookingId1",
                table: "reviews",
                column: "BookingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_bookings_BookingId1",
                table: "reviews",
                column: "BookingId1",
                principalTable: "bookings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_bookings_BookingId1",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_BookingId1",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "BookingId1",
                table: "reviews");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_bookings_BookingId",
                table: "reviews",
                column: "BookingId",
                principalTable: "bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
