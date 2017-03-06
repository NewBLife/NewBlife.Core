using AVFoundation;
using Foundation;
using System.Threading.Tasks;

namespace AudioPlay.Platform
{
    /// <summary>
    /// AudioPlay Implementation
    /// </summary>
    public class AudioPlayImplementation : IAudioPlay
    {
        AVAudioPlayer player = null;

        public void InitPalyer(string fileUrl)
        {
            NSError _err = null;
            player = AVAudioPlayer.FromData(NSData.FromUrl(NSUrl.FromString(fileUrl)), out _err);
            player.Volume = 100f;
            player.FinishedPlaying += (s, e) =>
            {
                player = null;
            };

        }

        public void Pasue()
        {
            if (player.Playing)
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
                     InitPalyer(fileUrl);
                     player.PrepareToPlay();
                     player.Play();
                 }
                 else
                 {
                     if (!player.Playing)
                     {
                         player.Play();
                     }
                 }
             });
        }

        public void Stop()
        {
            if (player.Playing)
            {
                player.Stop();
            }
        }
    }
}