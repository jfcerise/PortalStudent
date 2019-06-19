using Common.Domain;
using DataAccess;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
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

                return ctx.Classes.FirstOrDefault(x => x.ClassId==ClassId).Students.ToList();

            }
        }
    }
}
