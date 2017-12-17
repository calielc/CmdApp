using CmdApp.SequenceAnalysis;
using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [Command(Description = "Find the uppercase words in a string, and order all characters in these words alphabetically")]
    public class SequenceAnalysisCommand {
        public const string Name = "SequenceAnalysis";

        [Option(CommandOptionType.SingleValue, LongName = "input", ShortName = "i")]
        public string Input { get; set; }

        public int OnExecute(IConsole console) {
            var service = NewService();

            var output = service.Execute(Input);

            console.WriteLine(output);

            return 1;
        }

        protected virtual ISequenceAnalysis NewService() => new SequenceAnalysis.SequenceAnalysis();
    }
}