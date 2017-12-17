using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CmdApp.Domain {
    internal sealed class SumOfMultiple : ISumOfMultiple {
        public BigInteger Execute(BigInteger limit) {
            if (limit < BigInteger.Zero) {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            if (limit <= 3) {
                return BigInteger.Zero;
            }
            if (limit <= 5) {
                return new BigInteger(3);
            }

            var value = limit - 1;
            var sumOfDivisibleBy3 = SumOfDivisibleBy(value, 3);
            var sumOfDivisibleBy5 = SumOfDivisibleBy(value, 5);
            var sumOfDivisibleBy15 = SumOfDivisibleBy(value, 15);

            return sumOfDivisibleBy3 + sumOfDivisibleBy5 - sumOfDivisibleBy15;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static BigInteger SumOfDivisibleBy(BigInteger value, byte divider) {
            while (value % divider > 0) {
                value--;
            }

            var totalCount = value / divider;
            var pairCount = totalCount / 2;

            var pairSum = value + divider;

            return pairCount * pairSum + (totalCount % 2 == 1 ? pairSum / 2 : 0);
        }
    }
}