using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.Common.Domain
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentFirstName { get; set; }
        public ICollection<Sandwich> Sandwiches { get; set; }
    }
}

