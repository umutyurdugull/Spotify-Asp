using SpotifyAPI.Web;
using SpotifyASP.Models;
using System.Collections.Generic;

public class SongViewModel
{
    public string Query { get; set; }
    public IEnumerable<FullTrack> Tracks { get; set; }
}
