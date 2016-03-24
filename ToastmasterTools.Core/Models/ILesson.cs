using System.ComponentModel;

namespace ToastmasterTools.Core.Models
{
    public interface ILesson
    {
        string Name { get; set; }
        CardTime GreenCardTime { get; set; }
        CardTime YellowCardTime { get; set; }
        CardTime RedCardTime { get; set; }
        event PropertyChangedEventHandler PropertyChanged;
    }
}