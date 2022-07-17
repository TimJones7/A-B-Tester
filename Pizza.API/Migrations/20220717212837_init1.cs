using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza.API.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 75, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DomElement = table.Column<string>(type: "TEXT", nullable: false),
                    HtmlId = table.Column<string>(type: "TEXT", nullable: true),
                    Classes = table.Column<string>(type: "TEXT", nullable: true),
                    Styles = table.Column<string>(type: "TEXT", nullable: true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    ParentId = table.Column<int>(type: "INTEGER", nullable: true),
                    FirstChildId = table.Column<int>(type: "INTEGER", nullable: true),
                    NextChildId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elements_Elements_FirstChildId",
                        column: x => x.FirstChildId,
                        principalTable: "Elements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elements_Elements_NextChildId",
                        column: x => x.NextChildId,
                        principalTable: "Elements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elements_Elements_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Elements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResultedInOrder = table.Column<bool>(type: "INTEGER", nullable: false),
                    TotalSpent = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Components_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementSession",
                columns: table => new
                {
                    ElementsId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSession", x => new { x.ElementsId, x.SessionsId });
                    table.ForeignKey(
                        name: "FK_ElementSession_Elements_ElementsId",
                        column: x => x.ElementsId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementSession_Sessions_SessionsId",
                        column: x => x.SessionsId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Interactions",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false),
                    ElementId = table.Column<int>(type: "INTEGER", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false),
                    OccuranceDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interactions", x => new { x.CustomerId, x.SessionId, x.ElementId });
                    table.ForeignKey(
                        name: "FK_Interactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactions_Elements_ElementId",
                        column: x => x.ElementId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interactions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ElementId",
                table: "Components",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_FirstChildId",
                table: "Elements",
                column: "FirstChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_NextChildId",
                table: "Elements",
                column: "NextChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Elements_ParentId",
                table: "Elements",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementSession_SessionsId",
                table: "ElementSession",
                column: "SessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_ElementId",
                table: "Interactions",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_SessionId",
                table: "Interactions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CustomerId",
                table: "Sessions",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "ElementSession");

            migrationBuilder.DropTable(
                name: "Interactions");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
