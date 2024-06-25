namespace BookToggles.Handlers
{
    class BugBookHandler : IBookHandler
    {
        private bool _isBookOpen;

        public string Name => "Bug";

        public bool CanHandleBook(UseBook book)
        {
            return book.isBugBook;
        }

        public bool ToggleBook()
        {
            _isBookOpen = !_isBookOpen;
            AnimalManager.manage.bugBookOpen = _isBookOpen;
            AnimalManager.manage.lookAtBugBook.Invoke();
            return _isBookOpen;
        }

        public void CloseBook()
        {
            if (_isBookOpen)
            {
                ToggleBook();
            }
        }

        public void RefreshBook()
        {
            if (_isBookOpen)
            {
                ToggleBook();
                ToggleBook();
            }
        }
    }
}