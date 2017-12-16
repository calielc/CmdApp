using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace CmdApp.SumOfMultiple {
    public class SumOfMultiple {
        private readonly BigInteger _limit;

        public SumOfMultiple(BigInteger limit) {
            if (limit < BigInteger.Zero) {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }
            _limit = limit;
        }

        /// <summary>
        ///  Sum of all natural numbers that are a multiple of 3 or 5 below a limit
        /// </summary>
        /// <see cref="https://math.stackexchange.com/questions/9259/find-the-sum-of-all-the-multiples-of-3-or-5-below-1000"/>
        /// <returns>sum of all number</returns>
        public BigInteger Execute() {
            if (_limit <= 3) {
                return BigInteger.Zero;
            }
            if (_limit <= 5) {
                return new BigInteger(3);
            }
 
            var value = _limit - 1;
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