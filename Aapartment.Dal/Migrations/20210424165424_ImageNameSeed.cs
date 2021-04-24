using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aapartment.Dal.Migrations
{
    public partial class ImageNameSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "alap1");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "alap2");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageName",
                value: "alap3");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageName",
                value: "alap4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "9353853e-371c-4f06-bb3f-76e55a41577b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8bdacaa9-6932-4abc-b67c-a5eea2b1d6b2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "773e356d-72cd-4eae-a596-c5e6ab9de81d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "7af39677-f97a-4cf5-b0c9-193b659fe039");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "f60f3750-71c9-40ef-98ca-346ceaec4720");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 6, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(1487), new DateTime(2021, 4, 28, 18, 54, 23, 859, DateTimeKind.Local).AddTicks(8075) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 4, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(3287), new DateTime(2021, 4, 29, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(3258) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 16, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(3328), new DateTime(2021, 5, 9, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(3324) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(7478));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 54, 23, 862, DateTimeKind.Local).AddTicks(7501));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "2df10892-c209-4b94-9be3-d1499783ed2f");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "00ee11fc-ea78-4528-9c9a-e4972bc78d41");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageName",
                value: "f3b94ad5-c8e5-4840-a23f-a172df852c67");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageName",
                value: "ad5ee0eb-87e7-4923-8a0b-714c40a91c90");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ee079841-0983-4054-9b0c-44967ced958f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "363f418f-2ae7-4b99-99e8-04c41c63d580");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "82c857b1-ae7a-4eea-88e1-bcc1c0c866db");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "f497a861-a303-40d0-8cb3-3498ce1b106e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "1f8b069c-a6c0-4f23-83eb-09509863f8a7");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 6, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(3914), new DateTime(2021, 4, 28, 18, 44, 51, 834, DateTimeKind.Local).AddTicks(768) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 4, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(5830), new DateTime(2021, 4, 29, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(5801) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 16, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(5866), new DateTime(2021, 5, 9, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(5863) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 44, 51, 836, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 44, 51, 837, DateTimeKind.Local).AddTicks(24));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 4, 24, 18, 44, 51, 837, DateTimeKind.Local).AddTicks(51));
        }
    }
}
