using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWeb.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public SchoolClass MyClass { get; set; }
    }
}
