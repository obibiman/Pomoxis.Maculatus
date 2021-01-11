using ArticleCommands.WebAPI.Database.Contracts;
using DomainUsage.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleCommands.WebAPI.Database.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly FrontierContext _ctxt;
        private readonly Serilog.ILogger _logr;

        public StudentRepository(FrontierContext ctxt, Serilog.ILogger logr)
        {
            _ctxt = ctxt;
            _logr = logr;
        }

        public async Task<Student> GetByIdAsync(int Id)
        {
            var studentSku = await _ctxt.Students.FirstOrDefaultAsync(y => y.StudentId == Id);
            _logr.Information("The following student has been retrieved {@Student}", studentSku);
            return studentSku;
        }

        public async Task<Student> CreateAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            _ctxt.Set<Student>().Add(student);
            student.DateCreated = DateTime.UtcNow;
            student.CreatedBy = student?.CreatedBy ?? "System Ingestion";
            await _ctxt.SaveChangesAsync();
            _logr.Information("The following student has been added {@Student}", student);
            return student;
        }

        public async Task DeleteAsync(Student student)
        {
            Task<Student> customerSku = _ctxt.Students.FirstOrDefaultAsync(y => y.StudentId == student.StudentId);

            if (customerSku != null)
            {
                var theId = customerSku.Id;
                _ctxt.Set<Student>().Remove(student);
                _logr.Information("The following student will be removed {@Student}", student);
            }

            await _ctxt.SaveChangesAsync();
            _logr.Information("The following student has been removed {@Student}", student);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            List<Student> customerSkus = await _ctxt.Students.ToListAsync();
            _logr.Information("The following customers have been retrieved {@List<Student>}", customerSkus);
            return customerSkus;
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            Task<Student> customerSku = _ctxt.Students.FirstOrDefaultAsync(y => y.StudentId == student.StudentId);
            if (customerSku != null)
            {
                student.DateModified = DateTime.UtcNow;
                student.ModifiedBy = student?.ModifiedBy ?? "System Update";
                await _ctxt.SaveChangesAsync();
                _logr.Information("The following student has been updated {@Student}", student);
            }
            return student;
        }

        public Student GetById(int Id)
        {
            var studentSku = _ctxt.Students.FirstOrDefault(y => y.StudentId == Id);
            return studentSku;
        }
    }
}