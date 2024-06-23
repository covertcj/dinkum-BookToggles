namespace BookToggles.BookHandlers
{
    class BugBookHandler : IBookHandler
    {
        private bool _isBookOpen;

        public string Name => "Bug";

        public bool canHandleBook(UseBook book)
        {
            return book.isBugBook;
        }

        public void toggleBook(UseBook book)
        {
            _isBookOpen = !_isBookOpen;
            AnimalManager.manage.bugBookOpen = _isBookOpen;
            AnimalManager.manage.lookAtBugBook.Invoke();
        }
    }
}