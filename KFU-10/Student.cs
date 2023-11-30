namespace KFU_10
{
    class Student
    {
        public string FullName { get; private set; }
        public string IDGroup { get; private set; }
        public bool ParticipatedInLastThreeEvents { get; set; }
        public bool TheDesireToParticipate { get; set; }

        public Student(string name, string group, bool theDesireToParticipate = false)
        {
            FullName = name;
            IDGroup = group;
            ParticipatedInLastThreeEvents = false;
            TheDesireToParticipate = theDesireToParticipate;
        }
    }
}
