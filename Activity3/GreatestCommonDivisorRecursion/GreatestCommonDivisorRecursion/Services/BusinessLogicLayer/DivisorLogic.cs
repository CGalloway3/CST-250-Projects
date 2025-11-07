/*
 * Chad Galloway
 * CST - 250 Programming in C# II
 * 11/09/2020
 * Greatest Common Divisor Recursion
 * Activity 3 Part 3
 * References:
 */

namespace GreatestCommonDivisorRecursion.Services.BusinessLogicLayer
{
    internal class DivisorLogic
    {
        /// <summary>
        /// Solve a single pair of numbers in a complex GCD problem using recursion
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        internal int singlePairRecursiveSolution(int num1, int num2)
        {
            // Declare and Initialize
            int remainder = 0;

            // Base Case: num2 = 0
            if (num1 == 0 || num2 == 0)
            {
                // Return the greatest common divisor
                return Math.Max(num1, num2);
            }
            else
            {
                // Get the remainder of dividing num1 and num2
                remainder = num1 % num2;
                // Print an update to the user
                Console.WriteLine($"Not yet. The remainder of {num1} and {num2} is {remainder}.");
                // Call the recursive function of the second number and the remainder
                return singlePairRecursiveSolution(num2, remainder);
            }
        }

        /// <summary>
        /// Solve a single pair of numbers in a complex GCD problem using iteration
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        internal int singlePairIterativeSolution(int num1, int num2)
        {
            // Declare and Initialize
            int numerator = num1;  // Probably not needed but it helped my brain see the math clearly in the loop below
            int denominator = num2;  // Probably not needed but it helped my brain see the math clearly in the loop below

            // Catch Zero
            if (num1 == 0 || num2 == 0)
            {
                // Return the greatest common divisor
                return Math.Max(num1, num2);
            }
            else
            {
                do
                {
                    int temp = denominator; // store the current denominator temporarily
                    denominator = numerator % denominator; // calculate a new denominator for the next iteration
                    numerator = temp; // move the previous (temp) denominator up to the numerator
                    Console.WriteLine($"Not yet. The remainder of {num1} and {num2} is {denominator}.");
                } while (denominator != 0);
            }

            // The remainder of mod (%) was 0 so we have hit the greatest common divisor(denominator)
            // Return the numerator which is merely the temp storage of the previous (greatest common) divisor(denominator)
            return numerator;
        }

        /// <summary>
        /// Solve a single pair of numbers in a complex GCD problem using count from one
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        internal int singlePairCountingSolution(int num1, int num2)
        {
            // Declare and Initialize
            List<int> num1List = new List<int>();
            List<int> num2List = new List<int>();

            // Catch Zero
            if (num1 == 0 || num2 == 0)
            {
                // Return the greatest common divisor
                return Math.Max(num1, num2);
            }

            // Create list one
            for (int i = 1; i <= num1; i++) 
            { 
                if (num1 % i == 0)
                {
                    num1List.Add(i);
                }
            }
            Console.WriteLine($"The first list has {num1List.Count} entries.");

            // Create list two
            for (int i = 1; i <= num2; i++)
            {
                if (num2 % i == 0)
                {
                    num2List.Add(i);
                }
            }
            Console.WriteLine($"The second list has {num2List.Count} entries.");

            // Compare the lists with LINQ thanks ChatGPT
            return num1List.Intersect<int>(num2List).DefaultIfEmpty().Max();
        }

        /// <summary>
        /// Using iteration to probe the depth of the array of numbers while using recursion to solve the GCD problem
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        internal int SolveRecursiveGCD(int[] numbers)
        {
            // Declare and Initialize
            int divisor = Math.Abs(numbers[0]);

            // Iterate through all numbers to get the GCD except for the first number, it was used as the first divisor.
            for (int i = 1; i < numbers.Length; i++)
            {
                divisor = singlePairRecursiveSolution(Math.Abs(numbers[i]), divisor);
            }

            // Return the final result
            return divisor;
        }

        /// <summary>
        /// Using iteration to probe the depth of the array of numbers while using iteration to solve the GCD problem
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        internal int SolveIterativeGCD(int[] numbers)
        {
            // Declare and Initialize
            int divisor = Math.Abs(numbers[0]);

            // Iterate through all numbers to get the GCD except for the first number, it was used as the first divisor.
            for (int i = 1; i < numbers.Length; i++)
            {
                divisor = singlePairIterativeSolution(Math.Abs(numbers[i]), divisor);
            }

            // Return the final result
            return divisor;
        }

        /// <summary>
        /// Using iteration to probe depth and counting to solve the pairs
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        internal int SolveCountingGCD(int[] numbers)
        {
            // Declare and Initialize
            int divisor = Math.Abs(numbers[0]);

            // Iterate through all numbers to get the GCD except for the first number, it was used as the first divisor.
            for (int i = 1; i < numbers.Length; i++)
            {
                divisor = singlePairCountingSolution(Math.Abs(numbers[i]), divisor);
            }

            // Return the final result
            return divisor;        
        }

        /// <summary>
        /// Using recursion to probe the depth of each array of numbers while using recursion to solve the GCD for each pair
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal int arrayRecursionSolution(int[] numbers, int index)
        {
            // Base case: The last element was reached, stop digging deeper into the array for more elements
            if (index == numbers.Length - 1)
            {
                Console.WriteLine($"{numbers[index]} is the last number in the array, collapsing the solution back down.");
                return numbers[index]; // Return the last array element (number) so the recursive calls can start collapsing back down to the solution.
            }

            // Returns a call to the next number pair in the array
            Console.WriteLine($"Still more numbers. Calling the next number pair {numbers[index]} and {numbers[index + 1]}.");
            return singlePairRecursiveSolution(Math.Abs(numbers[index]), arrayRecursionSolution(numbers, index + 1));
        }

        /// <summary>
        /// Use recursion to probe the depth of the array of numbers while using iteration to solve the GCD of each pair
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal int arrayIterationSolution(int[] numbers, int index)
        {
            // Base case: The last element was reached, stop digging deeper into the array for more elements
            if (index == numbers.Length - 1)
            {
                Console.WriteLine($"{numbers[index]} is the last number in the array, collapsing the solution back down.");
                return numbers[index]; // Return the last array element (number) so the recursive calls can start collapsing back down to the solution.
            }

            // Returns a call to the next number pair in the array
            Console.WriteLine($"Still more numbers. Calling the next number pair {numbers[index]} and {numbers[index + 1]}.");
            return singlePairIterativeSolution(Math.Abs(numbers[index]), arrayIterationSolution(numbers, index + 1));
        }

        /// <summary>
        /// Use recursion to probe the depth and counting to solve the GCD of each pair
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        internal int arrayCountingSolution(int[] numbers, int index)
        {
            // Base case: The last element was reached, stop digging deeper into the array for more elements
            if (index == numbers.Length - 1)
            {
                Console.WriteLine($"{numbers[index]} is the last number in the array, collapsing the solution back down.");
                return numbers[index]; // Return the last array element (number) so the recursive calls can start collapsing back down to the solution.
            }

            // Returns a call to the next number pair in the array
            Console.WriteLine($"Still more numbers. Calling the next number pair {numbers[index]} and {numbers[index + 1]}.");
            return singlePairCountingSolution(Math.Abs(numbers[index]), arrayCountingSolution(numbers, index + 1));
        }
    }
}
