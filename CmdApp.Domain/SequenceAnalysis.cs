using System;
using System.Linq;

namespace CmdApp.Domain {
    internal sealed class SequenceAnalysis : ISequenceAnalysis {
        public string Execute(string input) {
            if (input is null) {
                throw new ArgumentNullException(nameof(input));
            }

            if (string.IsNullOrWhiteSpace(input)) {
                return string.Empty;
            }

            var ordered = input.Where(x => x >= 'A' && x <= 'Z').OrderBy(x => x);
            return string.Concat(ordered);
        }
    }
}
