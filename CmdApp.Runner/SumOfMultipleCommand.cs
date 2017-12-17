using System.Numerics;
using CmdApp.Domain;
using McMaster.Extensions.CommandLineUtils;

namespace CmdApp.Runner {
    [Command(Description = "Sum of all natural numbers that are a multiple of 3 or 5 below a limit")]
    public class SumOfMultipleCommand {
        public const string Name = "sumOfMultiple";

        [Option(CommandOptionType.SingleValue, Description = "Required limit", LongName = "limit", ShortName = "l")]
        public string LimiteAsString {
            get => Limit.ToString();
            set => Limit = BigInteger.Parse(value);
        }

        internal BigInteger Limit { get; set; }

        public int OnExecute(IConsole console) {
            var service = Container.GetService<ISumOfMultiple>();
            var value = service.Execute(Limit);

            console.WriteLine(value.ToString("#,##0"));
            return 1;
        }
    }
}