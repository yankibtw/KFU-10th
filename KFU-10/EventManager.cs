using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace KFU_10
{
    class EventManager
    {
        public List<Student> students;
        public List<Event> events;

        public EventManager()
        {
            students = new List<Student>();
            events = new List<Event>();
        }
        public void LoadStudentsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(';');
                    if (parts.Length == 2)
                    {
                        string studentName = parts[0].Trim();
                        string groupName = parts[1].Trim();
                        students.Add(new Student(studentName, groupName));
                    }
                }
            }
        }
        public void MarkParticipationForThreeLastEvent(Event eventTag)
        {
            foreach (Student student in students)
            {
                if (eventTag.studentsEvents.Contains(student))
                {
                    student.ParticipatedInLastThreeEvents = true;
                }
            }
        }
        public List<Student> GetFreeloaderStudent()
        {
            return students.Where(value => !value.ParticipatedInLastThreeEvents).ToList();
        }
        public void CreateEvent()
        {
            Console.WriteLine("Введите дату мероприятия (в формате DD.MM.YYYY): ");
            DateTime eventDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите название мероприятия: ");
            string eventName = Console.ReadLine();

            Console.WriteLine("Введите количество участников от каждой группы: ");
            int participantsPerGroup = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимальное количество групп для проведения розыгрыша: ");
            int minGroupsForDrawing = int.Parse(Console.ReadLine());

            events.Add(new Event(eventDate, eventName, participantsPerGroup, minGroupsForDrawing));
        }
        public void CreateEvent(DateTime eventDate, string eventName, int participantsPerGroup, int minGroupsForDrawing, int placeForTheDesireToParticipate)
        {
            events.Add(new Event(eventDate, eventName, participantsPerGroup, minGroupsForDrawing, placeForTheDesireToParticipate));
        }
        public void AddStudentsToEvent()
        {
            var result = events.Skip(Math.Max(0, events.Count - 3)).ToList();
            foreach (var eve in result)
            {
                MarkParticipationForThreeLastEvent(eve);
            }

            List<Student> freeLoaderStudents = GetFreeloaderStudent();
            List<string> selectedParticipants = new List<string>();
            var groupedStudents = students.GroupBy(v => v.IDGroup);

            foreach (var group in groupedStudents)
            {
                List<string> selectedGroupParticipants = group.OrderBy(s => Guid.NewGuid())
                    .Where(s => s.TheDesireToParticipate && !freeLoaderStudents.Contains(s))
                    .Take(events.Last().PlaceForTheDesireToParticipate)
                    .Concat(group.Where(s => freeLoaderStudents.Contains(s)).Take(events.Last().MinStudentsPerGroup - group.Count(s => s.TheDesireToParticipate == true && events.Last().studentsEvents.Contains(s))))
                    .Select(s => $"{s.FullName}; {s.IDGroup}")
                    .ToList();

                foreach (var participant in selectedGroupParticipants)
                {
                    selectedParticipants.Add(participant);
                }
            }
            WriteEventResultToFile(events.Last(), selectedParticipants);
        }
        private void WriteEventResultToFile(Event currentEvent, List<string> selectedParticipants)
        {
            string filePath = "events.txt";
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{currentEvent.Date:dd.MM.yyyy}; {currentEvent.Name}; {string.Join(", ", selectedParticipants)}");
            }
        }
    }
}
