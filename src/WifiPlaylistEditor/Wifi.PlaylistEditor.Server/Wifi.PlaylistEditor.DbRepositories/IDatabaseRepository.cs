using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;

namespace Wifi.PlaylistEditor.DbRepositories
{
    /// <summary>
    /// Defines CRUD methods for a database repository
    /// </summary>
    public interface IDatabaseRepository<T>
    {
        Task<List<T>> GetAsync();

        Task<T> GetAsync(string id);

        Task CreateAsync(T newPlaylist);

        Task UpdateAsync(string id, T updatedPlaylist);

        Task RemoveAsync(string id);
    }
}
