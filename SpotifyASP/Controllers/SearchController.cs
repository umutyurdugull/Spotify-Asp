using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

public class SearchController : Controller
{
    private readonly SpotifyClient _spotifyClient;

    public SearchController(SpotifyClient spotifyClient)
    {
        _spotifyClient = spotifyClient;
    }

    public async Task<IActionResult> Index(string query)
    {
        if (string.IsNullOrEmpty(query))
        {
            return View(new SearchViewModel());
        }

        var searchRequest = new SearchRequest(SearchRequest.Types.Artist, query);
        var searchResponse = await _spotifyClient.Search.Item(searchRequest);
        var artists = searchResponse.Artists.Items;
        
        var model = new SearchViewModel
        {
            Query = query,
            Artists = artists
        };

        return View(model);
    }
}
