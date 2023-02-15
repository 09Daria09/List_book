using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_book
{
    class Library : IEnumerable
    {
        Book[] count;
        static int len = 0;
        public Library(int book)
        {
            count = new Book[book];
            for (int i = 0; i < count.Length; i++)
            {
                count[i] = new Book();
                count[i].Init();
            }
        }
        public Library(Book[] books)
        {
            count = new Book[books.Length];
            for (int i = 0; i < books.Length; i++)
            {
                count[i] = new Book(books[i].Title, books[i].Author, books[i].YearPublishing, books[i].Star);
            }
        }
        public Book this[int i]
        {
            get => count[i];
            set => count[i] = value;
        }
        public void Add()
        {
            Console.Write("\nСколько книг вы хотете добавить -> ");
            int countBook = Convert.ToInt32(Console.ReadLine());

            int allElem = count.Length;
            Array.Resize(ref count, count.Length + countBook);
            for (int i = allElem; i < count.Length; i++)
            {
                count[i] = new Book();
                count[i].Init();
            }
        }
        public void Delete()
        {
            Console.Write($"\nВведите номер книги которую вы хотите удалить (1 - {count.Length}) -> ");
            int index = Convert.ToInt32(Console.ReadLine());

            if (index < 0 || index >= count.Length)
            {
                Console.WriteLine("Индекс за пределами массива");
                return;
            }
            count[index - 1] = null;
            count = count.Where(x => x != null).ToArray();
        }
        public void Faind()
        {
            Console.Write($"\nВведите название книги -> ");
            string str = Console.ReadLine();
            bool haveBook = false;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i].Title == str)
                {
                    Console.WriteLine("Ваша книга");
                    Console.WriteLine(count[i].ToString());
                    haveBook = true;
                }
            }
            if (haveBook == false)
                Console.WriteLine("Книга не найдена");


        }
        public override string ToString()
        {
            string result = null;
            for (int i = 0; i < count.Length; i++)
                result += $"\n\t-----{i + 1}-----\n" + count[i].ToString();
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            Console.WriteLine("\nВыполняется утипизация");
            for (int i = 0; i < count.Length; i++)
                yield return count[i];
        }
    }

    class Book : ICloneable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublishing { get; set; }
        public int Star { get; set; }
        public Book() 
        {
            Title = null;
            Author = null;
            YearPublishing = 0;
            Star = 0;
        }
        public Book(string title, string author, int yearPublishing, int star)
        {
            Title = title;
            Author = author;
            YearPublishing = yearPublishing;
            Star = star;
        }
        public void Init()
        {
            Console.Write("Введите название книги -> ");
            Title = Console.ReadLine();
            Console.Write("Введите автора книги -> ");
            Author = Console.ReadLine();
            Console.Write("Введите годи издания книги -> ");
            YearPublishing = Convert.ToInt32(Console.ReadLine());
            Console.Write("Cколько звезд вы поставите книге (0-5) -> ");
            Star = Convert.ToInt32(Console.ReadLine());
        }
        public string PrintStar()
        {
            string buf = null;
            for (int i = 0; i < Star; i++)
                buf += "* ";
            return buf;
        }
        public override string ToString()
        {
            return $"Название книги: {Title}\nАвтор книги: {Author}\nГод издания книги: {YearPublishing}\n" +
                $"Оценка книги: {PrintStar()}";
        }

        public object Clone()
        {
            return new Book(Title, Author, YearPublishing, Star);
        }

        public class SortByName : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).Title.CompareTo((obj2 as Book).Title);

                throw new NotImplementedException();
            }
        }
        public class SortByCity : IComparer
        {
            int IComparer.Compare(object obj1, object obj2)
            {
                if (obj1 is Book && obj2 is Book)
                    return (obj1 as Book).Author.CompareTo((obj2 as Book).Author);

                throw new NotImplementedException();
            }
        }

    }
}
