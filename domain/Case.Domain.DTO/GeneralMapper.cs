using AutoMapper;
using Case.Domain.Entity;

namespace Case.Domain.DTO;

public class GeneralMapper:Profile
{
    public GeneralMapper()
    {
        CreateMap<Personal, PersonalDTO>().ReverseMap();
        CreateMap<Personal, PersonalSaveDTO>().ReverseMap();
        CreateMap<Personal, PersonalUpdateDTO>().ReverseMap();
    }
}