namespace Infrastructure.Services.ArtistServices;
using Domain.Entities;
using Domain.Dtos;
public interface IArtistService{
    public Task<Response<List<GetArtistDto>>> GetArtists();
    public Task<Response<GetArtistDto>> GetArtistById(int id);
    public Task<Response<AddArtistDto>> InsertArtist(AddArtistDto artist);
    public Task<Response<AddArtistDto>> UpdateArtist(AddArtistDto artist);
    public Task<Response<string>> DeleteArtist (int id);
}