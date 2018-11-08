using EnglishPlayer.Media;
using EnglishPlayer.Services;
using System;
using System.Threading.Tasks;
using Windows.Media.Core;
using Windows.Media.Playback;

namespace EnglishPlayer.UWP.Services
{
    public class AudioPlayer : IAudioPlayer
    {
        MediaPlayer player = null;

        //public TimeSpan Position { get; set; }
        //public TimeSpan Duration { get; set; }
        //public TimeSpan Buffered { get; set; }
        public Func<TimeSpan, TimeSpan, bool> PositionChanged { get; set; }

        public void InitPlayer()
        {
            player = new MediaPlayer();
            player.PlaybackSession.PositionChanged += PlaybackSession_PositionChanged;
        }

        private void PlaybackSession_PositionChanged(MediaPlaybackSession sender, object args)
        {
            PositionChanged(player.PlaybackSession.Position, player.PlaybackSession.NaturalDuration);
        }

        public async Task Pause()
        {
            await Task.Run(() =>
            {
                if (player.PlaybackSession.PlaybackState == MediaPlaybackState.Playing
                       && player.PlaybackSession.CanPause)
                {

                    player.Pause();

                }
            });
        }

        public async Task Play(MediaFile mediaFile = null)
        {
            await Task.Run(() =>
            {
                if (mediaFile != null)
                {
                    if (player == null)
                    {
                        InitPlayer();
                        player.Source = MediaSource.CreateFromUri(new Uri(mediaFile.Url));
                    }

                    if (player.PlaybackSession.PlaybackState != MediaPlaybackState.Playing)
                    {
                        player.Play();
                    }
                }
            });
        }

        public async Task Seek(TimeSpan position)
        {
            await Task.FromResult(true);
        }

        public async Task Stop()
        {
            await Task.Run(() =>
            {
                if (player?.PlaybackSession.PlaybackState == MediaPlaybackState.Playing)
                {
                    player.Pause();
                    player.Dispose();
                    player = null;
                }
            });
        }
    }
}
