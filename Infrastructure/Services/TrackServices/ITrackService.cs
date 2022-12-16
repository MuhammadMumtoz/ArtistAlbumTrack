namespace Infrastructure.Services.TrackServices;
using Domain.Entities;
using Domain.Dtos;
public interface ITrackService{
    public Task<Response<List<GetTrackDto>>> GetTracks();
    public Task<Response<GetTrackDto>> GetTrackById(int id);
    public Task<Response<AddTrackDto>> InsertTrack(AddTrackDto Track);
    public Task<Response<AddTrackDto>> UpdateTrack(AddTrackDto Track);
    public Task<Response<string>> DeleteTrack (int id);
}