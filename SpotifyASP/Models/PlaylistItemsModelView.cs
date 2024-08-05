using SpotifyAPI.Web;
using System.Collections.Generic;

public class PlaylistItemsViewModel
{
    public string PlaylistId { get; set; }
    public IEnumerable<PlaylistTrack<IPlayableItem>> Tracks { get; set; }
}
