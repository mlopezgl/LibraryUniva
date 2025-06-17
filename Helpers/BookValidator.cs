using LibraryManager.Models;

namespace LibraryManager.Helpers
{
    public static class BookValidator
    {
        public static bool Validate(Book book, out string error)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                error = "Title is required.";
                return false;
            }

            error = "";
            return true;
        }
    }
}