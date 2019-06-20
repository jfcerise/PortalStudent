using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PortalStudent.Common.Domain
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Local { get; set; }

        public virtual ICollection<Sandwich> Sandwiches { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}