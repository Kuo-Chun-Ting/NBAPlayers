using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.EFCore
{
    public class PlayerModel
    {
        public string id { get; set; }
        public string Addition { get; set; }
        public string name { get; set; }
        public string team_acronym { get; set; }
        public string team_name { get; set; }
        public string games_played { get; set; }
        public string minutes_per_game { get; set; }
        public string field_goals_attempted_per_game { get; set; }
        public string field_goals_made_per_game { get; set; }
        public string field_goal_percentage { get; set; }
        public string free_throw_percentage { get; set; }
        public string three_point_attempted_per_game { get; set; }
        public string three_point_made_per_game { get; set; }
        public string three_point_percentage { get; set; }
        public string points_per_game { get; set; }
        public string offensive_rebounds_per_game { get; set; }
        public string defensive_rebounds_per_game { get; set; }
        public string rebounds_per_game { get; set; }
        public string assists_per_game { get; set; }
        public string steals_per_game { get; set; }
        public string blocks_per_game { get; set; }
        public string turnovers_per_game { get; set; }
        public string player_efficiency_rating { get; set; }
    }
}
