using System.Windows.Forms;

namespace Wifi.PlaylistEditor.UI
{
    public interface INewPlaylistDataProvider
    {
        string Title { get; }
        string Author { get; }

        DialogResult StartDialog();
    }
}
