using EnglishPlayer.Media;
using EnglishPlayer.Services;
using Prism.Commands;
using Prism.Navigation;

namespace EnglishPlayer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IAudioPlayer _player;

        private string _filePath = "http://video.ch9.ms/ch9/bcb7/c3be3247-0d67-4e56-abfc-d9e966bebcb7/20170120TWC9.mp3";

        public string FilePath
        {
            get { return _filePath; }
            set { SetProperty(ref _filePath, value); }
        }


        private double _position;
        public double Position
        {
            get { return _position; }
            set { SetProperty(ref _position, value); }
        }


        public MainPageViewModel(INavigationService navigationService, IAudioPlayer player)
            : base(navigationService)
        {
            Title = "Main Page";
            _player = player;
            _player.PositionChanged = (p, d) =>
            {
                Position = p.TotalSeconds / d.TotalSeconds;
                return true;
            };
        }

        public DelegateCommand PlayCommand => new DelegateCommand(
            async () =>
            {
                await _player.Play(new MediaFile { Url = FilePath });
            });

        public DelegateCommand PasueCommand => new DelegateCommand(
            async () =>
            {
                await _player.Pause();
            }
            );
        public DelegateCommand StopCommand => new DelegateCommand(
            async () =>
            {
                await _player.Stop();
            }
            );
    }
}
