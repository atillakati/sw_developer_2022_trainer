using System.Windows.Forms;

namespace Wifi.PlaylistEditor.UI
{
    internal interface INewPlaylistDataProvider
    {
        string Title { get; }
        string Author { get; }

        DialogResult StartDialog();
    }
}
