using System;
using System.Collections.Generic;

namespace KFU_10
{
    class Event
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int Groups { get; set; }
        public int MinStudentsPerGroup { get; set; }
        public List<Student> studentsEvents { get; set; }
        public int PlaceForTheDesireToParticipate { get; set; }


        public Event(DateTime date, string name, int groups = 1, int minStudentsPerGroup = 1, int placeForTheDesireToParticipate = 1)
        {
            Date = date;
            Name = name;
            Groups = groups;
            MinStudentsPerGroup = minStudentsPerGroup;
            studentsEvents = new List<Student>();
            PlaceForTheDesireToParticipate = placeForTheDesireToParticipate;
        }
    }
}
