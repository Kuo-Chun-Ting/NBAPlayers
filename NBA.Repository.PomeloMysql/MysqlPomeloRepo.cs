using NBA.Repository.Interface;
using NBA.Repository.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Repository.PomeloMysql
{
    public class MysqlPomeloRepo: INBARepository
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
                    name = "pomelo mysql provider"
                };
                _context.Players.Add(player);

                // Saves changes
                _context.SaveChanges();
            }
        }
    }
}
