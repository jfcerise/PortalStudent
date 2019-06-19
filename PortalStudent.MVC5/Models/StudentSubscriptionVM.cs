using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalStudent.MVC5.Models
{
    public class StudentSubscriptionVM
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public bool Subscribed { get; set; }
    }
}