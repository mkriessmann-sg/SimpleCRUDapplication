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
        int? input = null;



        //MAIN FUNCTIONS
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
            string tempinput = Console.ReadLine();
            input = CheckForIntInput(tempinput);
            Console.Clear();
            switch (input)
            {
                case 1:
                    DisplayBooks(books, "Main");
                    break;
                case 2:
                    AddBook(books);
                    break;
                case 3:
                    DeleteBook(books);
                    break;
                case 4:
                    EditBook(books);
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:

                    Console.WriteLine("invalid input");
                    break;
            }



        }
        void DisplayBooks(List<Book> books, string context)
        {
            
            foreach (Book b in books)
            {
                Console.WriteLine(b.identifier + ". " + b.title + " by" + b.author);

            }
            Console.Write("Press any Key to return");
            Console.ReadKey();
            Console.Clear();

            switch (context)
            {
                case "Main":
                    Execute();  
                    break;
                case "Add":
                    AddBook(books);
                    break;
                case "Delete":
                    DeleteBook(books);
                    break;
                case "Edit":
                    EditBook(books);
                    break;
                
                default:

                    Console.WriteLine("unexpected error");
                    break;
            }
            

        }
        void AddBook(List<Book> books)
        {
            Console.Write("Please enter Title:");
            string? title = Console.ReadLine();
            Console.Write("Please enter Author:");
            string? author = Console.ReadLine();
            Console.Write("Please enter identifier:");
            string? _tempInput = Console.ReadLine();
            int tempidentifier = CheckForIntInput(_tempInput);
            int identifier = TestForDuplicate(books, tempidentifier);

            Book b = new Book(title, author, identifier);
            books.Add(b);
            Console.Write("Press any Key to return");
            Console.ReadKey();
            Console.Clear();
            Execute();
        }

        //TODO: implement function
        void DeleteBook(List<Book> books)
        {
            int? identifier = null;
            
            Console.Write("Please enter the identifyer of the book you would like to delete.\nIf you do not know the identifier of the book you would like to delete, enter 's' to display the list of books.\nPlease enter here:");
            string? _tempInput;
            _tempInput = Console.ReadLine();
            if (_tempInput == "s")
            {
                DisplayBooks(books, "Delete");

            }
            else
            {

                identifier = CheckForIntInput(_tempInput);
            }

            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {

                }
                else
                {
                    Console.WriteLine("The selected idenfifier does not exist.");
                    DeleteBook(books);
                    //Return immedeately to improve performance
                    return;

                }
            }
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {

                    books.Remove(b);
                }
            }
            Console.Clear();
            Execute (); 

        }

        //TODO: implement function
        void EditBook(List<Book> books)
        {
            int? identifier = null;

            Console.Write("Please enter the identifyer of the book you would like to delete.\nIf you do not know the identifier of the book you would like to delete, enter 's' to display the list of books.\nPlease enter here:");
            string? _tempInput;
            _tempInput = Console.ReadLine();
            if (_tempInput == "s")
            {
                DisplayBooks(books, "Delete");

            }
            else
            {

                identifier = CheckForIntInput(_tempInput);
            }

            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {

                }
                else
                {
                    Console.WriteLine("The selected idenfifier does not exist.");
                    DeleteBook(books);
                    //Return immedeately to improve performance
                    return;

                }
            }
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {
                    EditBookInformation(b);
                    
                }
            }
            Console.Clear();
            Execute();  
        }









        //SUPPLEMENTARY FUNCTIONS
        int TestForDuplicate(List<Book> books, int identifier)
        {
            foreach (Book b in books)
            {
                if (b.identifier == identifier)
                {
                    Console.Write("Duplicate detected, please enter different desiered number:");
                    string? _tempInput = Console.ReadLine();
                    identifier = CheckForIntInput(_tempInput);
                    identifier = TestForDuplicate(books, identifier);
                }
            }

            return identifier;
        }

        int CheckForIntInput(string _input)
        {


            if (int.TryParse(_input, out int result))
            {
                return result; // Successfully parsed, return the integer
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                string? _newInput = Console.ReadLine();
                return CheckForIntInput(_newInput);
            }
        }

        void EditBookInformation(Book book)
        {
            Console.WriteLine("Please Select the operation you would like to perform:\n1... Edit Title\n2...Edit Author\n3...Edit Both\nPlease enter here:");
            string? _tempInput = Console.ReadLine();
            int _selection = CheckForIntInput(_tempInput);

            switch (input)
            {
                case 1:
                    Console.WriteLine("Please enter new Title");
                    book.title = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("Please enter new Author");
                    book.author = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("Please enter new Title");
                    book.title = Console.ReadLine();
                    Console.WriteLine("Please enter new Author");
                    book.author = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine("invalid input");
                    EditBookInformation(book);
                    break;
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
}






