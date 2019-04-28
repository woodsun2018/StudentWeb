using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWeb.Models
{
    public class SchoolClass
    {
        public int ID { get; set; }

        public string ClassTitle { get; set; }

        public List<Student> Students { get; set; }

        //班长
        public Student ClassMonitor { get; set; }

        //语文课代表
        public Student Chinese { get; set; }

        //数学课代表
        public Student Mathematics { get; set; }
    }

}
