using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Linq;
using System.Threading.Tasks;

public class PlaylistController : Controller
{
    private readonly SpotifyClient _spotifyClient;

    public PlaylistController(SpotifyClient spotifyClient)
    {
        _spotifyClient = spotifyClient;
    }

    public async Task<IActionResult> Index(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new PlaylistViewModel());
        }

        var searchRequest = new SearchRequest(SearchRequest.Types.Playlist, query)
        {
            Limit = 10
        };

        var searchResponse = await _spotifyClient.Search.Item(searchRequest);
        var playlists = searchResponse.Playlists.Items.Cast<FullPlaylist>();

        var model = new PlaylistViewModel
        {
            Query = query,
            Playlists = playlists
        };

        return View(model);
    }

    public async Task<IActionResult> GetPlaylistItems(string playlistId)
    {
        if (string.IsNullOrEmpty(playlistId))
        {
            return RedirectToAction("Index");
        }

        var playlistItems = await _spotifyClient.Playlists.GetItems(playlistId);
        var tracks = playlistItems.Items;

        var model = new PlaylistItemsViewModel
        {
            PlaylistId = playlistId,
            Tracks = tracks
        };

        return View(model);
    }
}
