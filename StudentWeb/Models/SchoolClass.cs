using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWeb.Models
{
    //班级
    public class SchoolClass
    {
        //主键
        public int ID { get; set; }

        //班级名字
        public string ClassTitle { get; set; }

        //本班级的学生集合
        [InverseProperty("MyClass")]
        public List<Student> Students { get; set; }

        //班长
        public Student ClassMonitor { get; set; }

        //语文课代表
        public Student Chinese { get; set; }

        //数学课代表
        public Student Mathematics { get; set; }

        //班主任
        [InverseProperty("AdminClass")]
        public Teacher HeadTeacher { get; set; }

        //语文老师
        public Teacher ChineseTeacher { get; set; }

        //数学老师
        public Teacher MathTeacher { get; set; }
    }

}
