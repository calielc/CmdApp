using System.Numerics;
using CmdApp.SumOfMultiple;
using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [Command(Description = "Sum of all natural numbers that are a multiple of 3 or 5 below a limit")]
    public class SumOfMultipleCommand {
        public const string Name = "sumOfMultiple";

        [Option(CommandOptionType.SingleValue, LongName = "limit", ShortName = "l")]
        public string Limit { get; set; }

        public int OnExecute(IConsole console) {
            var bigLimit = BigInteger.Parse(Limit);

            var service = NewService();
            var value = service.Execute(bigLimit);

            console.WriteLine(value.ToString("#,##0"));

            return 1;
        }

        protected virtual ISumOfMultiple NewService() {
            return new SumOfMultiple.SumOfMultiple();
        }
    }
}