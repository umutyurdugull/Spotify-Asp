using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using System.Threading.Tasks;

public class SongController : Controller
{
    private readonly SpotifyClient _spotifyClient;

    public SongController(SpotifyClient spotifyClient)
    {
        _spotifyClient = spotifyClient;
    }

    public async Task<IActionResult> Index(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new SongViewModel());
        }


        //hayatımdan nefret ediyorum.
        var searchRequest = new SearchRequest(SearchRequest.Types.Track, query)
        {
            Limit = 25
        };

        var searchResponse = await _spotifyClient.Search.Item(searchRequest);
        var tracks = searchResponse.Tracks.Items;

        var model = new SongViewModel
        {
            Query = query,
            Tracks = tracks
        };

        return View(model);
    }
}
