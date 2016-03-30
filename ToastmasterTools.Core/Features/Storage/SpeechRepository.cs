using System;
using System.Threading.Tasks;
using Microsoft.Data.Entity;
using ToastmasterTools.Core.Models;

namespace ToastmasterTools.Core.Features.Storage
{
    public class SpeechRepository : ISpeechRepository
    {
        public async Task SaveSpeech(Speech speech, string speakerName, string speechName)
        {
            speech.Date = DateTime.Now;
            using (var context = new ToastmasterContext())
            {
                await context.DisplayDbData(context);
                var speaker = await context.Speakers.FirstOrDefaultAsync(s => s.Name == speakerName);
                var speechType =
                    await context.SpeechTypes.FirstOrDefaultAsync(s => s.Name == speechName);
                speech.Speaker = speaker;
                speech.SpeechType = speechType;
                context.Speeches.Add(speech);
                await context.SaveChangesAsync();
                await context.DisplayDbData(context);
            }
        }
    }
}
