using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wifi.PlaylistEditor.Types
{
    public class Playlist : IPlaylist
    {
        private List<IPlaylistItem> _itemList;
        private string _name;
        private string _author;
        private DateTime _createAt;
        private bool _allowDuplicates;

        public Playlist(string name, string author)
            : this(name, author, DateTime.Now)
        {
        }

        public Playlist(string name, string author, DateTime createAt)
        {
            _name = name;
            _author = author;
            _createAt = createAt;
            _allowDuplicates = true;
            _itemList = new List<IPlaylistItem>();
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string Author
        {
            get => _author;
            set => _author = value;
        }

        public DateTime CreateAt => _createAt;

        public TimeSpan Duration
        {
            get
            {
                TimeSpan duration = TimeSpan.Zero;
                _itemList.ForEach(x => duration = duration.Add(x.Duration));

                return duration;
            }
        }

        public bool AllowDuplicates
        {
            get => _allowDuplicates;
            set => _allowDuplicates = value;
        }

        public IEnumerable<IPlaylistItem> ItemList
        {
            get { return _itemList; }
        }

        public void Add(IPlaylistItem itemToAdd)
        {
            bool addNewItem = true;

            if (itemToAdd == null)
            {
                return;
            }

            if (!_allowDuplicates)
            {
                addNewItem = !_itemList.Any(x => x.Artist == itemToAdd.Artist && x.Title == itemToAdd.Title);
            }

            if (addNewItem)
            {
                _itemList.Add(itemToAdd);
            }
        }

        public void Clear()
        {
            _itemList.Clear();
        }

        public void Remove(IPlaylistItem itemToRemove)
        {
            _itemList.Remove(itemToRemove);
        }

    }
}
