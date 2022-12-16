namespace Domain.Dtos;
public class GetTrackDto{
    public int TrackId { get; set; }
    public string TrackName { get; set; }
    public int AlbumId { get; set; }
    public string Title { get; set; }
    public int ArtistId { get; set; }
    public string ArtistName { get; set; }
}