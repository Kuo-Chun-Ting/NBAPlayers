using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NBA.Client
{
    public class NBAClient
    {
        private HttpClient _client = new HttpClient();
        private Uri _baseAddress;

        public Uri BaseAddress
        {
            get { return _baseAddress; }
            set
            {
                _baseAddress = value;
                _client.BaseAddress = value;
            }
        }


        public NBAClient()
        {
            BaseAddress = new Uri("https://nba-players.herokuapp.com");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void ShowPlayer(PlayerFromOpen player)
        {
            Console.WriteLine($"Name: {player.name}\tTeam: " +
                $"{player.team_name}\tTeamAcronym: {player.team_acronym}");
        }

       public async Task<Uri> CreatePlayerAsync(PlayerFromOpen player)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                "api/Players", player);
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }

        public async Task<List<PlayerFromOpen>> GetPlayersAsync()
        {
           List<PlayerFromOpen> players = null;
            HttpResponseMessage response = await _client.GetAsync("/players-stats");
            if (response.IsSuccessStatusCode)
            {
                players = await response.Content.ReadAsAsync<List<PlayerFromOpen>>();
            }
            return players;
        }

        public async Task<PlayerFromOpen> UpdatePlayerAsync(PlayerFromOpen Player)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync(
                $"api/Players/{Player.name}", Player);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated Player from the response body.
            Player = await response.Content.ReadAsAsync<PlayerFromOpen>();
            return Player;
        }

        public async Task<HttpStatusCode> DeletePlayerAsync(string id)
        {
            HttpResponseMessage response = await _client.DeleteAsync(
                $"api/Players/{id}");
            return response.StatusCode;
        }
    }
}
