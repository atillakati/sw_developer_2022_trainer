using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor.UI
{
    public class DummyDataProvider : INewPlaylistDataProvider
    {
        public string Title => "Meine Top Charts 2022";

        public string Author => "DJ Gandalf";

        public DialogResult StartDialog()
        {
            return DialogResult.OK;
        }
    }
}
