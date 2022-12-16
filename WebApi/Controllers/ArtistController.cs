using Domain.Dtos;
using Infrastructure.Services.ArtistServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class ArtistController {
    private readonly ArtistService _artistService;
    
    public ArtistController(ArtistService artistService){
        _artistService = artistService;
    }
    [HttpGet("GetArtists")]
    public async Task<Response<List<GetArtistDto>>> GetArtists(){
        return await _artistService.GetArtists();
    }
    [HttpGet("GetArtistById")]
    public async Task<Response<GetArtistDto>> GetArtistById (int id)
    {
        return await _artistService.GetArtistById(id);
    }
    [HttpPost("AddArtist")]
    public async Task<Response<AddArtistDto>> InsertArtist(AddArtistDto artist)
    {
        return await _artistService.InsertArtist(artist);
    }
    [HttpPut("UpdateArtist")]
    public async Task<Response<AddArtistDto>> UpdateArtist (AddArtistDto artist){
        return await _artistService.UpdateArtist(artist);
    }
    [HttpDelete("DeletArtist")]
    public async Task<Response<string>> DeleteArtist(int id){
        return await _artistService.DeleteArtist(id);
    }
}
