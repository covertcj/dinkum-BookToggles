namespace BookToggles.Handlers
{
    class FishBookHandler : IBookHandler
    {
        private bool _isBookOpen;

        public string Name => "Bug";

        public bool CanHandleBook(UseBook book)
        {
            return book.isFishBook;
        }

        public bool ToggleBook()
        {
            _isBookOpen = !_isBookOpen;
            AnimalManager.manage.fishBookOpen = _isBookOpen;
            AnimalManager.manage.lookAtFishBook.Invoke();
            return _isBookOpen;
        }

        public void CloseBook()
        {
            if (_isBookOpen)
            {
                ToggleBook();
            }
        }
    }
}