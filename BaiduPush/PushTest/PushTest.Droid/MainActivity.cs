
using Android.App;
using Android.Content.PM;
using Android.OS;
using Com.Baidu.Android.Pushservice;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace PushTest.Droid
{
    [Activity(Label = "PushTest", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.tabs;
            ToolbarResource = Resource.Layout.toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            PushManager.StartWork(this.ApplicationContext, PushConstants.LoginTypeApiKey, "trcK2e7vlMfN0StPx8n8Pb4M");
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {

        }
    }
}

