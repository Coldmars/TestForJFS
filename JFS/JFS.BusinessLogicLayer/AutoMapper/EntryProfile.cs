using AutoMapper;
using JFS.BusinessLogicLayer.DTOs;
using JFS.DataAccessLayer.Entities;

namespace JFS.BusinessLogicLayer.AutoMapper
{
    public class EntryProfile : Profile
    {
        public EntryProfile()
        {
            CreateMap<Entry, EntryDto>()
                .ForMember(
                dest => dest.AccountId,
                opt => opt.MapFrom(src => src.AccountId))
                .ForMember(
                dest => dest.Period,
                opt => opt.MapFrom(src => DateTime.ParseExact(src.Period, "yyyyMM", null)))
                .ForMember(
                dest => dest.InBalance,
                opt => opt.MapFrom(src => src.InBalance))
                .ForMember(
                dest => dest.Calculation,
                opt => opt.MapFrom(src => src.Calculation));
        }
    }
}
