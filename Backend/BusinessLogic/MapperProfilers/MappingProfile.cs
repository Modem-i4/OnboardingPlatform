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

        }
    }
}
