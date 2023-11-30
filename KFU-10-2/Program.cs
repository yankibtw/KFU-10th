using System;
using System.Collections.Generic;

namespace KFU_10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person { Name = "Алиса", Hobby = "Сериалы", Actions = Reactions.Wow },
                new Person { Name = "Артем", Hobby = "Концерты", Actions = Reactions.Beautiful },
                new Person { Name = "Дима", Hobby = "Спорт", Actions = Reactions.Godness },
            };

            Console.Write("Введите интересующее вас событие: ");
            string userInput = Console.ReadLine();

            foreach (Person person in people)
            {
                if (string.Equals(userInput, person.Hobby, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"{person.Name} реагирует: {person.Actions}");
                    return; 
                }
            }
            Console.WriteLine("Ни у кого из знакомых нет такого увлечения для этого события.");
        }
    }
}
