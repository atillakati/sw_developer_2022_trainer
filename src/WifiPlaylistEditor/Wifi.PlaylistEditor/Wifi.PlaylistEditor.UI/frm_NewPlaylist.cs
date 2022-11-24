using System;
using System.Windows.Forms;

namespace Wifi.PlaylistEditor.UI
{
    public partial class frm_NewPlaylist : Form, INewPlaylistDataProvider
    {
        public frm_NewPlaylist()
        {
            InitializeComponent();
        }

        public string Title => textBox1.Text;

        public string Author => textBox2.Text;

        public DialogResult StartDialog()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;

            return ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text) ||
               string.IsNullOrEmpty(textBox2.Text))
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
