using AudioPlay;
using AudioPlay.Platform;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace AudioPlayTest.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new AudioPlayTest.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IAudioPlay, AudioPlayImplementation>();
        }
    }

}
