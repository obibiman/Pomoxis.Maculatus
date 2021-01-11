using ArticleCommands.WebAPI.Database.Contracts;
using DomainUsage.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly FrontierContext _ctxt;
        private readonly Serilog.ILogger _logr;

        public CourseRepository(FrontierContext ctxt, Serilog.ILogger logr)
        {
            _ctxt = ctxt;
            _logr = logr;
        }

        public async Task<Course> GetByIdAsync(int Id)
        {
            var courseSku = await _ctxt.Courses.FirstOrDefaultAsync(y => y.CourseId == Id);
            _logr.Information("The following course has been retrieved {@Course}", courseSku);
            return courseSku;
        }

        public async Task<Course> CreateAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            _ctxt.Set<Course>().Add(course);
            course.DateCreated = DateTime.UtcNow;
            course.CreatedBy = course?.CreatedBy ?? "System Ingestion";
            await _ctxt.SaveChangesAsync();
            _logr.Information("The following course has been added {@Course}", course);
            return course;
        }

        public async Task DeleteAsync(Course course)
        {
            Task<Course> courseSku = _ctxt.Courses.FirstOrDefaultAsync(y => y.CourseId == course.CourseId);

            if (courseSku != null)
            {
                var theId = courseSku.Id;
                _ctxt.Set<Course>().Remove(course);
                _logr.Information("The following course will be removed {@Course}", course);
            }

            await _ctxt.SaveChangesAsync();
            _logr.Information("The following course has been removed {@Course}", course);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            List<Course> courseSkus = await _ctxt.Courses.ToListAsync();
            _logr.Information("The following courses have been retrieved {@List<Course>}", courseSkus);
            return courseSkus;
        }

        public async Task<Course> UpdateAsync(Course course)
        {
            Task<Course> courseSku = _ctxt.Courses.FirstOrDefaultAsync(y => y.CourseId == course.CourseId);
            if (courseSku != null)
            {
                course.DateModified = DateTime.UtcNow;
                course.ModifiedBy = course?.ModifiedBy ?? "System Update";
                await _ctxt.SaveChangesAsync();
                _logr.Information("The following course has been updated {@Course}", course);
            }
            return course;
        }

        public Course GetById(int Id)
        {
            var courseSku = _ctxt.Courses.FirstOrDefault(y => y.CourseId == Id);
            return courseSku;
        }
    }
}