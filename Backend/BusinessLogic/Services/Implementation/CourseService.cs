﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Dto.Course;
using BusinessLogic.Services.Abstract;
using BusinessLogic.Vm;
using DataAccess.DataContext;
using DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly AppDBContext context;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CourseService(AppDBContext context, IMapper mapper, UserManager<User> userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            return await context.Courses.OrderByDescending(course => course.Id)
               .ProjectTo<CourseViewModel>(mapper.ConfigurationProvider)
               .ToListAsync();
        }

        public async Task<CourseViewModel> GetCourseById(int courseId)
        {
            var course = await context.Courses.FindAsync(courseId);

            return mapper.Map<CourseViewModel>(course);
        }

        public async Task<bool> GetIsUserSubscribedToTheCourse(int courseId, int userId)
        {
            return await context.CoursesToUsers.FirstOrDefaultAsync(x => x.CourseId == courseId && x.UserId == userId) != null;
        }

        public async Task<SubscribeToCourseViewModel> SubscribeToCourse(SubscribeToCourseDto subscribe)
        {
            var courseToUser = mapper.Map<CourseToUser>(subscribe);

            if (courseToUser != null && await GetIsUserSubscribedToTheCourse(courseToUser.CourseId, courseToUser.UserId) == false)
            {
                context.CoursesToUsers.Add(courseToUser);

                await context.SaveChangesAsync();

                courseToUser = await context.CoursesToUsers
                    .Include(course => course.Course)
                    .Include(user => user.User)
                    .FirstOrDefaultAsync(course => course.CourseId == courseToUser.CourseId && course.UserId == courseToUser.UserId);

                return mapper.Map<SubscribeToCourseViewModel>(courseToUser);
            }
            else return null;
        }

        public async Task<List<CourseToUserViewModel>> GetCoursesByUserId(int userId)
        {
            var courses = await context.CoursesToUsers
                .Where(course => course.UserId == userId).OrderBy(course => course.StartDate)
                .ProjectTo<CourseToUserViewModel>(mapper.ConfigurationProvider)
                .ToListAsync();

            return courses;
        }

        public async Task<List<CourseToUserViewModel>> GetCoursesByUserEmail(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user != null)
            {
                var courses = await context.CoursesToUsers
                    .Where(users => users.UserId == user.Id).ProjectTo<CourseToUserViewModel>(mapper.ConfigurationProvider)
                    .ToListAsync();

                return courses;
            }
            return null;
        }

        


    }
}
