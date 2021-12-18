namespace ConsoleSystem.Commands.Builtin
{
    public class EchoCommand : ConsoleCommand
    {
        public override string CommandName { get => "echo"; }
        public override string Description { get => "prints out a log"; }

        public override void Run(List<string> args)
        {
            if (!CheckForArgumentCount(args, 1)) return;
            Log(args[1]);
        }
    }
}