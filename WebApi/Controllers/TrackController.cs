using Domain.Dtos;
using Infrastructure.Services.TrackServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class TrackController {
    private readonly TrackService _trackService;
    
    public TrackController(TrackService trackService){
        _trackService = trackService;
    }
    [HttpGet("GetTracks")]
    public async Task<Response<List<GetTrackDto>>> GetTracks(){
        return await _trackService.GetTracks();
    }
    [HttpGet("GetTrackById")]
    public async Task<Response<GetTrackDto>> GetTrackById (int id)
    {
        return await _trackService.GetTrackById(id);
    }
    [HttpPost("AddTrack")]
    public async Task<Response<AddTrackDto>> InsertTrack(AddTrackDto track)
    {
        return await _trackService.InsertTrack(track);
    }
    [HttpPut("UpdateTrack")]
    public async Task<Response<AddTrackDto>> UpdateTrack (AddTrackDto track){
        return await _trackService.UpdateTrack(track);
    }
    [HttpDelete("DeletTrack")]
    public async Task<Response<string>> DeleteTrack(int id){
        return await _trackService.DeleteTrack(id);
    }
}
