namespace BookToggles.BookHandlers
{
    interface IBookHandler
    {
        string Name { get; }
        bool canHandleBook(UseBook book);
        void toggleBook(UseBook book);
    }
}