using AutoMapper;
using EntityLayer.Concrete;
using StudentAssistant.WebUI.Dtos.Daily;
using StudentAssistant.WebUI.Dtos.Notes;
using StudentAssistant.WebUI.Dtos.Student;

namespace StudentAssistant.WebUI.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
            CreateMap<ResultStudentDto, Student>().ReverseMap();

            CreateMap<ResultNotesDto, Notes>().ReverseMap();
            CreateMap<UpdateNotesDto, Notes>().ReverseMap();
            CreateMap<AddNotesDto, Notes>().ReverseMap();

            CreateMap<ResultDailyDto, Daily>().ReverseMap();
            CreateMap<UpdateNotesDto, Daily>().ReverseMap();
            CreateMap<AddNotesDto, Daily>().ReverseMap();
        }
    }
}
