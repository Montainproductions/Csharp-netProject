using System;

public class Program
{
    public static void Main()
    {
        Library newLibrary = new Library("Joaquins Emporium");

        newLibrary.WhatToDo(); 
    }
}

public class Library
{
    string libraryName = "";
    List<Book> listOfBooksInLibrary = new List<Book>();

    Customer customer = new Customer("Joaquin", 3);

    public Library(string newLibraryName)
    {
        libraryName = newLibraryName;
    }

    public void WhatToDo()
    {

        while(true){
            Console.WriteLine("What do you want to do: (Add book to library|Remove by title|Remove by author|Search|Borrow book|Display all books|Exit)");
            string whatToDo = Console.ReadLine();
            if (whatToDo == "Add book to library")
            {
                AddBook();
            }
            else if (whatToDo == "Remove by title")
            {
                RemoveBookByBookTitle();
            }
            else if (whatToDo == "Remove by author")
            {
                RemoveBookByAuthorName();
            }
            else if (whatToDo == "Search by title")
            {
                SearchForBookByTitle();
            }
            else if (whatToDo == "Borrow book")
            {
                CheckOutBook();
            }
            else if (whatToDo == "Return book")
            {
                ReturnBook();
            }
            else if (whatToDo == "Display all books")
            {
                DisplayBooks();
            }
            else if (whatToDo == "Exit")
            {
                break;
            }
            else
            {
                WhatToDo();
                break;
            }
        }
    }

    public void AddBook()
    {
        Console.WriteLine("Enter Book Name to add:");
        string bookName = Console.ReadLine();
        Console.WriteLine(" ");
        Console.WriteLine("Enter Author Name to add:");
        string AuthorName = Console.ReadLine();

        Book newBookToAdd = new Book(bookName, AuthorName, false);

        listOfBooksInLibrary.Add(newBookToAdd);
        Console.WriteLine(" ");
    }

    public void RemoveBookByBookTitle()
    {
        Console.WriteLine("Enter book name to remove:");
        string bookNameToRemove = Console.ReadLine();
        Console.WriteLine(" ");
        RemoveBookByBookTitle(bookNameToRemove);
    }

    public void RemoveBookByBookTitle(string bookNameToRemove)
    {
        Console.WriteLine(listOfBooksInLibrary.Count());
        for (int i = 0; i < listOfBooksInLibrary.Count(); i++)
        {
            Console.WriteLine("Given name to remove: " + bookNameToRemove + ". Current book being tested: " + listOfBooksInLibrary[i].GetBookName());
            if (listOfBooksInLibrary[i].GetBookName() == bookNameToRemove)
            {
                Console.WriteLine("The following book is being removed from the library! Book Name: " + listOfBooksInLibrary[i].GetBookName() + ". Author Name: " + listOfBooksInLibrary[i].GetAuthorName());
                listOfBooksInLibrary.RemoveAt(i);
                Console.WriteLine(" ");
            }
            else
            {
                Console.WriteLine("The following name for the book does not exist in the library. " + bookNameToRemove);
                Console.WriteLine(" ");
                if(i + 1 == listOfBooksInLibrary.Count()){ break; }
            }
        }
    }

    public void RemoveBookByAuthorName()
    {
        Console.WriteLine("Enter author name to remove:");
        string authorNameToRemove = Console.ReadLine();
        Console.WriteLine(" ");
        RemoveBookByAuthorName(authorNameToRemove);
    }

    public void RemoveBookByAuthorName(string authorNameToRemove)
    {
        for (int i = 0; i < listOfBooksInLibrary.Count(); i++)
        {
            if (listOfBooksInLibrary[i].GetBookName() == authorNameToRemove)
            {
                Console.WriteLine("The following book is being removed from the library! Book Name: " + listOfBooksInLibrary[i].GetBookName() + ". Author Name: " + listOfBooksInLibrary[i].GetAuthorName());
                listOfBooksInLibrary.RemoveAt(i);
                Console.WriteLine(" ");
            }else
            {
                Console.WriteLine("The following name for the author does not exist in the library. " + authorNameToRemove);
                Console.WriteLine(" ");
                if(i + 1== listOfBooksInLibrary.Count()){ break; }
            }
        }
    }

    public void SearchForBookByTitle()
    {
        Console.WriteLine("Enter the book title you want to search:");
        string bookTitleToSearch = Console.ReadLine();
        Console.WriteLine(" ");
        SearchForBookByTitle(bookTitleToSearch);
    }

    public void SearchForBookByTitle(string nameOfBookBeingSearched)
    {
        for(int i = 0; i < listOfBooksInLibrary.Count(); i++)
        {
            if (listOfBooksInLibrary[i].GetBookName() != nameOfBookBeingSearched)
            {
                if(i + 1 == listOfBooksInLibrary.Count()){ Console.WriteLine("The book your searching for was not found."); }
                continue;
            }

            Console.WriteLine("The book your searching for was found.");
            break;
        }
    }

    public void CheckOutBook()
    {
        if (listOfBooksInLibrary.Count() <= 0)
        {
            Console.WriteLine("There are no books to checkout.");
            return;
        }else{
            Console.WriteLine("Enter the book name you want to check out:");
            string bookNameToCheckOut = Console.ReadLine();
            Console.WriteLine(" ");
            CheckOutBook(bookNameToCheckOut);
        }
    }

