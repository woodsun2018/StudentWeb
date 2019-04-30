﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWeb.Models
{
    //学生
    public class Student
    {
        //主键
        public int ID { get; set; }

        //姓名
        public string Name { get; set; }

        //学生所在的班级
        public SchoolClass MyClass { get; set; }
    }
}
