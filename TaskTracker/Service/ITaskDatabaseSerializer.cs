namespace TaskTracker.Service
{
    internal interface ITaskDatabaseSerializer
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        Task<IEnumerable<Model.Task>> LoadTasksAsync(string filepath);
        Task SaveTasksAsync(string filepath, IEnumerable<Model.Task> tasks);
    }
}