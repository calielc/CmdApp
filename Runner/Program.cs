using McMaster.Extensions.CommandLineUtils;

namespace Runner {
    [HelpOption]
    [Subcommand(SumOfMultipleCommand.Name, typeof(SumOfMultipleCommand))]
    [Subcommand(SequenceAnalysisCommand.Name, typeof(SequenceAnalysisCommand))]
    public class Program {
        static void Main(string[] args) => CommandLineApplication.Execute<Program>(args);

        public int OnExecute(IConsole console) {
            console.WriteLine("There are 2 avaiable commands:");
            console.WriteLine("");
            console.WriteLine($"{SequenceAnalysisCommand.Name} --input \"This IS a STRING\"");
            console.WriteLine($"{SumOfMultipleCommand.Name} --limit 1000");

            return 1;
        }
    }
}
