/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Factorial recursion
 * Activity 3 Part 2
 * References:
 */

using System.Numerics;

namespace FactorialRecursion.Services.BusinessLogicLayer
{
    internal class FactorialLogic
    {
        /// <summary>
        /// Solve the factorial problem using iteration
        /// </summary>
        /// <param name="factorial"></param>
        /// <returns></returns>
        internal BigInteger SolveIterativeFactorial(int factorial)
        {
            // Declare and Initialize
            BigInteger result = 1;

            // For loop to solve the factorial
            for (int i = factorial; i >= 1; i--)
            {
                // Multiply the result by i
                result *= i;
            }

            // Return the result
            return result;
        }

        /// <summary>
        /// Solve the factorial problem using recursion
        /// </summary>
        /// <param name="factorial"></param>
        /// <returns></returns>
        internal BigInteger SolveRecursiveFactorial(int factorial)
        {
            // Base case: factorial is 0 or 1
            if (factorial == 0 || factorial == 1)
            {
                return 1;
            }

            // Perform the recursion
            return factorial * SolveRecursiveFactorial(factorial - 1);
        }
    }
}
