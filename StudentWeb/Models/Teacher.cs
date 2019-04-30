using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentWeb.Models
{
    //老师
    public class Teacher
    {
        //主键
        public int ID { get; set; }

        //姓名
        public string Name { get; set; }

        public int? AdminClassID { get; set; }

        //老师作为班主任管理的班级
        public SchoolClass AdminClass { get; set; }
    }
}
