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
                switch (args[index].ToLower())
                {
                    case "add":
                        break;
                    case "update":
                        break;
                    case "delete":
                        break;
                    case "mark-in-progress":
                        break;
                    case "mark-done":
                        break;
                    case "list":
                        break;
                    default:
                        Console.WriteLine($"[unknown command ({args[index]}). Display help information]");
                        break;
                }
                index++;
            }

            throw new NotImplementedException();
        }
    }
}