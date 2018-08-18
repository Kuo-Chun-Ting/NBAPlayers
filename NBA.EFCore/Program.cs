using System;
using System.Threading.Tasks;

namespace NBA.EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InsertData();
                Console.WriteLine("Success!");
            }
            catch (Exception e)
            {

                WriteMsg(e.ToString());
            }
            Console.ReadKey();
        }

        private static void InsertData()
        {
            using (var context = new TestContext())
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
