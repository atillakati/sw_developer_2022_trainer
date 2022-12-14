using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;

namespace Wifi.PlaylistEditor.DbRepositories
{
    /// <summary>
    /// Defines CRUD methods for a database repository
    /// </summary>
    public interface IDatabaseRepository<T, TItem>
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(string id);

        Task CreateAsync(T newPlaylist);

        Task UpdateAsync(string id, T updatedPlaylist);

        Task RemovePlaylistAsync(string id);


        Task<List<PlaylistItemEntity>> GetItemsAsync();

        Task CreateItemAsync(TItem newPlaylistItem);

        Task RemoveItemAsync(string itemId);
    }
}
