using TaskTracker.Service;

namespace TaskTracker
{
    public class Program
    {
        internal static IParser parser = new ArgumentParser();

        public static async Task Main(string[] args)
        {
            parser.Parse(args);
        }
    }
}