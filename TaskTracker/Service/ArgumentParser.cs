namespace TaskTracker.Service
{
    internal class ArgumentParser : IParser
    {
        public void Parse(string[] args)
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
                        return;
                    case "update":
                        return;
                    case "delete":
                        return;
                    case "mark-in-progress":
                        return;
                    case "mark-done":
                        return;
                    case "list":
                        return;
                    default:
                        Console.WriteLine($"[unknown command ({args[index]}). Display help information]");
                        return;
                }
            }

            throw new NotImplementedException();
        }
    }
}