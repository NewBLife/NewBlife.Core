using Android.Content;
using Android.Media;
using Android.OS;
using System;
using System.Threading.Tasks;

namespace AudioPlay.Platform
{
    /// <summary>
    /// AudioPlay Implementation
    /// </summary>
    public class AudioPlayImplementation : IAudioPlay
    {
        MediaPlayer player = null;
        public Context ApplicationContext { get; private set; } = Android.App.Application.Context;

        public void InitPalyer()
        {
            player = new MediaPlayer();
            //Tell our player to sream music
            player.SetAudioStreamType(Stream.Music);
            //Wake mode will be partial to keep the CPU still running under lock screen
            player.SetWakeMode(ApplicationContext, WakeLockFlags.Partial);
            //When we have prepared the song start playback
            player.Prepared += (sender, args) => player.Start();
            //When we have reached the end of the song stop ourselves, however you could signal next track here.
            player.Completion += (sender, args) => Stop();
            player.Error += (sender, args) =>
            {
                //playback error
                Console.WriteLine("Error in playback resetting: " + args.What);
                Stop();//this will clean up and reset properly.
            };

        }

        public void Pasue()
        {
            if (player != null && player.IsPlaying)
            {
                player.Pause();
            }
        }

        public async Task PlayAsync(string fileUrl)
        {
            if (player == null)
            {
                InitPalyer();

                await player.SetDataSourceAsync(ApplicationContext, Android.Net.Uri.Parse(fileUrl));
                player.PrepareAsync();
            }
            else
            {
                if (!player.IsPlaying)
                {
                    player.Start();
                }
            }
        }

        public void Stop()
        {
            if (player != null)
            {
                if (player.IsPlaying)
                {
                    player.Stop();
                }
                player.Release();
                player = null;
            }
        }
    }
}