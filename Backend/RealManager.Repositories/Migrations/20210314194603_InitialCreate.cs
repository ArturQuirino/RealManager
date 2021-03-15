using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RealManager.Repositories.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdLeague = table.Column<Guid>(nullable: false),
                    Season = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    TeamName = table.Column<string>(nullable: true),
                    Matches = table.Column<int>(nullable: false),
                    Won = table.Column<int>(nullable: false),
                    Drawn = table.Column<int>(nullable: false),
                    Lost = table.Column<int>(nullable: false),
                    GoalsFor = table.Column<int>(nullable: false),
                    GoalsAgainst = table.Column<int>(nullable: false),
                    GoalDifference = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeTeamId = table.Column<Guid>(nullable: false),
                    AwayTeamId = table.Column<Guid>(nullable: false),
                    HomeTeamName = table.Column<string>(nullable: true),
                    AwayTeamName = table.Column<string>(nullable: true),
                    HomeGoals = table.Column<int>(nullable: false),
                    AwayGoals = table.Column<int>(nullable: false),
                    FinalResult = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchEventDescriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MatchEventId = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEventDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HomeGoals = table.Column<int>(nullable: false),
                    AwayGoals = table.Column<int>(nullable: false),
                    MatchId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Pace = table.Column<int>(nullable: false),
                    Shoot = table.Column<int>(nullable: false),
                    Pass = table.Column<int>(nullable: false),
                    Drible = table.Column<int>(nullable: false),
                    Defence = table.Column<int>(nullable: false),
                    Physical = table.Column<int>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Overall = table.Column<int>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Starter1Id = table.Column<Guid>(nullable: false),
                    Starter2Id = table.Column<Guid>(nullable: false),
                    Starter3Id = table.Column<Guid>(nullable: false),
                    Starter4Id = table.Column<Guid>(nullable: false),
                    Starter5Id = table.Column<Guid>(nullable: false),
                    Starter6Id = table.Column<Guid>(nullable: false),
                    Starter7Id = table.Column<Guid>(nullable: false),
                    Starter8Id = table.Column<Guid>(nullable: false),
                    Starter9Id = table.Column<Guid>(nullable: false),
                    Starter10Id = table.Column<Guid>(nullable: false),
                    Starter11Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Leagues");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "MatchEventDescriptions");

            migrationBuilder.DropTable(
                name: "MatchEvents");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
