using LinqPractices.DbOperations;
using LinqPractices.Entities;

DataGenerator.Initialize();
LinqDbContext context = new LinqDbContext();
var students = context.Students.ToList<Student>();

// Find()
Console.WriteLine("**** Find ****");
var student = context.Students.Where(student => student.StudentId == 1).FirstOrDefault();
student = context.Students.Find(3);
Console.WriteLine(student.Name);

// FirstOrDefault()
Console.WriteLine();
Console.WriteLine("**** First Or Default ****");
student = context.Students.Where(student => student.SurName == "Arda").FirstOrDefault();
Console.WriteLine(student.Name + " " +  student.SurName);
student = context.Students.FirstOrDefault(x => x.SurName == "Arda");
Console.WriteLine(student.Name + " " + student.SurName);

// SingleOrDefault()
Console.WriteLine();
Console.WriteLine("**** Single Or Default ****");
student = context.Students.SingleOrDefault(x => x.SurName == "Yılmaz");
Console.WriteLine(student.Name + " " + student.SurName);

// ToList()
Console.WriteLine();
Console.WriteLine("**** To List By ClassId ****");
var studentList = context.Students.Where(student => student.ClassId == 2).ToList();
foreach (var st in studentList)
{
    Console.WriteLine(st.ClassId + " " + st.Name);
}

// Order By
Console.WriteLine();
Console.WriteLine("**** Order By Desc ****");
students = context.Students.OrderByDescending(x => x.ClassId).ToList();
foreach (var st1 in students)
{
    Console.WriteLine(st1.ClassId + " - " + st1.Name + " " + st1.SurName);
}

// Anonymous Object Result
Console.WriteLine();
Console.WriteLine("**** Anonymous Object Result ****");
var anonymousObject = context.Students
                       .Where(x => x.ClassId == 2)
                       .Select(x => new
                       {
                           Id = x.StudentId,
                           FullName = x.Name + " " + x.SurName
                       });
foreach (var obj in anonymousObject)
{
    Console.WriteLine(obj.Id + " - " + obj.FullName);
}