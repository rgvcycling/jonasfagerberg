﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoOnDemand.Entities;

namespace VideoOnDemand.Repositories
{
    public class MockReadRepository : IReadRepository
    {
        #region Mock Data
        List<Course> _courses = new List<Course> {
            new Course{ Id = 1, InstructorId = 1, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course.jpg", Title = "C# For Beginners", Description = "Course 1 Description: Some description that is very very long and longer still" },
            new Course{ Id = 2, InstructorId = 1, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course2.jpg", Title = "Programming C#", Description = "Course 2 Description: Some description that is very very long and longer still" },
            new Course{ Id = 3, InstructorId = 2, MarqueeImageUrl = "/images/laptop.jpg", ImageUrl = "/images/course3.jpg", Title = "MVC 5 For Beginners", Description = "Course 3 Description: Some description that is very very long and longer still" }
        };

        List<UserCourse> _userCourses = new List<UserCourse>
        {
            new UserCourse { UserId = "649112c5-a8e9-4312-9fff-fbec8d717f99" , CourseId = 1 },
            new UserCourse { UserId = "00000000-0000-0000-0000-000000000000" , CourseId = 2 },
            new UserCourse { UserId = "649112c5-a8e9-4312-9fff-fbec8d717f99" , CourseId = 3 },
            new UserCourse { UserId = "00000000-0000-0000-0000-000000000000" , CourseId = 1 }
        };

        List<Module> _modules = new List<Module>
        {
            new Module { Id = 1, Title = "Module 1", CourseId = 1 },
            new Module { Id = 2, Title = "Module 2", CourseId = 1 },
            new Module { Id = 3, Title = "Module 3", CourseId = 2 }
        };

        List<Video> _videos = new List<Video>
        {
            new Video { Id = 1, ModuleId = 1, CourseId = 1, Position = 1, Title = "Video 1 Title", Description = "Video 1 Description: Some description that is very very long and longer still", Duration = 50, Thumbnail = "/images/video1.jpg", Url = "https://www.youtube.com/watch?v=BJFyzpBcaCY" },
            new Video { Id = 2, ModuleId = 1, CourseId = 1, Position = 2, Title = "Video 2 Title", Description = "Video 2 Description: Some description that is very very long and longer still", Duration = 45, Thumbnail = "/images/video2.jpg", Url = "https://www.youtube.com/watch?v=BJFyzpBcaCY" },
            new Video { Id = 3, ModuleId = 1, CourseId = 1, Position = 3, Title = "Video 3 Title", Description = "Video 3 Description: Some description that is very very long and longer still", Duration = 41, Thumbnail = "/images/video3.jpg", Url = "https://www.youtube.com/watch?v=BJFyzpBcaCY" },
            new Video { Id = 4, ModuleId = 3, CourseId = 2, Position = 1, Title = "Video 4 Title", Description = "Video 4 Description: Some description that is very very long and longer still", Duration = 41, Thumbnail = "/images/video4.jpg", Url = "https://www.youtube.com/watch?v=BJFyzpBcaCY" },
            new Video { Id = 5, ModuleId = 2, CourseId = 1, Position = 1, Title = "Video 5 Title", Description = "Video 5 Description: Some description that is very very long and longer still", Duration = 42, Thumbnail = "/images/video5.jpg", Url = "https://www.youtube.com/watch?v=BJFyzpBcaCY" }
        };

        List<Instructor> _instructors = new List<Instructor>
        {
            new Instructor{
                Id = 1,
                Name = "John Doe",
                Thumbnail = "/images/Ice-Age-Scrat-icon.png",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            },
            new Instructor{
                Id = 2,
                Name = "Jane Doe",
                Thumbnail = "/images/Ice-Age-Scrat-icon.png",
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
            }
        };

        List<Download> _downloads = new List<Download>
        {
            new Download{Id = 1, ModuleId = 1, CourseId = 1, Title = "ADO.NET 1 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" },
            new Download{Id = 2, ModuleId = 1, CourseId = 1, Title = "ADO.NET 2 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" },
            new Download{Id = 3, ModuleId = 3, CourseId = 2, Title = "ADO.NET 1 (PDF)", Url = "https://1drv.ms/b/s!AuD5OaH0ExAwn48rX9TZZ3kAOX6Peg" }
        };
        #endregion

        public IEnumerable<Course> GetCourses(string userId)
        {
            var courses = _userCourses.Where(uc => uc.UserId.Equals(userId))
                .Join(_courses, uc => uc.CourseId, c => c.Id,
                (uc, c) => new { Course = c })
                .Select(s => s.Course);

            foreach (var course in courses)
            {
                course.Instructor = _instructors.SingleOrDefault(s => s.Id.Equals(course.Instructor));
                course.Module = _modules.Where(m => m.CourseId.Equals(course.Id)).ToList();
            }

            return courses;
        }

        public Video GetVideo(string userId, int videoId)
        {
            var video = _videos
                .Where(v => v.Id.Equals(videoId))
                .Join(_userCourses, v => v.CourseId, uc => uc.CourseId, (v, uc) => new { Video = v, UserCourse = uc })
                .Where(vuc => vuc.UserCourse.UserId.Equals(userId))
                .FirstOrDefault().Video;
            
            return video;
        }
    }
}
