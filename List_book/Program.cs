using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_book
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] book = new Book[5];

            book[0] = new Book("Война и мир", "Лев Толстой", 1873, 3);
            book[1] = new Book("Вино из одуванчиков", "Рэй Брэдбери", 1957, 4);
            book[2] = new Book("Виноваты звезды ", "Джон Грин", 2012, 5);
            book[3] = new Book("Кладбище домашних животных", "Стивен Кинг", 1983, 5);
            book[4] = new Book("50 дней до моего самоубийства", "Стейс Крамер", 2012, 5);

            //foreach (Book temp in book)
            //    Console.WriteLine($"{temp.ToString()}\n");

            //Array.Sort(book, new Book.SortByName());
            //Console.WriteLine("\nСортировка по названию:");
            //foreach (Book temp in book)
            //    Console.WriteLine($"{temp.ToString()}\n");

            //Array.Sort(book, new Book.SortByCity());
            //Console.WriteLine("\nСортировка по автору:");
            //foreach (Book temp in book)
            //    Console.WriteLine($"{temp.ToString()}\n");


            //Console.WriteLine("\nКопия обьекта:");
            //Book bookcopy = book[0].Clone() as Book;

            //Console.WriteLine($"{bookcopy.ToString()}\n");

            Library lg = new Library(book);
            foreach (Book temp in lg)
                Console.WriteLine($"{temp.ToString()}\n");
        }
    }
}
