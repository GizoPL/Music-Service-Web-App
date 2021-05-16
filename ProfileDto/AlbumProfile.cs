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
            CreateMap<Track, TrackDto>().ReverseMap();
        }
    }
}