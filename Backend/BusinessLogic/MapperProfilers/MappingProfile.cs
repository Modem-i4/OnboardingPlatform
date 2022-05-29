using AutoMapper;
using BusinessLogic.Dto.Auth;
using BusinessLogic.Dto.Course;
using BusinessLogic.Vm;
using DataAccess.Models;

namespace BusinessLogic.MapperProfilers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationDto, User>();

            CreateMap<LoginViewModel, UserRefreshToken>()
                .ForSourceMember(login => login.Token, login => login.DoNotValidate());

            CreateMap<Course, CourseViewModel>();

            CreateMap<CourseToUser, SubscribeToCourseViewModel>();

            CreateMap<SubscribeToCourseDto, CourseToUser>()
               .ForMember(course => course.EndDate, opt => opt.MapFrom(course => course.StartDate.AddDays(14)));

            CreateMap<CourseToUser, CourseToUserViewModel>()
                .ForMember(course => course.Id, opt => opt.MapFrom(course => course.Course.Id))
                .ForMember(course => course.Name, opt => opt.MapFrom(course => course.Course.Name))
                .ForMember(course => course.StartDate, opt => opt.MapFrom(course => course.StartDate.ToString("d")))
                .ForMember(course => course.EndDate, opt => opt.MapFrom(course => course.EndDate.ToString("d")));

            CreateMap<AddCourseDto, Course>()
               .ForMember(course => course.Name, opt => opt.MapFrom(course => course.Name))
               .ForMember(course => course.Description, opt => opt.MapFrom(course => course.Description))
               .ForMember(course => course.ImgUrl, opt => opt.MapFrom(course => course.File));

        }
    }
}
