using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        }

        public async Task Seed()
        {
            try
            {
                await AddDefaultLessons();
            }
            catch (Exception exception)
            {
            }
        }

        public async Task DisplayDbData(ToastmasterContext context)
        {
            var speakers = await context.Speakers.ToListAsync();
            Debug.WriteLine("Speakers count: " + speakers.Count);
            foreach (var speaker in speakers)
            {
                Debug.WriteLine("Speaker: " + speaker.Name);
                Debug.WriteLine("SpeakerId: " + speaker.SpeakerId);
            }

            var speechTypes = await context.SpeechTypes.ToListAsync();
            Debug.WriteLine("Speech types count: " + speechTypes.Count);
            foreach (var speechType in speechTypes)
            {
                Debug.WriteLine("Speech: " + speechType.Name);
                Debug.WriteLine("SpeechId: " + speechType.SpeechTypeId);
            }

            var speechList = await context.Speeches.ToListAsync();
            Debug.WriteLine("Speeches count: " + speechList.Count);
            foreach (var speech in speechList)
            {
                Debug.WriteLine("Speech id: " + speech.SpeechId);
                Debug.WriteLine("Speech date: " + speech.Date);
                Debug.WriteLine("Speech type: " + speech.SpeechType.Name);
            }
            var speeches = await context.Speeches.Include(s => s.SpeechType).Include(s => s.Speaker).ToListAsync();
            foreach (var speech in speeches)
            {
                Debug.WriteLine("Speech id: " + speech.SpeechId);
                Debug.WriteLine("Speech date: " + speech.Date);
                Debug.WriteLine("Speech type: " + speech.SpeechType.Name);
            }
        }

        private async Task AddDefaultLessons()
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
            using (var context = new ToastmasterContext())
            {
                var count = await context.SpeechTypes.CountAsync();
                if (count > 0)
                    return;
                context.SpeechTypes.AddRange(ListOfLessons);
                await context.SaveChangesAsync();
            }
        }

        public static List<SpeechType> ListOfLessons { get; set; }
    }
}