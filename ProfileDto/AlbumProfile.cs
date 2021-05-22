using AutoMapper;
using Dtos;
using MyFirstWebApp.Model;

namespace ProfileDto
{
    public class AlbumProfile : Profile
    {
        public AlbumProfile()
        {
            CreateMap<Album, AlbumReadDto>().ReverseMap();
            CreateMap<Album, AlbumCreateDto>().ReverseMap();
            CreateMap<Track, TrackReadDto>().ReverseMap();
            CreateMap<Track, TrackCreateDto>().ReverseMap();
        }
    }
}