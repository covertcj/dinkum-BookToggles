namespace BookToggles.BookHandlers
{
    class FishBookHandler : IBookHandler
    {
        private bool _isBookOpen;

        public string Name => "Bug";

        public bool canHandleBook(UseBook book)
        {
            return book.isFishBook;
        }

        public void toggleBook(UseBook book)
        {
            _isBookOpen = !_isBookOpen;
            AnimalManager.manage.fishBookOpen = _isBookOpen;
            AnimalManager.manage.lookAtFishBook.Invoke();
        }
    }
}