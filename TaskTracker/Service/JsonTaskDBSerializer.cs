
using System.Text.Json;

namespace TaskTracker.Service
{
    internal class JsonTaskDBSerializer : ITaskDatabaseSerializer
    {
        private readonly JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };

        public async Task<List<Model.Task>> LoadTasksAsync(string filepath)
        {
            if (!File.Exists(filepath))
            {
                await SaveTasksAsync(filepath, []);
            }

            using FileStream stream = File.OpenRead(filepath);
            return (await JsonSerializer.DeserializeAsync<List<Model.Task>>(stream))!; // should never be null
        }

        public async Task SaveTasksAsync(string filepath, List<Model.Task> tasks)
        {
            using FileStream stream = File.Open(filepath, FileMode.Create);
            await JsonSerializer.SerializeAsync(stream, tasks, options);
        }
    }
}