using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BookBorrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBorrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookBorrows_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BookBorrows_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookTags_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Birthdate", "CreatedAt", "Email", "FirstName", "IsDeleted", "LastName", "LastUpdatedAt", "PasswordHash", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, new DateOnly(1990, 1, 1), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1178), "johndoe@example.com", "John", false, "Doe", new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1179), "hashedpassword1", "+123456789", "Customer" },
                    { 2, new DateOnly(1985, 6, 15), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1185), "janesmith@example.com", "Jane", false, "Smith", new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1186), "hashedpassword2", "+987654321", "Employee" },
                    { 3, new DateOnly(1982, 10, 20), new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1190), "aliceauthor@example.com", "Alice", false, "Johnson", new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1190), "hashedpassword3", "+192837465", "Author" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Books related to programming languages and software development.", "Programming" },
                    { 2, "Novels and stories that are imaginative and not based on real events.", "Fiction" },
                    { 3, "Books that are factual and based on real events and information.", "Non-Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1672), "C#" },
                    { 2, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1675), "ASP.NET" },
                    { 3, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1678), "Web Development" },
                    { 4, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1680), "Fantasy" },
                    { 5, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1683), "Biography" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "AppUserId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AppUserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "AppUserId", "Title" },
                values: new object[] { 1, 2, "Library Manager" });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "C# Programming" },
                    { 2, 1, "Web Development" },
                    { 3, 2, "Fantasy" },
                    { 4, 3, "Biography" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedAt", "Description", "PublishedDate", "SubcategoryId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1804), "An advanced guide to C# programming.", new DateOnly(2019, 3, 12), 1, "Mastering C#" },
                    { 2, 1, 1, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1811), "A practical guide to building web applications using ASP.NET Core.", new DateOnly(2020, 7, 25), 2, "ASP.NET Core in Action" }
                });

            migrationBuilder.InsertData(
                table: "BookBorrows",
                columns: new[] { "Id", "BookId", "CreatedAt", "CustomerId", "ExpiryDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1894), 1, new DateTime(2024, 11, 7, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1895) },
                    { 2, 2, new DateTime(2024, 10, 24, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1902), 1, new DateTime(2024, 11, 7, 8, 0, 57, 17, DateTimeKind.Utc).AddTicks(1903) }
                });

            migrationBuilder.InsertData(
                table: "BookTags",
                columns: new[] { "Id", "BookId", "TagId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 },
                    { 4, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Authors_AppUserId",
                table: "Authors",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_BookId",
                table: "BookBorrows",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookBorrows_CustomerId",
                table: "BookBorrows",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubcategoryId",
                table: "Books",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_BookId",
                table: "BookTags",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookTags_TagId",
                table: "BookTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AppUserId",
                table: "Customers",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_AppUserId",
                table: "Employees",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBorrows");

            migrationBuilder.DropTable(
                name: "BookTags");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "AppUsers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
