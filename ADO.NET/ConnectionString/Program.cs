﻿using Microsoft.Extensions.Configuration;

namespace ConnectionString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                .Build();

            Console.WriteLine(configuration.GetSection("ConnectionStrings")["DefaultString"]);
        }
    }
}
