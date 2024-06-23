namespace BookToggles.Handlers
{
    class FishBookHandler : IBookHandler
    {
        private bool _isBookOpen;

        public string Name => "Bug";

        public bool canHandleBook(UseBook book)
        {
            return book.isFishBook;
        }

        public bool toggleBook()
        {
            _isBookOpen = !_isBookOpen;
            AnimalManager.manage.fishBookOpen = _isBookOpen;
            AnimalManager.manage.lookAtFishBook.Invoke();
            return _isBookOpen;
        }

        public void closeBook()
        {
            if (_isBookOpen)
            {
                toggleBook();
            }
        }
    }
}