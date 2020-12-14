using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;

namespace ConsoleApp15
{
    class StudentContext : DbContext
    {
        public StudentContext() : base("DbConnection") { }
        public DbSet<Student> Students { get; set; }
    }
    
    public class Student
    {
        public int Id { get; set; }
        public string Fio { get; set; }
        public int Age { get; set; }
        public string Group { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            using(StudentContext db = new StudentContext())
            {
                Student st1 = new Student { Fio = "Иванов Иван Иванович", Age = 19, Group = "19-11-1 ИСиП" };
                Student st2 = new Student { Fio = "Петров Александр Александрович", Age = 20, Group = "19-11-2 ИСиП" };
                Student st3 = new Student { Fio = "Понова Ирина Ивановна", Age = 19, Group = "19-11-2 ИСиП" };
                Student st4 = new Student { Fio = "Смиронова Полина Алексеевна", Age = 20, Group = "19-11-1 ИСиП" };
                Student st5 = new Student { Fio = "Попов Петр Павлович", Age = 19, Group = "19-11-1 ИСиП" };

                db.Students.Add(st1);
                db.Students.Add(st2);
                db.Students.Add(st3);
                db.Students.Add(st4);
                db.Students.Add(st5);
                db.SaveChanges();
                Console.WriteLine("Объекты сохранены");

                var students = db.Students;
                Console.WriteLine("Список объектов:");
                foreach(Student s in students)
                {
                    Console.WriteLine("ID: {0} - ФИО: {1} - Возраст: {2} - Группа: {3};",s.Id, s.Fio, s.Age, s.Group);
                }
            }
            Console.Read();
        }
    }
}
