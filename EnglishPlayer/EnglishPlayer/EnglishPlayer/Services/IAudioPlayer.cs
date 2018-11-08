using EnglishPlayer.Media;
using System;
using System.Threading.Tasks;

namespace EnglishPlayer.Services
{
    public interface IAudioPlayer
    {

        //TimeSpan Position { get; set; }

        //TimeSpan Duration { get; set; }

        //TimeSpan Buffered { get; set; }

        Func<TimeSpan, TimeSpan, bool> PositionChanged { get; set; }

        Task Play(MediaFile mediaFile = null);

        Task Pause();

        Task Stop();

        Task Seek(TimeSpan position);
    }
}