    public void CheckOutBook(string bookNameToCheckOut)
    {
        for (int i = 0; i < listOfBooksInLibrary.Count(); i++)
        {

            if(listOfBooksInLibrary[i].GetBookName() != bookNameToCheckOut){ 
                if(i + 1 == listOfBooksInLibrary.Count())
                {
                    Console.WriteLine("The following book does not exist in the list of books in the library. Book Name: " + bookNameToCheckOut);
                    Console.WriteLine(" ");
                    return;
                }
                continue;
            }

            if (listOfBooksInLibrary[i].GetHasBeenCheckedOut())
            {
                Console.WriteLine("The book your looking for has already been checked out.");
                Console.WriteLine(" ");
                return;
            }

            Console.WriteLine("The following book has been checked out! Book Name: " + listOfBooksInLibrary[i].GetBookName() + ". Author Name: " + listOfBooksInLibrary[i].GetAuthorName());
            customer.NewBookCheckedOut(listOfBooksInLibrary[i]);
            Console.WriteLine(" ");

            return;
        }
    }

    public void ReturnBook()
    {
        if (customer.GetListOfCheckedOutBooks().Count() <= 0)
        {
            Console.WriteLine("There are no books to return.");
            return;
        }else{
            Console.WriteLine("Enter the book name you want to check out:");
            string bookTitleToReturn = Console.ReadLine();
            Console.WriteLine(" ");
            CheckOutBook(bookTitleToReturn, customer.GetListOfCheckedOutBooks());
        }
    }

    public void ReturnBook(string bookTitleToReturn, List<Book> listOfCheckedOutBooks)
    {
        for (int i = 0; i < listOfCheckedOutBooks.Count(); i++)
        {
            if (listOfCheckedOutBooks[i].GetBookName() != bookTitleToReturn)
            {
                if (i + 1 == listOfCheckedOutBooks.Count())
                {
                    Console.WriteLine("The user has not checked out that book.");
                }
                continue;
            }

            Console.WriteLine("The following book has been removed from the list of checked out books. Book Title: " + listOfCheckedOutBooks[i].GetBookName + ". Author Name: " + listOfCheckedOutBooks[i].GetAuthorName());
            listOfCheckedOutBooks.Remove(i);
            break;
        }
    }

    public void DisplayBooks()
    {
        foreach (Book bookToDisplay in listOfBooksInLibrary)
        {
            Console.WriteLine("The following book exists in the library! Book Name: " + bookToDisplay.GetBookName() + ". Author Name: " + bookToDisplay.GetAuthorName());
        }
    }
}

public class Customer
{
    string customerName = "";
    int amountOfBooksCheckedOut, maxBooksToCheckOut;
    List<Book> listOfCheckedOutBooks = new List<Book>();

    public Customer(string newCustomerName, int newMaxBooksToCheckOut)
    {
        customerName = newCustomerName;
        maxBooksToCheckOut = newMaxBooksToCheckOut;
        amountOfBooksCheckedOut = 0;
    }

    public void NewBookCheckedOut(Book newBookCheckedOut)
    {
        if (amountOfBooksCheckedOut == maxBooksToCheckOut)
        {
            Console.WriteLine("Already Checked out too many books. Return a book to be able to check out a new book.");
            return;
        }
            
        amountOfBooksCheckedOut++;
        listOfCheckedOutBooks.Add(newBookCheckedOut);
        newBookCheckedOut.FlipHasBeenBorrowed();
        Console.WriteLine("New book has been checked out. The name of the book is: " + newBookCheckedOut.GetBookName() + ". By: " + newBookCheckedOut.GetAuthorName());
    }

    public void ReturnBookCheckedOut(string bookName)
    {
        for (int i = 0; i < listOfCheckedOutBooks.Count(); i++)
        {
            if(listOfCheckedOutBooks[i].GetBookName() != bookName)
            {
                if (i + 1 == listOfCheckedOutBooks.Count())
                {
                    Console.WriteLine("The book your looking for has not been checked out by this person.");
                }
                continue;
            }

            listOfCheckedOutBooks.RemoveAt(i);
            amountOfBooksCheckedOut--;
            listOfCheckedOutBooks[i].FlipHasBeenBorrowed();
            Console.WriteLine("The following book was returned: " + bookName + ". You can check out a new book now.");
            break;
        }
    }

    public List<Book> GetListOfCheckedOutBooks()
    {
        return listOfCheckedOutBooks;
    }
}

public class Book
{

    string bookName, authorName;

    bool hasBeenCheckedOut;

    public Book(string newBookName, string newAuthorName, bool newHasBeenCheckedOut)
    {
        bookName = newBookName;
        authorName = newAuthorName;
        hasBeenCheckedOut = newHasBeenCheckedOut;
    }

    public void SetBookName(string newBookName)
    {
        bookName = newBookName;
    }

    public void SetAuthorName(string newAuthorName)
    {
        authorName = newAuthorName;
    }

    public void FlipHasBeenBorrowed()
    {
        hasBeenCheckedOut = !hasBeenCheckedOut;
    }

    public string GetBookName()
    {
        return bookName;
    }

    public string GetAuthorName()
    {
        return authorName;
    }
    
    public bool GetHasBeenCheckedOut()
    {
        return hasBeenCheckedOut;
    }
}