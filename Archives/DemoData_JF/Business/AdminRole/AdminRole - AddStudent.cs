using Common.Domain;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public partial class AdminRole
    {
        public bool AddStudent(Student StudentToUse)
        {
            if (StudentToUse == null)
                throw new ArgumentNullException(nameof(StudentToUse));

            if (StudentToUse.StudentId != 0)
                throw new Exception(nameof(StudentToUse));

            if (String.IsNullOrEmpty(StudentToUse.StudentName) || String.IsNullOrWhiteSpace(StudentToUse.StudentName))
                throw new Exception(nameof(StudentToUse));

            using (var ctx = new PortalContext())
            {
                if (ctx.Students.Any(x => x.StudentName == StudentToUse.StudentName))
                {
                    throw new Exception(nameof(StudentToUse));
                }
                ctx.Students.Add(StudentToUse);
                ctx.SaveChanges();
            }

            return true;
        }
        public bool UpdStudent(Student StudentToUse)
        {
            if (StudentToUse == null)
                throw new ArgumentNullException(nameof(StudentToUse));

            if (String.IsNullOrEmpty(StudentToUse.StudentName) || String.IsNullOrWhiteSpace(StudentToUse.StudentName))
                throw new Exception(nameof(StudentToUse));

            using (var ctx = new PortalContext())
            {
                ctx.Entry(StudentToUse).State = EntityState.Modified;
                ctx.SaveChanges();
            }

            return true;
        }

        public bool DelStudent(Student StudentToUse)
        {
            if (StudentToUse == null)
                throw new ArgumentNullException(nameof(StudentToUse));

            using (var ctx = new PortalContext())
            {
                ctx.Entry(StudentToUse).State = EntityState.Deleted;
                ctx.SaveChanges();
            }

            return true;
        }
    }
}