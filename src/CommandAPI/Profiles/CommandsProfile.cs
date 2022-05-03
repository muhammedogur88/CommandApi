using System;
using AutoMapper;
using CommandAPI.DTOs;
using CommandAPI.Models;

namespace CommandAPI.Profiles;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        // Source => Targets
        CreateMap<Command, CommandReadDto>();

        CreateMap<CommandCreateDto, Command>();

        CreateMap<CommandUpdateDto, Command>().ReverseMap();


    }
}