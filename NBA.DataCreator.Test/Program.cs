using AutoMapper;
using NBA.Client;
using NBA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.DataCreator.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {

            try
            {
                Mapper.Initialize(config =>
                    {
                        config.CreateMap<Player, PlayerDB>();
                    });

                NBAClient client = new NBAClient();
                var players = await client.GetPlayersAsync();
                using (var context = new NBAPlayerContext())
                {
                    foreach (var p in players)
                    {
                        var playerDB = Mapper.Map<Player, PlayerDB>(p);
                        playerDB.Id = Guid.NewGuid().ToString();
                        context.Player.Add(playerDB);
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                WriteMsg(e.ToString());
                throw;
            }

            Console.ReadKey();
        }

        private static void InsertData()
        {
            using (var context = new NBAPlayerContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var player = new PlayerDB
                {
                    Id = Guid.NewGuid().ToString(),
                    name = "test",
                    team_name = "gws"
                };
                context.Player.Add(player);

                // Saves changes
                context.SaveChanges();
            }
        }


        private static void PrintData()
        {
            // Gets and prints all books in database
            using (var context = new NBAPlayerContext())
            {
                var players = context.Player;
                foreach (var p in players)
                {
                    var data = new StringBuilder();
                    data.AppendLine($"ISBN: {p.Id}");
                    data.AppendLine($"Title: {p.name}");
                    data.AppendLine($"Publisher: {p.team_name}");
                    Console.WriteLine(data.ToString());
                }
            }
        }

        private static void WriteMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
