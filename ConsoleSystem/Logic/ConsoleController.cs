using ConsoleSystem.Commands;

using static ConsoleSystem.ConsoleLogger;
using static ConsoleSystem.Logic.ArgumentSorter;

namespace ConsoleSystem
{
    public class ConsoleController
    {
        CommandList commandList;

        public ConsoleController()
        {
            Log("Initializing console...", ConsoleColor.Magenta);
            commandList = new CommandList();
            Log("Console has been initialized", ConsoleColor.Blue);
        }

        public void Start()
        {
            Log("Console started. Use 'help' for more information", ConsoleColor.Green);

            while (true)
                HandleInput(GetInput());
        }

        public void HandleInput(string? cmd)
        {
            List<string> args = SortCommand(cmd);
            if (args.Count < 1) return;

            if(!commandList.TryGettingConsoleCommand(args[0], out ConsoleCommand? command))
            {
                Log($"Command '{args[0]}' does not exist!", ConsoleColor.Red);
                return;
            }

            command?.Run(args);
        }
    }
}