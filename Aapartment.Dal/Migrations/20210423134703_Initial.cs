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
                    ApartmentId = table.Column<int>(nullable: false)
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
                name: "Services",
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
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Apartments_ApartmentId",
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
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<int>(nullable: true),
                    ApartmentId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<int>(nullable: true),
                    RoomId = table.Column<int>(nullable: false)
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
                    { 3, "Take an early morning stroll and enjoy the Trevi Fountain without the tourists. Wander around the historic streets while the city sleeps, then head back for a morning coffee at this urban-chic studio with a suspended loft bedroom.", "b61d0cf5-dd61-4b54-9f81-80bb312f77f0", "Langmoon Hotel", "Peking", "China", "Chicaego street 45", 11004 },
                    { 2, "Unwind at this stunning French Provencal beachside cottage. The house was lovingly built with stone floors, high-beamed ceilings, and antique details for a luxurious yet charming feel. Enjoy the sea and mountain views from the pool and lush garden. The house is located in the enclave of Llandudno Beach, a locals-only spot with unspoilt, fine white sand and curling surfing waves. Although shops and restaurants are only a five-minute drive away, the area feels peaceful and secluded.", "57c4e158-e07c-459e-a724-9ef65ab4a0d0", "Mercur Hotel", "Madrid", "Spain", "Bueno street 45", 3424 },
                    { 1, "Pretend you are lost in a magical forest as you perch on a log or curl up in the swinging chair. Soak in the tub, then fall asleep in a heavenly bedroom with cloud-painted walls and twinkling lights. And when you wake up, the espresso machine awaits.", "5789f5af-62ba-4361-a432-fccb268e1a90", "Panama Hotel", "New York", "USA", "Pearl street 72", 5504 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "2116fbb0-3c38-4841-b36f-9b07629e2d6a", "ADMIN", "ADMIN" },
                    { 2, "658b7766-9d80-4986-a8d3-9ba7a555e628", "GUEST", "GUEST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "bc57f428-e735-4ccf-baa8-dba15599cc54", "bbotond25@gmail.com", true, "Botond", "Barta", false, null, null, null, "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw==", "06/30-152-5123", false, null, false, "baaart" },
                    { 3, 0, "9324bee8-474e-46eb-aafd-6b765cada70a", "hmate@gmail.com", true, "Herczku", "Máté", false, null, null, null, "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw==", "06/30-152-5123", false, null, false, "herczkum" },
                    { 4, 0, "6cd3a24e-6a1b-4b57-b6cc-feace8dd4dd6", "kbela@gmail.com", true, "Kis", "Béla", false, null, null, null, "AQAAAAEAACcQAAAAEMsPWENyxbGqK+PMv0F8Uv8/llEInzFl7oWMQAYeFYE73P5FPn9gMJGX0Q47dL1bbw==", "06/30-152-5123", false, null, false, "kbela" }
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
                    { 3, 3, "I could find a better place, but it's ok.", new DateTime(2021, 4, 23, 15, 47, 3, 21, DateTimeKind.Local).AddTicks(300), 3, 4, null },
                    { 2, 2, "There are a lot of bugs here!", new DateTime(2021, 4, 23, 15, 47, 3, 21, DateTimeKind.Local).AddTicks(277), 1, 3, null },
                    { 1, 1, "One of the best apartment here.", new DateTime(2021, 4, 23, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(9411), 4, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "ApartmentId", "IsAvailabe", "MaxNumberOfPeople", "PricePerAdult", "PricePerChild", "RoomNumber" },
                values: new object[,]
                {
                    { 5, 1, true, 4, 5050, 2700, 105 },
                    { 4, 1, true, 4, 6000, 3400, 104 },
                    { 3, 1, false, 7, 5400, 2000, 103 },
                    { 2, 1, true, 3, 5500, 2450, 102 },
                    { 1, 1, true, 4, 5000, 2400, 101 },
                    { 10, 2, true, 4, 5050, 2700, 105 },
                    { 9, 2, true, 4, 6000, 3400, 104 },
                    { 11, 3, true, 4, 5000, 2400, 101 },
                    { 7, 2, true, 3, 5500, 2450, 102 },
                    { 6, 2, true, 4, 5000, 2400, 101 },
                    { 12, 3, true, 3, 5500, 2450, 102 },
                    { 13, 3, false, 7, 5400, 2000, 103 },
                    { 14, 3, true, 4, 6000, 3400, 104 },
                    { 15, 3, true, 4, 5050, 2700, 105 },
                    { 8, 2, false, 7, 5400, 2000, 103 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "ApartmentId", "Icon", "Name" },
                values: new object[,]
                {
                    { 6, 1, "fas fa-umbrella-beach", "Terrace" },
                    { 5, 1, "fas fa-users", "Family rooms" },
                    { 4, 1, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 3, 1, "fas fa-shuttle-van", "Airport shuttle" },
                    { 2, 1, "fas fa-paw", "Pets allowed" },
                    { 1, 1, "fas fa-wifi", "Free wifi" },
                    { 13, 3, "fas fa-wifi", "Free wifi" },
                    { 15, 3, "fas fa-shuttle-van", "Airport shuttle" },
                    { 16, 3, "fas fa-smoking-ban", "Non-smoking rooms" },
                    { 17, 3, "fas fa-users", "Family rooms" },
                    { 12, 2, "fas fa-umbrella-beach", "Terrace" },
                    { 11, 2, "fas fa-users", "Family rooms" },
                    { 18, 3, "fas fa-umbrella-beach", "Terrace" },
                    { 9, 2, "fas fa-shuttle-van", "Airport shuttle" },
                    { 8, 2, "fas fa-paw", "Pets allowed" },
                    { 7, 2, "fas fa-wifi", "Free wifi" },
                    { 14, 3, "fas fa-paw", "Pets allowed" },
                    { 10, 2, "fas fa-smoking-ban", "Non-smoking rooms" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EndDate", "IsPaid", "NumberOfAdults", "NumberOfChildren", "RoomId", "StartDate", "SumPrice", "UserId", "UserId1" },
                values: new object[] { 3, new DateTime(2021, 5, 15, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6109), true, 1, 0, 10, new DateTime(2021, 5, 8, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6106), 212330, 4, null });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EndDate", "IsPaid", "NumberOfAdults", "NumberOfChildren", "RoomId", "StartDate", "SumPrice", "UserId", "UserId1" },
                values: new object[] { 1, new DateTime(2021, 5, 5, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(4271), true, 3, 2, 2, new DateTime(2021, 4, 27, 15, 47, 3, 18, DateTimeKind.Local).AddTicks(836), 160300, 2, null });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "EndDate", "IsPaid", "NumberOfAdults", "NumberOfChildren", "RoomId", "StartDate", "SumPrice", "UserId", "UserId1" },
                values: new object[] { 2, new DateTime(2021, 5, 3, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6067), false, 2, 3, 5, new DateTime(2021, 4, 28, 15, 47, 3, 20, DateTimeKind.Local).AddTicks(6036), 260300, 3, null });

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

            migrationBuilder.CreateIndex(
                name: "IX_Services_ApartmentId",
                table: "Services",
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
                name: "Services");

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
