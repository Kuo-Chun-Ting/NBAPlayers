using System;
using System.Threading.Tasks;

namespace NBA.EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertData();
            Console.WriteLine("Success!");
            Console.ReadKey();
        }

        private static void InsertData()
        {
            using (var context = new NBAContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                // Adds a publisher
                var player = new PlayerModel
                {
                    id = Guid.NewGuid().ToString(),
                    name = "test",
                    team_name = "gws"
                };
                context.Players.Add(player);

                // Saves changes
                context.SaveChanges();
            }
        }

        private static void WriteMsg(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
