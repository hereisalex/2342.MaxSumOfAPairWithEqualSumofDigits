using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        int[] nums = [18, 43, 36, 13, 7];
        int[] nums2 = [10, 12, 19, 14];
        int[] hmm = [12, 21, 30];
        var output54 = solution.MaximumSum(nums);
        var outputNegative1 = solution.MaximumSum(nums2);
        var output51 = solution.MaximumSum(hmm);
        Console.WriteLine(output54 + " should be 54 and this should be -1: " + outputNegative1);
    }
    /// <summary>
    /// Finds the maximum sum of two numbers in the array such that the sum of their digits is the same.
    /// </summary>
    /// <param name="nums">An array of integers.</param>
    /// <returns>The maximum sum of two numbers with the same digit sum, or -1 if no such pair exists.</returns>
    public int MaximumSum(int[] nums)
    {
        // initialize default answer to -1 (indicating no valid pairs found [yet])
        int maxSum = -1;

        // array to store the maximum number for each possible digit sum (0-81, the max possible digit sum for any integer)
        int[] digitSumMax = new int[82];

        // iterate through each number in the input array
        foreach (int num in nums)
        {
            int digitSum = 0; // initialize digit sum for the current number
            int currentNum = num; // copy of the current number for manipulation

            // calculate the sum of the digits of the current number
            while (currentNum > 0)
            {
                digitSum += currentNum % 10; // add the last digit to digitSum
                currentNum /= 10; // remove the last digit from currentNum
            }

            // check if there is already a number with the same digit sum
            if (digitSumMax[digitSum] > 0)
            {
                // update maxSum if the sum of the current number and the stored number is greater
                maxSum = Math.Max(maxSum, num + digitSumMax[digitSum]);
            }

            // update the stored number for the current digit sum if the current number is greater
            digitSumMax[digitSum] = Math.Max(digitSumMax[digitSum], num);
        }

        // return the maximum sum found, or -1 if no valid pairs were found
        return maxSum;
    }
}
