using Domain.Dtos;
using Infrastructure.Services.AlbumServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class AlbumController {
    private readonly AlbumService _albumService;
    
    public AlbumController(AlbumService albumService){
        _albumService = albumService;
    }
    [HttpGet("GetAlbums")]
    public async Task<Response<List<GetAlbumDto>>> GetAlbums(){
        return await _albumService.GetAlbums();
    }
    [HttpGet("GetAlbumById")]
    public async Task<Response<GetAlbumDto>> GetAlbumById (int id)
    {
        return await _albumService.GetAlbumById(id);
    }
    [HttpPost("AddAlbum")]
    public async Task<Response<AddAlbumDto>> InsertAlbum(AddAlbumDto album)
    {
        return await _albumService.InsertAlbum(album);
    }
    [HttpPut("UpdateAlbum")]
    public async Task<Response<AddAlbumDto>> UpdateAlbum (AddAlbumDto album){
        return await _albumService.UpdateAlbum(album);
    }
    [HttpDelete("DeletAlbum")]
    public async Task<Response<string>> DeleteAlbum(int id){
        return await _albumService.DeleteAlbum(id);
    }
}
