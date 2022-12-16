namespace Infrastructure.Services.ArtistServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Net;

public class ArtistService : IArtistService
{
    private readonly DataContext _context;
    private readonly IMapper _iMapper;
    public ArtistService(DataContext context, IMapper mapper){
        _context = context;
        _iMapper = mapper;
    }

    public async Task<Response<List<GetArtistDto>>> GetArtists()
    {
        var list = await (
            from ab in _context.Albums
            join at in _context.Artists on ab.ArtistId equals at.ArtistId
            join tr in _context.Tracks on ab.AlbumId equals tr.AlbumId
            select new GetArtistDto
            {
                ArtistId = at.ArtistId,
                ArtistName = at.ArtistName,
                AlbumId = ab.AlbumId,
                Title = ab.Title,
                TrackId = tr.TrackId,
                TrackName = tr.TrackName
            }
            ).ToListAsync();
        return new Response<List<GetArtistDto>>(list);
    }
    public async Task<Response<GetArtistDto>> GetArtistById(int id)
    {
        var newArtist = await ( from ab in _context.Albums
                          join at in _context.Artists on ab.ArtistId equals at.ArtistId
                          join tr in _context.Tracks on ab.AlbumId equals tr.AlbumId
                          where at.ArtistId == id
                          select new GetArtistDto
                          {
                            ArtistId = at.ArtistId,
                            ArtistName = at.ArtistName,
                            AlbumId = ab.AlbumId,
                            Title = ab.Title,
                            TrackId = tr.TrackId,
                            TrackName = tr.TrackName
                          }).FirstOrDefaultAsync();
                          return new Response<GetArtistDto>(newArtist);
    }

    public async Task<Response<AddArtistDto>> InsertArtist(AddArtistDto artist)
    {
        var newArtist = _iMapper.Map<Artist>(artist);
        await _context.Artists.AddAsync(newArtist);
        await _context.SaveChangesAsync();
        return new Response<AddArtistDto>(artist);
    }

    public async Task<Response<AddArtistDto>> UpdateArtist(AddArtistDto artist)
    {
        var find = await _context.Artists.FindAsync(artist.ArtistId);
        find.ArtistName = artist.ArtistName;
        await _context.SaveChangesAsync();
        return new Response<AddArtistDto>(artist);
    }
    public async Task<Response<string>> DeleteArtist(int id)
    {
        var find = await _context.Artists.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if(response>0)
                return new Response<string>("Category deleted successfully");
                return new Response<string>(HttpStatusCode.BadRequest,"Category not found");
    }
}