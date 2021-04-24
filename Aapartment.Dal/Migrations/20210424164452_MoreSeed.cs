using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aapartment.Dal.Migrations
{
    public partial class MoreSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Description", "ImageName", "Name", "Address_City", "Address_Country", "Address_Street", "Address_ZipCode" },
                values: new object[] { 4, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "ad5ee0eb-87e7-4923-8a0b-714c40a91c90", "Malaha Hotel", "Honolulu", "USA", "Upalu St street 3", 96705 });

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

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ApartmentId", "IsAvailabe", "MaxNumberOfPeople", "PricePerAdult", "PricePerChild", "RoomNumber" },
                values: new object[,]
                {
                    { 16, 4, true, 4, 5000, 2400, 101 },
                    { 17, 4, true, 3, 5500, 2450, 102 },
                    { 18, 4, false, 7, 5400, 2000, 103 },
                    { 19, 4, true, 4, 6000, 3400, 104 },
                    { 20, 4, true, 4, 5050, 2700, 105 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageName",
                value: "5789f5af-62ba-4361-a432-fccb268e1a90");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageName",
                value: "57c4e158-e07c-459e-a724-9ef65ab4a0d0");

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageName",
                value: "b61d0cf5-dd61-4b54-9f81-80bb312f77f0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "2116fbb0-3c38-4841-b36f-9b07629e2d6a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "658b7766-9d80-4986-a8d3-9ba7a555e628");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bc57f428-e735-4ccf-baa8-dba15599cc54");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "9324bee8-474e-46eb-aafd-6b765cada70a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6cd3a24e-6a1b-4b57-b6cc-feace8dd4dd6");

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 5, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(4271), new DateTime(2021, 4, 27, 15, 47, 3, 18, DateTimeKind.Local).AddTicks(836) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 3, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6067), new DateTime(2021, 4, 28, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2021, 5, 15, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6109), new DateTime(2021, 5, 8, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created",
                value: new DateTime(2021, 4, 23, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created",
                value: new DateTime(2021, 4, 23, 15, 47, 3, 21, DateTimeKind.Local).AddTicks(277));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created",
                value: new DateTime(2021, 4, 23, 15, 47, 3, 21, DateTimeKind.Local).AddTicks(300));
        }
    }
}
