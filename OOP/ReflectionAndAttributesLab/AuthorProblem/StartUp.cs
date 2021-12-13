namespace AuthorProblem
{
    [Author("Zlati")]
    public class StartUp
    {
        [Author("Pencho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}
