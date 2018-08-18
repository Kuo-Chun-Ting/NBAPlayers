using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NBA.EFCore.OfficialProvider.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Addition = table.Column<string>(nullable: true),
                    assists_per_game = table.Column<string>(nullable: true),
                    blocks_per_game = table.Column<string>(nullable: true),
                    defensive_rebounds_per_game = table.Column<string>(nullable: true),
                    field_goal_percentage = table.Column<string>(nullable: true),
                    field_goals_attempted_per_game = table.Column<string>(nullable: true),
                    field_goals_made_per_game = table.Column<string>(nullable: true),
                    free_throw_percentage = table.Column<string>(nullable: true),
                    games_played = table.Column<string>(nullable: true),
                    minutes_per_game = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    offensive_rebounds_per_game = table.Column<string>(nullable: true),
                    player_efficiency_rating = table.Column<string>(nullable: true),
                    points_per_game = table.Column<string>(nullable: true),
                    rebounds_per_game = table.Column<string>(nullable: true),
                    steals_per_game = table.Column<string>(nullable: true),
                    team_acronym = table.Column<string>(nullable: true),
                    team_name = table.Column<string>(nullable: true),
                    three_point_attempted_per_game = table.Column<string>(nullable: true),
                    three_point_made_per_game = table.Column<string>(nullable: true),
                    three_point_percentage = table.Column<string>(nullable: true),
                    turnovers_per_game = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
