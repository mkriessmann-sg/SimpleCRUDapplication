using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace SimpleCRUDapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<Book> books = new List<Book>();
            bool startup = true;
            bool run= true;
            string? input = null; 
                   



            while (run) 
            {
                Console.Clear();
                if (startup) Console.WriteLine("こんにちは！\n書籍管理ソフトへようこそ！"); 
                Console.WriteLine("Select Operation");
                Console.WriteLine("1 Display Current Books");
                Console.WriteLine("2 Add Books");
                Console.WriteLine("3 Delete Books");
                Console.WriteLine("4 Edit book information");
                Console.WriteLine("5 Exit");
                Console.Write("Please select operation:");
                input = Console.ReadLine();

                switch (input) 
                {
                    case "1":
                        DisplayBooks(books);
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:

                        Console.WriteLine("invalid input");
                        break;
                }
               
            }

        }
        static void DisplayBooks(List<Book> books)
        {
            Console.Clear();
            foreach (Book b in books)
            {
                Console.WriteLine(b.identifier + ". " + b.title + " by" + b.author);

            }
            Console.Write("Press any Key to return");
            Console.ReadKey();

        }    
        static void AddBook(List<Book> books)
        {
            Console.Clear();    
            Console.Write("Please enter Title:");
            string title = Console.ReadLine();
            Console.Write("Please enter Author:");
            string author = Console.ReadLine();
            Console.Write("Please enter identifier:");
            //TODO: Add try and catch for invalid inputs
            int identifier = Convert.ToInt32(Console.ReadLine());
            

        }
       
        static int TestForDuplicate(List<Book> books, int identifier)
        {
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {
                    Console.Write("Duplicate detected, please enter different desiered number:");
                    //TODO: Add try and catch for invalid inputs
                    identifier = Convert.ToInt32(Console.ReadLine());
                    identifier= TestForDuplicate(books, identifier);
                }
            }

            return identifier;
        }

        class Book
        {
            public string title;
            public string author;
            public int identifier;
        
        }



    }
}
