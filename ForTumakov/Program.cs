using System;
using Tumakov;
using TUmakov;

namespace ForTumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Задание 1
            Console.WriteLine("Задание 1:");
            uint account = BankFabric.CreateAccount(1000, 0);
            uint defaultAccountNumber = BankFabric.CreateAccount();
            BankFabric.CloseAccount(account);

            //Задание 2
            Console.WriteLine("\nЗадание 2:");
            uint build = Creator.CreateBuild(10, 200, 300, 10);
            uint build2 = Creator.CreateBuild(10, 200, 300, 10);
            BankFabric.CloseAccount(build2);

            //Задание 3
            Console.WriteLine("\nЗадание 3:");
            Bank account1 = new Bank(1000, BankTypes.Saving);
            Bank account2 = new Bank(500, BankTypes.Saving);
            Bank account3 = new Bank(1000, BankTypes.Saving);

            Console.WriteLine(account1 == account2);
            Console.WriteLine(account1 != account2);
            Console.WriteLine(account1 == account3);

            Console.WriteLine(account1.Equals(account3));
            Console.WriteLine(account1.ToString());

            //Задание 4
            Console.WriteLine("\nЗадание 4:");
            try
            {
                RationalNumbers first = new RationalNumbers(1, 2);
                RationalNumbers second = new RationalNumbers(1, 5);

                Console.WriteLine($"Сумма: {first + second}");
                Console.WriteLine($"Разность: {first - second}");
                Console.WriteLine($"Произведение: {first * second}");
                Console.WriteLine($"Частное: {first / second}");
                Console.WriteLine($"Остаток от деления: {first % second}");

                Console.WriteLine($"\n{first} = {second}: {first == second}");
                Console.WriteLine($"{first} != {second}: {first != second}");
                Console.WriteLine($"{first} < {second}: {first < second}");
                Console.WriteLine($"{first} > {second} : {first > second}");
                Console.WriteLine($"{first} <= {second}: {first <= second}");
                Console.WriteLine($"{first}  >=  {second} : {first >= second}");

                Console.WriteLine($"\n++{first}: {++first}");
                Console.WriteLine($"--{second}: {--second}");

                Console.WriteLine($"\n{first} в int: {(int)first}");
                Console.WriteLine($"{second} в float: {(float)second}");

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            //Задание 5
            Console.WriteLine("\nЗадание 5");
            ComplexNumber complex1 = new ComplexNumber(1, 5);
            ComplexNumber complex2 = new ComplexNumber(3, 2);

            Console.WriteLine($"Сумма: {complex1 + complex2}");
            Console.WriteLine($"Разность: {complex1 - complex2}");
            Console.WriteLine($"Произведение: {complex1 * complex2}");

            Console.WriteLine($"complex1 равно complex2: {complex1 == complex2}");
            Console.WriteLine($"complex1 не равно complex2: {complex1 != complex2}");

            //Задание 6
            Console.WriteLine("\nЗадание 6");
            BookContainer books = new BookContainer();

            books.AddBook(new Book("Гарри Поттер и узник Азкабана", "Джоан Роулинг", "Азбука-Аттикус"));
            books.AddBook(new Book("Унесенные ветром", "Маргарет Митчел", "Азбука-Аттикус"));
            books.AddBook(new Book("Зелёная миля", "Стивен Кинг", "ACT"));
            books.AddBook(new Book("Свита короля", "Нора Сакавич", "Popcorn Books"));

            Console.WriteLine("Неотсортированные книги:");
            books.DisplayBooks();

            Console.WriteLine("\nСортировка по названию:");
            books.SortBooks(CompareByTitle);
            books.DisplayBooks();

            Console.WriteLine("\nСортировка по автору:");
            books.SortBooks(CompareByAuthor);
            books.DisplayBooks();

            Console.WriteLine("\nСортировка по издательству:");
            books.SortBooks(CompareByPublishingHouse);
            books.DisplayBooks();

        }
        static int CompareByTitle(Book book1, Book book2)
        {
            return book1.Title.CompareTo(book2.Title);
        }
        static int CompareByAuthor(Book book1, Book book2)
        {
            return book1.Author.CompareTo(book2.Author);
        }
        static int CompareByPublishingHouse(Book book1, Book book2)
        {
            return book1.PublishingHouse.CompareTo(book2.PublishingHouse);
        }
    }
}

