using SpotifyAPI.Web;
using SpotifyASP.Models;
using System.Collections.Generic;

public class SearchViewModel
{
    public string Query { get; set; }
    public IEnumerable<FullArtist> Artists { get; set; }
}
