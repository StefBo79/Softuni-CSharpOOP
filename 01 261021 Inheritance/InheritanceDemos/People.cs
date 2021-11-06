using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InheritanceDemos
{
    public class Person
    {
        public string Name { get; set; }

        public string Address { get; set; }
    }

    public class Employee : Person
    {
        public string Company { get; set; }
    }

    public class Student : Person
    {
        public string School { get; set; }
    }

    public class UniversityStudent : Student
    {
        public int GraduationYear { get; set; }
    }

    public class HighSchoolStudent : Student
    {
        public DateTime PromDate { get; set; }
    }
}
