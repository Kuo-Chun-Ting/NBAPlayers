using NBA.Repository.Interface;
using NBA.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository.OfficialMysql
{
    public class MysqlOfficialRepo: INBARepository
    {
        private PlayerContext _context;
        public void InsertTest()
        {
            using (_context = new PlayerContext())
            {
                // Creates the database if not exists
                _context.Database.EnsureCreated();


                // Adds a Player
                var player = new PlayerModel
                {
                    id = Guid.NewGuid().ToString(),
                    name = "official mysql provider"
                };
                _context.Players.Add(player);

                // Saves changes
                _context.SaveChanges();
            }
        }
    }
}
