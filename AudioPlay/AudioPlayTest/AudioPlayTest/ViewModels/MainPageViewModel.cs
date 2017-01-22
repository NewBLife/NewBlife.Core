using AudioPlay;
using Prism.Commands;
using Prism.Mvvm;

namespace AudioPlayTest.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IAudioPlay _player;
        private string _FilePath = "http://video.ch9.ms/ch9/bcb7/c3be3247-0d67-4e56-abfc-d9e966bebcb7/20170120TWC9.mp3";
        public string FilePath
        {
            get { return _FilePath; }
            set { SetProperty(ref _FilePath, value); }
        }

        public DelegateCommand PlayCommand => new DelegateCommand(
            async () =>
            {
                await _player.PlayAsync(FilePath);
            },
            () => !string.IsNullOrEmpty(FilePath)).ObservesProperty(() => FilePath);

        public DelegateCommand PasueCommand => new DelegateCommand(
            () =>
            {
                _player.Pasue();
            }
            );

        public DelegateCommand StopCommand => new DelegateCommand(
            () =>
            {
                _player.Stop();
            }
            );

        public MainPageViewModel(IAudioPlay player)
        {
            _player = player;
        }
    }
}
