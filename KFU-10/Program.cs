using System;
using System.IO;

namespace KFU_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventManager eventManager = new EventManager();
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "studentsDB.txt");
            eventManager.LoadStudentsFromFile(filePath);
            DateTime date = DateTime.Now;

            Student stud = new Student("Степанов Григорий", "09-322");
            Student stud2 = new Student("Шайхрамов Ильяс", "09-322", true);

            eventManager.students.Add(stud);
            eventManager.students.Add(stud2);

            eventManager.CreateEvent(date, "Music Festiival", 5, 5, 2);
            eventManager.CreateEvent(date, "Cybersport", 5, 5, 0);
            eventManager.CreateEvent(date, "Theatre", 4, 2, 1);

            eventManager.events[0].studentsEvents.Add(stud);
            eventManager.events[1].studentsEvents.Add(stud);
            eventManager.events[2].studentsEvents.Add(stud);
            eventManager.events[2].studentsEvents.Add(stud2);

            eventManager.AddStudentsToEvent();
        }
    }
}
