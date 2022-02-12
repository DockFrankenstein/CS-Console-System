namespace ConsoleSystem.Commands
{
    public abstract class ConsoleCommand
    {
        public virtual bool Active { get; } = true;
        public abstract string CommandName { get; }
        public abstract string Description { get; }
        public virtual string DetailedDescription { get; }
        public virtual string[] Aliases { get; }

        public abstract void Run(List<string> args);

        public bool CheckForArgumentCount(List<string> args, int min, int max)
        {
            if (args.Count - 1 < min)
            {
                LogError("User input - not enough arguments!");
                return false;
            }
            if (args.Count - 1 > max)
            {
                LogError("User input - index is out of range!");
                return false;
            }
            return true;
        }

        public bool CheckForArgumentCount(List<string> args, int amount) =>
            CheckForArgumentCount(args, amount, amount);

        public bool CheckForArgumentCountMin(List<string> args, int min)
        {
            if (args.Count - 1 < min)
            {
                LogError("User input - not enough arguments!");
                return false;
            }
            return true;
        }

        public void Log(string text) =>
            ConsoleLogger.Log(text);

        public void Log(string text, ConsoleColor color) =>
            ConsoleLogger.Log(text, color);

        public void LogError(string text) =>
            ConsoleLogger.Log(text, ConsoleColor.Red);

        public void NoOptionException(string option) =>
            ConsoleLogger.Log($"Option <b>{option}</b> does not exist!", ConsoleColor.Red);

        public void ParseException(string text, string type) =>
            ConsoleLogger.Log($"Couldn't parse <b>{text}</b> to {type}!", ConsoleColor.Red);
    }
}