using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditor.UI.Properties;

namespace Wifi.PlaylistEditor.UI
{
    public partial class frm_Main : Form
    {
        private INewPlaylistDataProvider _newPlaylistDataProvider;
        private IPlaylist _playlist;

        private IPlaylistFactory _playlistFactory;
        private IPlaylistItemFactory _playlistItemFactory;
        private IRepositoryFactory _repositoryFactory;

        public frm_Main()
        {
            InitializeComponent();

            _newPlaylistDataProvider = new frm_NewPlaylist();
            _playlistFactory = new PlaylistFactory();
            _playlistItemFactory = new PlaylistItemFactory();
            _repositoryFactory = new RepositoryFactory(_playlistFactory, _playlistItemFactory);
        }
           

        private void EnableEditMenuItems(bool isEnabled)
        {
            saveToolStripMenuItem.Enabled = isEnabled;
            itemsToolStripMenuItem.Enabled = isEnabled;
        }

        private void UpdatePlaylistItemView()
        {
            int index = 0;

            lst_itemView.Items.Clear();
            imageList1.Images.Clear();

            foreach (var playlistItem in _playlist.ItemList)
            {
                var listViewItem = new ListViewItem(playlistItem.Title);
                listViewItem.Tag = playlistItem;
                listViewItem.ImageIndex = index;

                lst_itemView.Items.Add(listViewItem);

                var image = playlistItem.Thumbnail == null ? Resource.no_image : playlistItem.Thumbnail;
                imageList1.Images.Add(image);

                index++;
            }

            lst_itemView.LargeImageList = imageList1;
        }

        private void UpdatePlaylistInfoView()
        {
            lbl_playlistInfo.Text = $"{_playlist.Name} [{_playlist.Duration.ToString(@"hh\:mm\:ss")}] @ {_playlist.Author}";
        }

        private string CreateFilterText(IEnumerable<IFileDescription> availableTypes)
        {
            string filter = string.Empty;
            string allTypesFilter = "All types|";

            foreach (var type in availableTypes)
            {
                filter += $"{type.Description}|*{type.Extension}|";
                allTypesFilter += $"*{type.Extension};";
            }

            //remove last char
            filter += allTypesFilter;
            filter = filter.Substring(0, filter.Length - 1);

            return filter;
        }

        private void InitFileDialog(FileDialog fileDialog, IEnumerable<IFileDescription> availableTypes,
                                    string title, string defaultFileName)
        {
            fileDialog.Title = title;
            fileDialog.FileName = defaultFileName;
            fileDialog.Filter = CreateFilterText(availableTypes);
        }


        private void frm_Main_Load(object sender, EventArgs e)
        {
            lbl_playlistInfo.Text = string.Empty;
            lbl_itemDetailInfo.Text = string.Empty;

            EnableEditMenuItems(false);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_newPlaylistDataProvider.StartDialog() == DialogResult.Cancel)
            {
                return;
            }

            _playlist = _playlistFactory.Create(_newPlaylistDataProvider.Title,
                                                _newPlaylistDataProvider.Author, DateTime.Now);

            EnableEditMenuItems(true);
            UpdatePlaylistInfoView();
            UpdatePlaylistItemView();
        }     

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            InitFileDialog(openFileDialog1, _playlistItemFactory.AvailableTypes,
                "Select new item(s)", string.Empty);

            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            foreach (var itemPath in openFileDialog1.FileNames)
            {
                var item = _playlistItemFactory.Create(itemPath);
                if (item == null)
                {
                    continue;
                }

                _playlist.Add(item);
            }
            
            UpdatePlaylistInfoView();
            UpdatePlaylistItemView();
        }        

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _playlist.Clear();

            UpdatePlaylistInfoView();
            UpdatePlaylistItemView();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFileDialog(saveFileDialog1, _repositoryFactory.AvailableTypes, "Playlist speichern", _playlist.Name);
            
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var repository = _repositoryFactory.Create(saveFileDialog1.FileName);
            if(repository == null)
            {
                MessageBox.Show("Fileformat kann leider nicht erzeugt werden.", "Error");
                return;
            }

            repository.Save(_playlist, saveFileDialog1.FileName);
        }

        private void lst_itemView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(e.Item.Tag is IPlaylistItem playlistItem)
            {
                UpdateItemDetailsView(e.IsSelected ? playlistItem : null);               
            }
        }

        private void UpdateItemDetailsView(IPlaylistItem playlistItem)
        {
            /*
                Artist: Souron Singer
                Path: c:\myMusic\superSong.mp3
                Duration: 00:03:15
             */
            if (playlistItem != null)
            {
                lbl_itemDetailInfo.Text = $"Artist: {playlistItem.Artist}\n";
                lbl_itemDetailInfo.Text += $"Path: {playlistItem.Path}\n";
                lbl_itemDetailInfo.Text += $"Duration: {playlistItem.Duration.ToString(@"hh\:mm\:ss")}";
            }
            else
            {
                lbl_itemDetailInfo.Text = string.Empty;
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(lst_itemView.SelectedItems == null || lst_itemView.SelectedItems.Count == 0)
            {
                return;
            }

            foreach (ListViewItem selectedItem in lst_itemView.SelectedItems)
            {
                if(selectedItem.Tag is IPlaylistItem playlistItem)
                {
                    _playlist.Remove(playlistItem);
                }
            }

            UpdatePlaylistInfoView();
            UpdatePlaylistItemView();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitFileDialog(openFileDialog1, _repositoryFactory.AvailableTypes,
                           "Select playlist to load", string.Empty);
            openFileDialog1.Multiselect = false;

            if(openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var repository = _repositoryFactory.Create(openFileDialog1.FileName);
            if(repository != null)
            {
                _playlist = repository.Load(openFileDialog1.FileName);

                EnableEditMenuItems(true);
                UpdatePlaylistInfoView();
                UpdatePlaylistItemView();
            }
        }
    }
}
