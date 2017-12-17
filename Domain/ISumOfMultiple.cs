using System.Numerics;

namespace Domain {
    public interface ISumOfMultiple {
        /// <summary>
        ///  Sum of all natural numbers that are a multiple of 3 or 5 below a limit
        /// </summary>
        /// <param name="limit">input limit</param>
        /// <remarks>
        /// You can see the mathematics about it in https://math.stackexchange.com/questions/9259/find-the-sum-of-all-the-multiples-of-3-or-5-below-1000
        /// </remarks>
        /// <returns>sum of all numbers</returns>
        BigInteger Execute(BigInteger limit);
    }
}