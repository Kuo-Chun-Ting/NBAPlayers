using System;
using System.Threading.Tasks;

namespace NBA.Client.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NBAClient client = new NBAClient();
            var players = await client.GetPlayersAsync();
            WriteMsg($"Name\t\tTeam\t\t\tTeamAcronym");

            foreach (var p in players)
            {
                WriteMsg($"{p.name}\t{p.team_name}\t{p.team_acronym}");
            }
            Console.ReadKey();
        }

        private static void WriteMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
