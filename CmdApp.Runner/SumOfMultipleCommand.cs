using System.Numerics;
using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [Command(Description = "Sum of all natural numbers that are a multiple of 3 or 5 below a limit")]
    public class SumOfMultipleCommand {
        [Option(CommandOptionType.SingleValue, LongName = "limit", ShortName = "l")]
        public string Limit { get; set; }

        public int OnExecute(IConsole console) {
            var bigLimit = BigInteger.Parse(Limit);
            var value = ExecuteService(in bigLimit);

            console.WriteLine(value.ToString("#,##0"));

            return 1;
        }

        protected virtual BigInteger ExecuteService(in BigInteger limit) {
            var service = new SumOfMultiple.SumOfMultiple(limit);

            return service.Execute();
        }
    }
}