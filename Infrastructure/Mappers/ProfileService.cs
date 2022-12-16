
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ProfileService : Profile {
    public ProfileService(){
        CreateMap<GetAlbumDto, AddAlbumDto>().ReverseMap();
        CreateMap<GetAlbumDto, Album>().ReverseMap();
        CreateMap<AddAlbumDto, Album>().ReverseMap();
        CreateMap<GetArtistDto, AddArtistDto>().ReverseMap();
        CreateMap<GetArtistDto, Artist>().ReverseMap();
        CreateMap<AddArtistDto, Artist>().ReverseMap();
        CreateMap<GetTrackDto, AddTrackDto>().ReverseMap();
        CreateMap<GetTrackDto, Track>().ReverseMap();
        CreateMap<AddTrackDto, Track>().ReverseMap();
    }
}
// public class ProfileService : Profile
// {
//     public ProfileService()
//     {
//         CreateMap<AlbumDto, Album>();
//         CreateMap<ArtistDto, Artist>();
//         CreateMap<TrackDto, Track>();
//     }
// }