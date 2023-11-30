namespace TUmakov
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PublishingHouse { get; set; }

        public Book(string title, string author, string publishingHouse)
        {
            Title = title;
            Author = author;
            PublishingHouse = publishingHouse;
        }
        public override string ToString()
        {
            return $"Книга: {Title}\nАвтор: {Author}\nИздательство: {PublishingHouse}\n";
        }
    }
}
