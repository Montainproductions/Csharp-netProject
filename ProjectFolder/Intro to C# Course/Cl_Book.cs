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