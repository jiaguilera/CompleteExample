﻿using CompleteExample.Entities;
using CompleteExample.Logic.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CompleteExample.Logic
{
    internal class EnrollmentCommands : IEnrollmentCommands
    {
        private readonly CompleteExampleDBContext _context;

        public EnrollmentCommands(CompleteExampleDBContext context)
            => _context = context;

        public ValueTask<Result<Enrollment>> AddOrUpdateStudentsGradeAsync(int courseId, int studentId, decimal? grade)
            => _context.ValidateExistsAsync<Course>(courseId)
                .ThenAsync(_ => _context.ValidateExistsAsync<Student>(studentId))
                .ThenAsync(async _ =>
                {
                    var enrollment = await _context.Enrollment.FirstOrDefaultAsync(e => e.CourseId == courseId && e.StudentId == studentId);

                    if (enrollment == default)
                    {
                        enrollment = new Enrollment { CourseId = courseId, StudentId = studentId };
                        _context.Add(enrollment);
                    }

                    enrollment.Grade = grade;

                    await _context.SaveChangesAsync();

                    return new Result<Enrollment>(enrollment);
                });
    }
}
