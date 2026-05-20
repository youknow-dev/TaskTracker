namespace TaskTracker.Service
{
    internal class ArgumentParser : IParser
    {
        public void Parse(string[] args, List<Model.Task> tasks)
        {
            if (args.Length == 0)
            {
               Console.WriteLine("[display help information]");
            }

            int index = 0;

            while (index < args.Length)
            {
                switch (args[index++].ToLower())
                {
                    case "add":
                        var task = GetNewTask(tasks);
                        task.Description = args[index]; 
                        tasks.Add(task);
                        Console.WriteLine($"Task added successfully (ID: {task.ID})");
                        return;

                    case "update":
                        if (int.TryParse(args[index], out int i))
                        {
                            task = tasks.FirstOrDefault(x => x.ID == i); 
                            
                            if (task == null)
                            {
                                Console.WriteLine($"Task {i} is not a known task");
                            }
                            else
                            {
                                task.Description = args[++index];
                                task.UpdatedAt = DateTime.Now;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Expected ID number: ({args[index]})");
                        }
                        return;

                    case "delete":
                        if (int.TryParse(args[index], out i))
                        {
                            task = tasks.FirstOrDefault(x => x.ID == i); 
                            
                            if (task == null)
                            {
                                Console.WriteLine($"Task {i} is not a known task");
                            }
                            else
                            {
                                tasks.Remove(task);
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Expected ID number: ({args[index]})");
                        }
                        return;

                    case "mark-in-progress":
                        if (int.TryParse(args[index], out i))
                        {
                            task = tasks.FirstOrDefault(x => x.ID == i); 
                            
                            if (task == null)
                            {
                                Console.WriteLine($"Task {i} is not a known task");
                            }
                            else
                            {
                                task.Status = Model.TaskStatus.InProgress;
                                task.UpdatedAt = DateTime.Now;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Expected ID number: ({args[index]})");
                        }
                        return;

                    case "mark-done":
                    if (int.TryParse(args[index], out i))
                        {
                            task = tasks.FirstOrDefault(x => x.ID == i); 
                            
                            if (task == null)
                            {
                                Console.WriteLine($"Task {i} is not a known task");
                            }
                            else
                            {
                                task.Status = Model.TaskStatus.Done;
                                task.UpdatedAt = DateTime.Now;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Expected ID number: ({args[index]})");
                        }
                        return;

                    case "list":
                        var tasksToList = tasks;
                        if (++index < args.Length)
                        {
                            Model.TaskStatus? status = args[index].ToLower() switch
                            {
                                "done" => Model.TaskStatus.Done,
                                "todo" => Model.TaskStatus.ToDo,
                                "in-progress" => Model.TaskStatus.InProgress,
                                _ => null
                            };

                            if (status == null)
                            {
                                Console.WriteLine($"Unexpected search criterion: {args[index]}");
                                return;
                            }
                            else
                            {
                                tasksToList = [.. tasks.Where(x => x.Status == status)];
                            }
                        }

                        foreach (var item in tasksToList)
                        {
                            Console.WriteLine($"  Task {item.ID}: {item.Description}");
                            Console.WriteLine($"          Status: {item.Status}");
                            Console.WriteLine($"   Creation Date: {item.CreatedAt}");
                            Console.WriteLine($"Last Update Date: {item.UpdatedAt}");
                            Console.WriteLine("---");
                        }
                        return;

                    default:
                        Console.WriteLine($"[unknown command ({args[index]}). Display help information]");
                        return;
                }
            }
        }

        /// <summary>
        /// Gets a new UUID for the next task
        /// </summary>
        /// <param name="tasks">collection of current tasks</param>
        /// <returns>the next id</returns>
        private static int GetNextId(List<Model.Task> tasks)
        {
            return tasks.LastOrDefault()?.ID + 1 ?? 1;
        }

        /// <summary>
        /// Creates a new task
        /// </summary>
        /// <param name="tasks">collection of current tasks</param>
        /// <returns>the new task</returns>
        private static Model.Task GetNewTask(List<Model.Task> tasks)
        {
            var now = DateTime.Now;

            return new Model.Task()
            {
                ID = GetNextId(tasks),
                Status = Model.TaskStatus.ToDo,
                CreatedAt = now,
                UpdatedAt = now
            };
        }
    }
}