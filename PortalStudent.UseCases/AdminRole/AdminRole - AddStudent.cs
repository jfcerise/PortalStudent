using PortalStudent.Common.Domain;
using PortalStudent.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.UseCases
{
    public partial class AdminRole
    {
        public bool UpdateClassAttendence(int ClasseId, List<Student> StudentToUse)
        {
            var classe = GetClass(ClasseId);
            var listActual = GetStudentsOfClass(ClasseId);

            listActual.Where(x => !StudentToUse.Any(y=>y.StudentId == x.StudentId))
                .ToList()
                .ForEach(x => RemoveStudent2(classe, x));

            StudentToUse.Where(x => !listActual.Any(y => y.StudentId == x.StudentId))
                .ToList()
                .ForEach(x => AddStudent2(classe, x));

            return false;
        }

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
        public bool AddStudent2(Class Classe, Student StudentToUse)
        {
            if (Classe == null)
                throw new ArgumentNullException(nameof(Classe));

            if (StudentToUse == null)
                throw new ArgumentNullException(nameof(StudentToUse));

            if (Classe.ClassId == 0)
                throw new Exception(nameof(Classe));

            if (StudentToUse.StudentId == 0)
                throw new Exception(nameof(StudentToUse));

            using (var ctx = new PortalContext())
            {
                //if (ctx.Classes.Any(x => x.ClassId == Classe.ClassId))
                //{
                //    throw new Exception(nameof(Classe));
                //}
                //if (ctx.Students.Any(x => x.StudentName == StudentToUse.StudentName))
                //{
                //    throw new Exception(nameof(StudentToUse));
                //}
                ctx.Classes.Attach(Classe);

                if (ctx.Entry(StudentToUse).State == EntityState.Detached)
                    ctx.Students.Attach(StudentToUse);

                Classe.Students.Add(StudentToUse);

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
        public bool RemoveStudent2(Class Classe, Student StudentToUse)
        {
            if (Classe == null)
                throw new ArgumentNullException(nameof(Classe));

            if (StudentToUse == null)
                throw new ArgumentNullException(nameof(StudentToUse));

            if (Classe.ClassId == 0)
                throw new Exception(nameof(Classe));

            if (StudentToUse.StudentId == 0)
                throw new Exception(nameof(StudentToUse));

            using (var ctx = new PortalContext())
            {
                ctx.Classes.Attach(Classe);

                //if (ctx.Entry(StudentToUse).State == EntityState.Detached)
                //{
                //    ctx.Students.Attach(StudentToUse);
                //}

                //var studentEF
                Classe.Students.Remove(Classe.Students.FirstOrDefault(x=>x.StudentId==StudentToUse.StudentId));

                ctx.SaveChanges();
            }

            return true;
        }
    }
}