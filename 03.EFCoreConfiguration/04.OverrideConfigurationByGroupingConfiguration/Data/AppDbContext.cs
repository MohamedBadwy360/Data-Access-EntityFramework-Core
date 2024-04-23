﻿using _04.OverrideConfigurationByGroupingConfiguration.Data.Config;
using Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring using IEntityTypeConfiguration (Grouping Configurations)
            // Individual Call
            new UserConfiguration().Configure(modelBuilder.Entity<User>());

            new TweetConfiguration().Configure(modelBuilder.Entity<Tweet>());

            new CommentConfiguration().Configure(modelBuilder.Entity<Comment>());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultString")!;

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}