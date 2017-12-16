using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [HelpOption]
    [Subcommand("sumOfMultiple", typeof(SumOfMultipleCommand))]
    public class Program {
        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);
    }
}
