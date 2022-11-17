namespace Wifi.PlaylistEditor.Types
{
    public interface IFileDescription
    {
        /// <summary>
        /// Die Dateiextension die verwendet werden soll für das jeweilige Playlist/-item Format.
        /// zb: .m3u oder .mp3
        /// </summary>
        string Extension { get; }

        string Description { get; }
    }
}
