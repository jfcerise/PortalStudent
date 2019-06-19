﻿using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public List<Student> GetStudents()
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Students.ToList();
            }
        }
        public Student GetStudent(int StudentId)
        {
            using (var ctx = new PortalContext())
            {
                return ctx.Students.FirstOrDefault(x => x.StudentId == StudentId);
            }
        }

        public List<Student> GetStudentsOfClass(int ClassId)
        {
            using (var ctx = new PortalContext())
            {
                var st2 = from x in ctx.Classes
                          where x.ClassId == ClassId
                          select x.Students;

                return st2 != null? st2.First().ToList(): new List<Student>();

            }
        }
    }
}
