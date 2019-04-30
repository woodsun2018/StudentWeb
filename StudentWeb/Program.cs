using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentWeb.Models;

namespace StudentWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            IWebHost webHost = CreateWebHostBuilder(args).Build();

            //系统初始化
            AppInit(webHost.Services);

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        //系统初始化
        private static void AppInit(IServiceProvider serviceProvider)
        {
            //初始化数据库
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<StudentWebContext>();

                //确保创建数据库
                context.Database.EnsureCreated();

                if (context.SchoolClass.Any())
                    return;

                var schoolClass61 = new SchoolClass()
                {
                    ClassTitle = "六一班"
                };

                //先保存班级，否则报错
                //Unable to save changes because a circular dependency was detected in the data to be saved: 'SchoolClass [Added] <- Students MyClass { 'MyClassID' } Student [Added] <- Chinese { 'ChineseID' } SchoolClass [Added]'.
                context.Add(schoolClass61);
                int rows = context.SaveChanges();
                Console.WriteLine($"添加了班级{schoolClass61.ClassTitle}, 影响记录{rows}");

                var student1 = new Student()
                {
                    Name = "张三",
                };

                var student2 = new Student()
                {
                    Name = "李四",
                };

                var student3 = new Student()
                {
                    Name = "王五",
                };

                var student4 = new Student()
                {
                    Name = "赵六",
                };

                schoolClass61.Students = new List<Student>()
                {
                    student1,
                    student2,
                    student3,
                    student4
                };

                //设置同学的职位
                schoolClass61.ClassMonitor = student1;
                schoolClass61.Chinese = student2;
                schoolClass61.Mathematics = student3;

                //保存到数据库
                rows = context.SaveChanges();
                Console.WriteLine($"添加了{schoolClass61.Students.Count}位同学, 影响记录{rows}");

                //添加老师
                var teacher1 = new Teacher()
                {
                    Name = "孔子"
                };

                var teacher2 = new Teacher()
                {
                    Name = "李白"
                };

                var teacher3 = new Teacher()
                {
                    Name = "祖冲之"
                };

                //设置老师的职位
                schoolClass61.HeadTeacher = teacher1;
                schoolClass61.ChineseTeacher = teacher2;
                schoolClass61.MathTeacher = teacher3;

                //保存到数据库
                rows = context.SaveChanges();
                Console.WriteLine($"添加了老师, 影响记录{rows}");

            }
        }
    }
}
