using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.Storage
{
    public class ToastmasterContext : DbContext
    {
        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Speech> Speeches { get; set; }
        public DbSet<SpeechType> SpeechTypes { get; set; }

        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ToastmasterTools.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Speaker>()
                .HasMany(s => s.Speeches);

        }

        public async Task Seed()
        {
            try
            {
                AddDefaultLessons();
            }
            catch (Exception exception)
            {
            }
        }

        private void AddDefaultLessons()
        {
            ListOfLessons = new List<SpeechType>
            {
                new SpeechType
                {
                    Name = "Ice Breaker",
                    GreenCardTime = new CardTime(4, 0),
                    YellowCardTime = new CardTime(5, 0),
                    RedCardTime = new CardTime(6, 0)
                },
                new SpeechType
                {
                    Name = "Standard Breaker",
                    GreenCardTime = new CardTime(5, 0),
                    YellowCardTime = new CardTime(6, 00),
                    RedCardTime = new CardTime(7, 0)
                },
                new SpeechType
                {
                    Name = "Test2",
                    GreenCardTime = new CardTime(7, 0),
                    YellowCardTime = new CardTime(8, 0),
                    RedCardTime = new CardTime(9, 0)
                }, new SpeechType
                {
                    Name = "Advanced Breaker",
                    GreenCardTime = new CardTime(7, 0),
                    YellowCardTime = new CardTime(8, 0),
                    RedCardTime = new CardTime(9, 0)
                },
                new SpeechType
                {
                    Name = "Speech Evaluator",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
                new SpeechType
                {
                    Name = "AH Counter",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
                new SpeechType
                {
                    Name = "Gramatician",
                    GreenCardTime = new CardTime(3, 0),
                    YellowCardTime = new CardTime(3, 30),
                    RedCardTime = new CardTime(4, 0)
                },
                new SpeechType
                {
                    Name = "Timer",
                    GreenCardTime = new CardTime(2, 0),
                    YellowCardTime = new CardTime(2, 30),
                    RedCardTime = new CardTime(3, 0)
                },
            };
        }

        public static List<SpeechType> ListOfLessons { get; set; }
    }
}