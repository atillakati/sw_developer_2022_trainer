namespace Wifi.PlaylistEditor.Types
{
    public interface IDatabaseRepository
    {
        Task<IEnumerable<IPlaylist>> GetAsync();

        Task<IPlaylist?> GetAsync(string id);

        Task CreateAsync(IPlaylist newPlaylist);

        Task UpdateAsync(string id, IPlaylist updatePlaylist);

        Task RemoveAsync(string id);
    }
}
