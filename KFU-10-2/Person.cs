namespace KFU_10_2
{
    enum Reactions
    {
        Wow,
        Good,
        Well,
        Beautiful,
        Godness
    }
    internal class Person
    {
        public string Name { get; set; }
        public string Hobby { get; set; }
        public Reactions Actions { get; set; }

        public Person(string name, string hobby, Reactions actions)
        {
            Name = name;
            Hobby = hobby;
            Actions = actions;
        }
        public Person() { }
    }
}
