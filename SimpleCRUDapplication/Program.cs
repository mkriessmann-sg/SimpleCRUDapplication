using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics.Metrics;

namespace SimpleCRUDapplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Programme programme = new Programme();
            Console.WriteLine("こんにちは！\n書籍管理ソフトへようこそ！");
            programme.Execute();

        }
    }
    public class Programme()
    {
        List<Book> books = new List<Book>();
        bool run = true;
        string? input = null;




        public void Execute()
        {
            
           
                Console.Clear();
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
                        DisplayBooks(books, "Main");
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
        void DisplayBooks(List<Book> books, string context)
        {
            Console.Clear();
            foreach (Book b in books)
            {
                Console.WriteLine(b.identifier + ". " + b.title + " by" + b.author);

            }
            Console.Write("Press any Key to return");
            Console.ReadKey();

            switch (context)
            {
                case "Main":
                    
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
            //TODO: Implement return to to screen with context

        }
        void AddBook(List<Book> books)
        {
            Console.Clear();
            Console.Write("Please enter Title:");
            string? title = Console.ReadLine();
            Console.Write("Please enter Author:");
            string? author = Console.ReadLine();
            Console.Write("Please enter identifier:");
            //TODO: Add try and catch for invalid inputs
            int tempidentifier = Convert.ToInt32(Console.ReadLine());
            int identifier = TestForDuplicate(books, tempidentifier);

            Book b = new Book(title, author, identifier);
            books.Add(b);
            Console.Write("Press any Key to return");
            Console.ReadKey();

        }

        int TestForDuplicate(List<Book> books, int identifier)
        {
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {
                    Console.Write("Duplicate detected, please enter different desiered number:");
                    //TODO: Add try and catch for invalid inputs
                    identifier = Convert.ToInt32(Console.ReadLine());
                    identifier = TestForDuplicate(books, identifier);
                }
            }

            return identifier;
        }
        //TODO: implement function
        void DeleteBook(List<Book> books)
        {
            int? identifier = null;
            Console.Clear();
            Console.Write("Please enter the identifyer of the book you would like to delete.\nIf you do not know the identifier of the book you would like to delete, enter 's' to display the list of books.\nPlease enter here:");
            string? _tempInput;
            _tempInput = Console.ReadLine();
            if (_tempInput == "s")
            {
                DisplayBooks(books, "Delete");

            }
            else
            {
                //TODO: Implement catch for wrong input
                identifier = Convert.ToInt32(_tempInput);
            }

            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {

                }
                else
                {
                    //TODO:Implement wrong input
                }
            }
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {

                    books.Remove(b);
                }
            }


        }

        //TODO: implement function
        void EditBook(List<Book> books)
        {

        }




    }

    class Book
    {
        public string? title;
        public string? author;
        public int identifier;

        public Book(string? title, string? author, int identifier)
        {
            this.title = title;
            this.author = author;
            this.identifier = identifier;
        }
    }

}






