using SpotifyAPI.Web;
using System.Collections.Generic;

public class PlaylistViewModel
{
    public string Query { get; set; }
    public string Description { get; set; }
    public IEnumerable<FullPlaylist> Playlists { get; set; }
}
