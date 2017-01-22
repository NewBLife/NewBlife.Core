using System;
using System.Threading.Tasks;
using Windows.Media.Playback;

namespace AudioPlay.Platform
{
    /// <summary>
    /// AudioPlay Implementation
    /// </summary>
    public class AudioPlayImplementation : IAudioPlay
    {
        MediaPlayer player = null;
        public void InitPalyer()
        {
            player = BackgroundMediaPlayer.Current;
        }
        public void Pasue()
        {
            if (player.CurrentState == MediaPlayerState.Playing
                && player.CanPause)
            {
                player.Pause();
            }
        }

        public async Task PlayAsync(string fileUrl)
        {
            await Task.Run(() =>
            {
                if (player == null)
                {
                    InitPalyer();
                    player.SetUriSource(new Uri(fileUrl, UriKind.Absolute));
                    player.Play();
                }
                else
                {
                    if (player.CurrentState != MediaPlayerState.Playing)
                    {
                        player.Play();
                    }
                }
            });
        }

        public void Stop()
        {
            if (player.CurrentState == MediaPlayerState.Playing)
            {
                player.Pause();
                player = null;
            }
        }
    }
}