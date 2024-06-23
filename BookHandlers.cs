using BookToggles.Handlers;

namespace BookToggles
{
    static class BookHandlers
    {
        public static IBookHandler[] Handlers = { new BugBookHandler(), new FishBookHandler() };
    }
}