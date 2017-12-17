using CmdApp.Domain;
using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [Command(Description = "Find the uppercase words in a string, and order all characters in these words alphabetically")]
    public class SequenceAnalysisCommand {
        public const string Name = "sequenceAnalysis";

        [Option(CommandOptionType.SingleValue, Description = "Required text")]
        public string Input { get; set; }

        public int OnExecute(IConsole console) {
            var service = Container.GetService<ISequenceAnalysis>();
            var output = service.Execute(Input);

            console.WriteLine(output);
            return 1;
        }
    }
}