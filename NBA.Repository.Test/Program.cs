using NBA.Repository.Interface;
using NBA.Repository.OfficialMysql;
using NBA.Repository.PomeloMysql;
using System;
using System.Collections.Generic;

namespace NBA.Repository.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<INBARepository> repoList = new List<INBARepository>()
                {
                    new MysqlOfficialRepo(),
                    new MysqlPomeloRepo()
                };


                foreach (var r in repoList)
                {
                    try
                    {
                        r.InsertTest();

                        Console.WriteLine($"{r.GetType()} Success!!!");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{r.GetType()} Failed!!!");
                        Console.WriteLine(e.ToString());
                    }
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadKey();
        }
    }
}
