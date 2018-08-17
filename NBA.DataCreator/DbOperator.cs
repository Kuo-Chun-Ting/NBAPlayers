using AutoMapper;
using NBA.Client;
using NBA.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.DataCreator
{
    public class DbOperator
    {
        public DbOperator()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Player, PlayerDB>();
            });
        }

        public async Task<bool> PourData()
        {
            try
            {
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
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
