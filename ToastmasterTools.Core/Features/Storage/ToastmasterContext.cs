using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Features.AHCounter;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.Storage
{
    public class ToastmasterContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        public DbSet<Speech> Speeches { get; set; }

        public DbSet<SpeechType> SpeechTypes { get; set; }

        public DbSet<Counter> Counters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Toastmasters.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SpeechType>()
                .HasIndex(s => s.Name)
                .IsUnique();
        }

        public async Task Seed()
        {
            try
            {
                await AddDefaultLessons();
                await SaveChangesAsync();
            }
            catch (Exception exception)
            {
            }
        }

        private async Task AddDefaultLessons()
        {
            var listOfLessons = new List<SpeechType>
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
            var existingSpeeches = await SpeechTypes.ToListAsync();
            var newSpeeches = listOfLessons.Where(l => existingSpeeches.Any(e => e.Name == l.Name) == false);
            SpeechTypes.AddRange(newSpeeches);
        }
    }
}