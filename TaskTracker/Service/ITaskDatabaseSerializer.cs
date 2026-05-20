namespace TaskTracker.Service
{
    internal interface ITaskDatabaseSerializer
    {
        /// <summary>
        /// Load tasks into new collection from database file
        /// </summary>
        /// <param name="filepath">the path to the dataase file</param>
        /// <returns>New collection of tasks</returns>
        Task<List<Model.Task>> LoadTasksAsync(string filepath);

        /// <summary>
        /// Saves collection of tasks to the argument filepath 
        /// </summary>
        /// <param name="filepath">the path to save to</param>
        /// <param name="tasks">the collection of task</param>
        /// <returns></returns>
        Task SaveTasksAsync(string filepath, List<Model.Task> tasks);
    }
}