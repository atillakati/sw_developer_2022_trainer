namespace Wifi.PlaylistEditor.Types
{
    public interface IFileDescription
    {
        /// <summary>
        /// Contains the default description of the file. eg: .mp3 or .m3u
        /// </summary>
        string Extension { get; }

        /// <summary>
        /// Contains a brief description of the filetype
        /// </summary>
        string Description { get; }
    }
}
