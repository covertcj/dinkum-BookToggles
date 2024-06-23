namespace BookToggles.Handlers
{
    interface IBookHandler
    {
        /// <summary>
        /// A human readable name (for logging)
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Checks whether this handler supports the given book.
        /// </summary>
        /// <param name="book">The book to check the support of</param>
        /// <returns>True if it can handle the book, otherwise false</returns>
        bool canHandleBook(UseBook book);

        /// <summary>
        /// Open the book if its closed, and close it if its open.
        /// </summary>
        /// <param name="book">The book to toggle</param>
        /// <returns>True if the book was opened, false if it was closed</returns>
        bool toggleBook();

        /// <summary>
        /// Used to force close a book for cases like when a user goes to bed.
        /// </summary>
        /// <param name="book">The book to close</param>
        void closeBook();
    }
}