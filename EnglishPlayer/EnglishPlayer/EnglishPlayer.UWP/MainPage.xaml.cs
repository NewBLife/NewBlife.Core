using EnglishPlayer.Services;
using EnglishPlayer.UWP.Services;
using Prism;
using Prism.Ioc;

namespace EnglishPlayer.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new EnglishPlayer.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAudioPlayer, AudioPlayer>();
        }
    }
}
