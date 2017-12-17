using CmdApp.SequenceAnalysis;
using CmdApp.SumOfMultiple;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace CmdApp.Runner {
    [HelpOption]
    [Subcommand(SumOfMultipleCommand.Name, typeof(SumOfMultipleCommand))]
    [Subcommand(SequenceAnalysisCommand.Name, typeof(SequenceAnalysisCommand))]
    public class Program {
        static void Main(string[] args) {
            //var serviceProvider = new ServiceCollection()
            //    .AddSingleton<ISumOfMultiple, SumOfMultiple.SumOfMultiple>()
            //    .AddSingleton<ISequenceAnalysis, SequenceAnalysis.SequenceAnalysis>();

            CommandLineApplication.Execute<Program>(args);
        }
    }
}
