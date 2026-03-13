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