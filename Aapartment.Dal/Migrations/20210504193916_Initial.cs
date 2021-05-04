using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aapartment.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Address_Country = table.Column<string>(nullable: true),
                    Address_ZipCode = table.Column<int>(nullable: true),
                    Address_City = table.Column<string>(nullable: true),
                    Address_Street = table.Column<string>(nullable: true),
                    ImageName = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(nullable: false),
                    PricePerAdult = table.Column<int>(nullable: false),
                    PricePerChild = table.Column<int>(nullable: false),
                    MaxNumberOfPeople = table.Column<int>(nullable: false),
                    IsAvailabe = table.Column<bool>(nullable: false),
                    ApartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Apartments",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => new { x.ApartmentId, x.Id });
                    table.ForeignKey(
                        name: "FK_Service_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stars = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 300, nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Apartments",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Reviews",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    SumPrice = table.Column<int>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    NumberOfAdults = table.Column<int>(nullable: false),
                    NumberOfChildren = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    UserId1 = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Bookings",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Bookings",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "Description", "ImageName", "Name", "Address_City", "Address_Country", "Address_Street", "Address_ZipCode" },
                values: new object[,]
                {
                    { 4, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap4.jpg", "Malaha Hotel", "Honolulu", "USA", "Upalu St street 3", 96705 },
                    { 16, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap16.jpg", "Boulvard Hotel", "Los Angeles", "USA", "Fedora street 74", 74511 },
                    { 15, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap15.jpg", "Indigo Hotel", "Manila", "Philippines", "Kaucor street 85", 36301 },
                    { 14, "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.", "alap14.jpg", "Edgbaston Hotel", "Istanbul", "Turkey", "Gyromar street 45", 7821 },
                    { 13, "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.", "alap13.jpg", "Nautis Hotel", "Osaka", "Japan", "Muramura street 3", 8232 },
                    { 12, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap12.jpg", "Nostra Hotel", "Cairo", "Egypt", "Pyramor street 52", 7531 },
                    { 10, "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.", "alap10.jpeg", "Willis Hotel", "Mexico City", "Mexico", "Mehikan street 28", 2468 },
                    { 9, "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.", "alap9.jpg", "Phonin Hotel", "Sao Paulo", "Brazil", "Peloza street 33", 5231 },
                    { 11, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap11.jpeg", "Pandora Hotel", "Dhaka", "Bangladesh", "Proauro street 11", 9743 },
                    { 7, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap7.jpg", "Happymoon Hotel", "Delhi", "India", "Temple street 80", 41023 },
                    { 6, "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.", "alap6.jpg", "Sunshine Hotel", "Tokyo", "Japan", "Kaumu street 410", 5620 },
                    { 5, "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.", "alap5.jpg", "Retro Hotel", "Budapest", "Hungary", "Havanna St street 3", 1181 },
                    { 1, "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.", "alap1.jpg", "Panama Hotel", "New York", "USA", "Pearl street 72", 5504 },
                    { 2, "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.", "alap2.jpg", "Mercur Hotel", "Madrid", "Spain", "Bueno street 45", 3424 },
                    { 3, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap3.jpg", "Langmoon Hotel", "Peking", "China", "Chicaego street 45", 11004 },
                    { 8, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "alap8.jpg", "Aquarell Hotel", "Shanghai", "China", "Ruraro street 91", 632302 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "49238e4b-4c47-424e-86a6-e6690a61bb35", "ADMIN", "ADMIN" },
                    { 2, "167729fe-511a-466d-83d3-644c132e6e73", "GUEST", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "be73785a-c3ee-4e57-9c3a-049891a30713", "tesztelek@gmail.com", true, "Teszt", "Elek", false, null, "TESZTELEK@GMAIL.COM", "TESZTELEK", "AQAAAAEAACcQAAAAEIHDARrWsCZc5QOCeQ4wWdvkivfYwA2tPRoPIy/G33U4U5IOhvJJyRouOt9zLk3/DA==", "06/30-152-5123", false, "384136cd-4c29-4969-8558-ce17373772f3", false, "tesztelek" },
                    { 3, 0, "93fbba93-898d-40c6-b5b0-698e8d89c721", "wincheszter@gmail.com", true, "Winch", "Eszter", false, null, "WINCHESZTER@GMAIL.COM", "WINCHESZTER", "AQAAAAEAACcQAAAAEIwaS+U6mg3VqnFi5SnZgE+Ew8BPkZMTjVEsOqW6SYyT8VYWws+mgD78bxHKFn0K2A==", "06/30-152-5123", false, "03dde34b-092f-461e-a718-92c83e39661a", false, "wincheszter" },
                    { 4, 0, "c00fe948-17dd-498b-9778-3b6985c1f592", "kbela@gmail.com", true, "Kis", "Béla", false, null, "KBELA@GMAIL.COM", "KBELA", "AQAAAAEAACcQAAAAEK9JM1WSCho+CX7LLIb9dpO3LEoIOHfVtUUtmp3OPaWlZvcQnyzqWo2tNKlwKPXWvQ==", "06/30-152-5123", false, "3df1da4b-79d2-424a-ba8d-1a0ce7389514", false, "kbela" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 4, 2 },
                    { 2, 2 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "ApartmentId", "Content", "Created", "Stars", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 4, 4, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6901), 5, 2, null },
                    { 7, 7, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6911), 4, 2, null },
                    { 10, 10, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6921), 4, 2, null },
                    { 13, 13, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6931), 4, 2, null },
                    { 16, 15, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6941), 4, 2, null },
                    { 19, 16, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6951), 4, 2, null },
                    { 2, 2, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6869), 1, 3, null },
                    { 5, 5, "There are a lot of cockroach here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6904), 2, 3, null },
                    { 8, 8, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6914), 1, 3, null },
                    { 1, 1, "One of the best apartment here.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(5657), 4, 2, null },
                    { 14, 14, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6934), 1, 3, null },
                    { 17, 15, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6944), 1, 3, null },
                    { 20, 16, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6954), 1, 3, null },
                    { 3, 3, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6897), 3, 4, null },
                    { 6, 6, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6908), 3, 4, null },
                    { 9, 9, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6918), 3, 4, null },
                    { 12, 12, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6928), 3, 4, null },
                    { 15, 14, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6937), 3, 4, null },
                    { 18, 15, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6947), 3, 4, null },
                    { 21, 16, "I could find a better place, but it's ok.", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6957), 3, 4, null },
                    { 11, 11, "There are a lot of bugs here!", new DateTime(2021, 5, 4, 21, 39, 15, 955, DateTimeKind.Local).AddTicks(6925), 1, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ApartmentId", "IsAvailabe", "MaxNumberOfPeople", "PricePerAdult", "PricePerChild", "RoomNumber" },
                values: new object[,]
                {
                    { 49, 11, true, 4, 6000, 3400, 104 },
                    { 50, 11, true, 4, 5050, 2700, 105 },
                    { 55, 13, true, 4, 5050, 2700, 105 },
                    { 52, 13, true, 3, 5500, 2450, 102 },
                    { 53, 13, false, 7, 5400, 2000, 103 },
                    { 54, 13, true, 4, 6000, 3400, 104 },
                    { 48, 11, false, 7, 5400, 2000, 103 },
                    { 51, 12, true, 4, 5000, 2400, 101 },
                    { 47, 10, true, 3, 5500, 2450, 102 },
                    { 42, 9, true, 3, 5500, 2450, 102 },
                    { 45, 10, true, 4, 5050, 2700, 105 },
                    { 44, 10, true, 4, 6000, 3400, 104 },
                    { 43, 9, false, 7, 5400, 2000, 103 },
                    { 41, 9, true, 4, 5000, 2400, 101 },
                    { 40, 8, true, 4, 5050, 2700, 105 },
                    { 39, 8, true, 4, 6000, 3400, 104 },
                    { 38, 8, false, 7, 5400, 2000, 103 },
                    { 37, 8, true, 3, 5500, 2450, 102 },
                    { 56, 14, true, 4, 5000, 2400, 101 },
                    { 46, 10, true, 4, 5000, 2400, 101 },
                    { 57, 14, true, 3, 5500, 2450, 102 },
                    { 69, 15, true, 4, 6000, 3400, 104 },
                    { 59, 14, true, 4, 6000, 3400, 104 },
                    { 80, 16, true, 4, 5050, 2700, 105 },
                    { 79, 16, true, 4, 6000, 3400, 104 },
                    { 78, 16, false, 7, 5400, 2000, 103 },
                    { 77, 16, true, 3, 5500, 2450, 102 },
                    { 76, 16, true, 4, 5000, 2400, 101 },
                    { 75, 16, true, 4, 5050, 2700, 105 },
                    { 74, 16, true, 4, 6000, 3400, 104 },
                    { 73, 16, false, 7, 5400, 2000, 103 },
                    { 72, 16, true, 3, 5500, 2450, 102 },
                    { 71, 16, true, 4, 5000, 2400, 101 },
                    { 70, 15, true, 4, 5050, 2700, 105 },
                    { 36, 8, true, 4, 5000, 2400, 101 },
                    { 68, 15, false, 7, 5400, 2000, 103 },
                    { 67, 15, true, 3, 5500, 2450, 102 },
                    { 66, 15, true, 4, 5000, 2400, 101 },
                    { 65, 15, true, 4, 5050, 2700, 105 },
                    { 64, 15, true, 4, 6000, 3400, 104 },
                    { 63, 15, false, 7, 5400, 2000, 103 },
                    { 62, 15, true, 3, 5500, 2450, 102 },
                    { 61, 15, true, 4, 5000, 2400, 101 },
                    { 60, 14, true, 4, 5050, 2700, 105 },
                    { 58, 14, false, 7, 5400, 2000, 103 },
                    { 35, 8, true, 4, 5050, 2700, 105 },
                    { 16, 4, true, 4, 5000, 2400, 101 },
                    { 2, 1, true, 3, 5500, 2450, 102 },
                    { 26, 5, true, 4, 5000, 2400, 101 },
                    { 30, 6, true, 4, 5050, 2700, 105 },
                    { 21, 5, true, 4, 5000, 2400, 101 },
                    { 29, 6, true, 4, 6000, 3400, 104 },
                    { 28, 6, false, 7, 5400, 2000, 103 },
                    { 22, 5, true, 3, 5500, 2450, 102 },
                    { 6, 2, true, 4, 5000, 2400, 101 },
                    { 3, 1, false, 7, 5400, 2000, 103 },
                    { 23, 5, false, 7, 5400, 2000, 103 },
                    { 24, 5, true, 4, 6000, 3400, 104 },
                    { 25, 5, true, 4, 5050, 2700, 105 },
                    { 7, 2, true, 3, 5500, 2450, 102 },
                    { 8, 2, false, 7, 5400, 2000, 103 },
                    { 9, 2, true, 4, 6000, 3400, 104 },
                    { 10, 2, true, 4, 5050, 2700, 105 },
                    { 15, 3, true, 4, 5050, 2700, 105 },
                    { 14, 3, true, 4, 6000, 3400, 104 },
                    { 27, 5, true, 3, 5500, 2450, 102 },
                    { 12, 3, true, 3, 5500, 2450, 102 },
                    { 11, 3, true, 4, 5000, 2400, 101 },
                    { 17, 4, true, 3, 5500, 2450, 102 },
                    { 18, 4, false, 7, 5400, 2000, 103 },
                    { 19, 4, true, 4, 6000, 3400, 104 },
                    { 20, 4, true, 4, 5050, 2700, 105 },
                    { 34, 7, true, 4, 6000, 3400, 104 },
                    { 31, 7, true, 4, 5000, 2400, 101 },
                    { 32, 7, true, 3, 5500, 2450, 102 },
                    { 33, 7, false, 7, 5400, 2000, 103 },
                    { 13, 3, false, 7, 5400, 2000, 103 },
                    { 1, 1, true, 4, 5000, 2400, 101 },
                    { 5, 1, true, 4, 5050, 2700, 105 },
                    { 4, 1, true, 4, 6000, 3400, 104 }
                });

            migrationBuilder.InsertData(
                table: "Service",
                columns: new[] { "ApartmentId", "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 15, 64, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 15, 65, "fas fa-users", "Family rooms" },
                    { 2, 10, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 2, 11, "fas fa-users", "Family rooms" },
                    { 2, 12, "fas fa-umbrella-beach", "Terrace" },
                    { 15, 66, "fas fa-umbrella-beach", "Terrace" },
                    { 2, 9, "fas fa-shuttle-van", "Airport shuttle" },
                    { 15, 67, "fas fa-wifi", "Free wifi" },
                    { 16, 72, "fas fa-umbrella-beach", "Terrace" },
                    { 2, 7, "fas fa-wifi", "Free wifi" },
                    { 4, 19, "fas fa-wifi", "Free wifi" },
                    { 4, 20, "fas fa-paw", "Pets allowed" },
                    { 4, 21, "fas fa-shuttle-van", "Airport shuttle" },
                    { 4, 22, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 4, 23, "fas fa-users", "Family rooms" },
                    { 4, 24, "fas fa-umbrella-beach", "Terrace" },
                    { 3, 13, "fas fa-wifi", "Free wifi" },
                    { 2, 8, "fas fa-paw", "Pets allowed" },
                    { 3, 14, "fas fa-paw", "Pets allowed" },
                    { 3, 16, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 3, 17, "fas fa-users", "Family rooms" },
                    { 3, 18, "fas fa-umbrella-beach", "Terrace" },
                    { 16, 71, "fas fa-users", "Family rooms" },
                    { 16, 70, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 16, 69, "fas fa-shuttle-van", "Airport shuttle" },
                    { 16, 68, "fas fa-paw", "Pets allowed" },
                    { 3, 15, "fas fa-shuttle-van", "Airport shuttle" },
                    { 7, 36, "fas fa-umbrella-beach", "Terrace" },
                    { 1, 5, "fas fa-users", "Family rooms" },
                    { 1, 2, "fas fa-paw", "Pets allowed" },
                    { 10, 48, "fas fa-umbrella-beach", "Terrace" },
                    { 10, 47, "fas fa-users", "Family rooms" },
                    { 6, 28, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 6, 29, "fas fa-users", "Family rooms" },
                    { 6, 30, "fas fa-umbrella-beach", "Terrace" },
                    { 9, 46, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 6, 31, "fas fa-wifi", "Free wifi" },
                    { 9, 44, "fas fa-paw", "Pets allowed" },
                    { 10, 49, "fas fa-wifi", "Free wifi" },
                    { 9, 43, "fas fa-wifi", "Free wifi" },
                    { 8, 41, "fas fa-users", "Family rooms" },
                    { 8, 40, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 8, 39, "fas fa-shuttle-van", "Airport shuttle" },
                    { 8, 38, "fas fa-paw", "Pets allowed" },
                    { 7, 32, "fas fa-paw", "Pets allowed" },
                    { 7, 33, "fas fa-shuttle-van", "Airport shuttle" },
                    { 7, 34, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 7, 35, "fas fa-users", "Family rooms" },
                    { 9, 42, "fas fa-umbrella-beach", "Terrace" },
                    { 1, 1, "fas fa-wifi", "Free wifi" },
                    { 10, 50, "fas fa-paw", "Pets allowed" },
                    { 11, 51, "fas fa-shuttle-van", "Airport shuttle" },
                    { 1, 3, "fas fa-shuttle-van", "Airport shuttle" },
                    { 1, 4, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 7, 37, "fas fa-wifi", "Free wifi" },
                    { 14, 63, "fas fa-shuttle-van", "Airport shuttle" },
                    { 14, 62, "fas fa-paw", "Pets allowed" },
                    { 1, 6, "fas fa-umbrella-beach", "Terrace" },
                    { 13, 61, "fas fa-wifi", "Free wifi" },
                    { 5, 25, "fas fa-wifi", "Free wifi" },
                    { 5, 27, "fas fa-shuttle-van", "Airport shuttle" },
                    { 12, 60, "fas fa-umbrella-beach", "Terrace" },
                    { 12, 58, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 12, 57, "fas fa-shuttle-van", "Airport shuttle" },
                    { 12, 56, "fas fa-paw", "Pets allowed" },
                    { 5, 26, "fas fa-paw", "Pets allowed" },
                    { 11, 55, "fas fa-wifi", "Free wifi" },
                    { 11, 54, "fas fa-umbrella-beach", "Terrace" },
                    { 11, 53, "fas fa-users", "Family rooms" },
                    { 11, 52, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 12, 59, "fas fa-users", "Family rooms" },
                    { 9, 45, "fas fa-shuttle-van", "Airport shuttle" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EndDate", "IsPaid", "NumberOfAdults", "NumberOfChildren", "RoomId", "StartDate", "SumPrice", "UserId", "UserId1" },
                values: new object[,]
                {
                    { 9, new DateTime(2021, 9, 3, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5171), true, 3, 2, 16, new DateTime(2021, 8, 24, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5168), 562300, 4, null },
                    { 16, new DateTime(2021, 6, 14, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5215), true, 3, 2, 21, new DateTime(2021, 5, 10, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5212), 976230, 2, null },
                    { 7, new DateTime(2021, 6, 5, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5123), true, 3, 2, 21, new DateTime(2021, 5, 18, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5120), 600300, 2, null },
                    { 14, new DateTime(2021, 6, 3, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5203), false, 2, 2, 5, new DateTime(2021, 5, 29, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5200), 333440, 3, null },
                    { 2, new DateTime(2021, 5, 14, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5039), false, 2, 3, 5, new DateTime(2021, 5, 9, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5022), 260300, 3, null },
                    { 1, new DateTime(2021, 5, 16, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(2424), true, 3, 2, 2, new DateTime(2021, 5, 8, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(1892), 160300, 2, null },
                    { 18, new DateTime(2021, 7, 10, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5227), true, 2, 0, 10, new DateTime(2021, 7, 6, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5225), 63960, 4, null },
                    { 12, new DateTime(2021, 7, 15, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5190), true, 3, 1, 10, new DateTime(2021, 7, 8, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5188), 95530, 4, null },
                    { 3, new DateTime(2021, 5, 26, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5097), true, 1, 0, 10, new DateTime(2021, 5, 19, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5094), 212330, 4, null },
                    { 17, new DateTime(2021, 6, 28, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5221), false, 2, 2, 8, new DateTime(2021, 6, 18, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5218), 52660, 3, null },
                    { 15, new DateTime(2021, 7, 9, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5209), true, 4, 2, 14, new DateTime(2021, 6, 24, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5206), 73031, 4, null },
                    { 6, new DateTime(2021, 6, 14, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5116), true, 2, 2, 14, new DateTime(2021, 5, 8, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5114), 51111, 4, null },
                    { 11, new DateTime(2021, 6, 25, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5184), false, 1, 0, 13, new DateTime(2021, 6, 24, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5181), 6360, 3, null },
                    { 4, new DateTime(2021, 7, 5, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5104), true, 2, 4, 12, new DateTime(2021, 6, 14, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5101), 53300, 2, null },
                    { 13, new DateTime(2021, 5, 22, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5196), true, 3, 2, 17, new DateTime(2021, 5, 12, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5194), 415300, 2, null },
                    { 8, new DateTime(2021, 5, 23, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5129), false, 2, 3, 17, new DateTime(2021, 5, 19, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5126), 421300, 3, null },
                    { 10, new DateTime(2021, 7, 21, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5178), true, 3, 2, 23, new DateTime(2021, 6, 14, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5175), 960342, 2, null },
                    { 5, new DateTime(2021, 5, 27, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5110), false, 2, 3, 25, new DateTime(2021, 5, 12, 21, 39, 15, 954, DateTimeKind.Local).AddTicks(5107), 100600, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId1",
                table: "Bookings",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ApartmentId",
                table: "Reviews",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId1",
                table: "Reviews",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_ApartmentId",
                table: "Rooms",
                column: "ApartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Apartments");
        }
    }
}
