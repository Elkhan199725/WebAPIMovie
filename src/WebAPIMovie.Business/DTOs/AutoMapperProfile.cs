using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIMovie.Business.DTOs.GenreDto;
using WebAPIMovie.Business.DTOs.MovieDto;
using WebAPIMovie.Core.Models;

namespace WebAPIMovie.Business.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Genre mappings
        CreateMap<Genre, GenreReadDto>().ReverseMap();
        CreateMap<GenreCreateDto, Genre>().ReverseMap();
        CreateMap<GenreUpdateDto, Genre>().ReverseMap();

        // Movie mappings
        CreateMap<Movie, MovieReadDto>()
            .ForMember(dest => dest.GenreNames, opt => opt.MapFrom(src => src.Genres.Select(g => g.Name)))
            .ReverseMap(); // Reverse mapping might require further configuration if GenreNames needs to be converted back to Genres

        CreateMap<MovieCreateDto, Movie>()
            .ForMember(dest => dest.Genres, opt => opt.Ignore()) // Handle genre linking explicitly in service
            .ReverseMap();

        CreateMap<MovieUpdateDto, Movie>()
            .ForMember(dest => dest.Genres, opt => opt.Ignore()) // Reverse mapping might not be straightforward due to ignored member
            .ReverseMap();

        CreateMap<Movie, MovieDetailedDto>()
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(g => new GenreReadDto { Id = g.Id, Name = g.Name })))
            .ReverseMap()
            .ForMember(dest => dest.Genres, opt => opt.Ignore()); // You may need to handle how to create Genre entities from GenreReadDto on reverse mapping
    }
}
