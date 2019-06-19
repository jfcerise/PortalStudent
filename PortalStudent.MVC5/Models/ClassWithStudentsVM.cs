using PortalStudent.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudent.MVC5.Models
{
    public class ClassWithStudentsVM
    {
        public Class Classe { get;set;}
        public List<StudentSubscriptionVM> Students { get;set; }
    }
}