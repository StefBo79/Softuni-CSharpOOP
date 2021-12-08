namespace CodeTracker
{ //first rename the project to AuthorProblem
    [Author("Anakin")]
    public class StartUp
    {
        [Author("DartVayder")]
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}