
using System.Text.Json;

namespace TaskTracker.Service
{
    internal class JsonTaskDBSerializer : ITaskDatabaseSerializer
    {
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
            using FileStream stream = File.OpenWrite(filepath);
            await JsonSerializer.SerializeAsync(stream, tasks);
        }
    }
}