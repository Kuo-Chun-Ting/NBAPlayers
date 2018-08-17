﻿using System;
using System.Text;

namespace NBA.DataCreator.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                InsertData();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                WriteMsg(e.ToString());
            }

            try
            {
                PrintData();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                WriteMsg(e.ToString());
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
                var player = new Player
                {
                    Id=Guid.NewGuid().ToString(),
                    name = "test",
                    team_name="gws"
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