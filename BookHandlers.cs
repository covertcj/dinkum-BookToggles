using BookToggles.Handlers;

namespace BookToggles
{
    static class BookHandlers
    {
        public static BugBookHandler BugBookHandler = new BugBookHandler();
        public static FishBookHandler FishBookHandler = new FishBookHandler();

        public static IBookHandler[] Handlers = {
            BugBookHandler,
            FishBookHandler
        };
    }
}