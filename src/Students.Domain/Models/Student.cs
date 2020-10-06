using System;
using System.Collections.Generic;
using System.Text;

namespace Students.Domain.Models
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Groupe { get; set; }
        public string Spec { get; set; }
       
    }
}
