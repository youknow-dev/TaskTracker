namespace TaskTracker.Service
{
    internal interface IParser
    {
        /// <summary>
        /// Parse command-line arguments
        /// </summary>
        /// <param name="args">the arguments</param>
        /// <param name="tasks">the collection of tasks to operate on</param>
        void Parse(string[] args, List<Model.Task> tasks);
    }
}