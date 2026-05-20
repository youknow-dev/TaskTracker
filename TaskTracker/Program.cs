using System.Text.Json;
using TaskTracker.Service;

namespace TaskTracker
{
    public class Program
    {
        internal static ITaskDatabaseSerializer serializer = new JsonTaskDBSerializer();
        internal static IParser parser = new ArgumentParser();
        internal static string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.json");

        public static async Task Main(string[] args)
        {
            parser.Parse(args, await serializer.LoadTasksAsync(dbPath));
        }
    }
}