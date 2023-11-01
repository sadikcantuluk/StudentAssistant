using AutoMapper;
using EntityLayer.Concrete;
using StudentAssistant.WebUI.Dtos.Student;

namespace StudentAssistant.WebUI.Mapping
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<UpdateStudentDto, Student>().ReverseMap();
            CreateMap<ResultStudentDto, Student>().ReverseMap();
        }
    }
}
