using System.Threading.Tasks;

namespace AudioPlay
{
    public interface IAudioPlay
    {
        Task PlayAsync(string fileUrl);
        void Stop();
        void Pasue();
    }
}
