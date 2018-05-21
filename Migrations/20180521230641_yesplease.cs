using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Beltretake.Migrations
{
    public partial class yesplease : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(nullable: true),
                    first = table.Column<string>(nullable: true),
                    last = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "_activities",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creatorid = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    duration = table.Column<TimeSpan>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    start = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__activities", x => x.id);
                    table.ForeignKey(
                        name: "FK__activities__users_creatorid",
                        column: x => x.creatorid,
                        principalTable: "_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_joins",
                columns: table => new
                {
                    joinid = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityid = table.Column<int>(nullable: false),
                    userid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__joins", x => x.joinid);
                    table.ForeignKey(
                        name: "FK__joins__activities_activityid",
                        column: x => x.activityid,
                        principalTable: "_activities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__joins__users_userid",
                        column: x => x.userid,
                        principalTable: "_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__activities_creatorid",
                table: "_activities",
                column: "creatorid");

            migrationBuilder.CreateIndex(
                name: "IX__joins_activityid",
                table: "_joins",
                column: "activityid");

            migrationBuilder.CreateIndex(
                name: "IX__joins_userid",
                table: "_joins",
                column: "userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_joins");

            migrationBuilder.DropTable(
                name: "_activities");

            migrationBuilder.DropTable(
                name: "_users");
        }
    }
}
