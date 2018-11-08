using EnglishPlayer.Enums;

namespace EnglishPlayer.Media
{
    public class MediaFile
    {
        public MediaFileType Type { get; set; }

        public ResourceType ResourceDataType { get; set; }

        public string Url { get; set; }
    }
}
