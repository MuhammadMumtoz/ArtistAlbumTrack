namespace Infrastructure.Services.TrackServices;

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Net;

public class TrackService : ITrackService
{
    private readonly DataContext _context;
    private readonly IMapper _iMapper;
    public TrackService(DataContext context, IMapper mapper)
    {
        _context = context;
        _iMapper = mapper;
    }

    public async Task<Response<List<GetTrackDto>>> GetTracks()
    {
        var list = await (
            from ab in _context.Albums
            join at in _context.Artists on ab.ArtistId equals at.ArtistId
            join tr in _context.Tracks on ab.AlbumId equals tr.AlbumId
            select new GetTrackDto
            {
                TrackId = tr.TrackId,
                TrackName = tr.TrackName,
                ArtistId = at.ArtistId,
                ArtistName = at.ArtistName,
                AlbumId = ab.AlbumId,
                Title = ab.Title
            }
            ).ToListAsync();
        return new Response<List<GetTrackDto>>(list);
    }
    public async Task<Response<GetTrackDto>> GetTrackById(int id)
    {
        var newTrack = await (from ab in _context.Albums
                              join at in _context.Artists on ab.ArtistId equals at.ArtistId
                              join tr in _context.Tracks on ab.AlbumId equals tr.AlbumId
                              where at.ArtistId == id
                              select new GetTrackDto
                              {
                                  TrackId = tr.TrackId,
                                  TrackName = tr.TrackName,
                                  ArtistId = at.ArtistId,
                                  ArtistName = at.ArtistName,
                                  AlbumId = ab.AlbumId,
                                  Title = ab.Title
                              }).FirstOrDefaultAsync();
        return new Response<GetTrackDto>(newTrack);
    }

    public async Task<Response<AddTrackDto>> InsertTrack(AddTrackDto track)
    {
        var newTrack = _iMapper.Map<Track>(track);
        await _context.Tracks.AddAsync(newTrack);
        await _context.SaveChangesAsync();
        return new Response<AddTrackDto>(track);
    }

    public async Task<Response<AddTrackDto>> UpdateTrack(AddTrackDto track)
    {
        var find = await _context.Tracks.FindAsync(track.TrackId);
        find.TrackName = track.TrackName;
        find.AlbumId = track.AlbumId;
        await _context.SaveChangesAsync();
        return new Response<AddTrackDto>(track);
    }
    public async Task<Response<string>> DeleteTrack(int id)
    {
        var find = await _context.Tracks.FindAsync(id);
        _context.Remove(find);
        var response = await _context.SaveChangesAsync();
        if (response > 0)
            return new Response<string>("Category deleted successfully");
        return new Response<string>(HttpStatusCode.BadRequest, "Category not found");
    }
}