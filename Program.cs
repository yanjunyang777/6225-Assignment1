using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1_Summer2021
{
    class Program
    {
        static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");
            string moves = Console.ReadLine();
            bool pos = JudgeCircle(moves);
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine();
            bool flag = CheckIfPangram(s);
            if (flag)
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 };
            int gp = NumIdenticalPairs(arr);
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp);


            //Question 4:
            int[] arr1 = { 1, 7, 3, 6, 5, 6 };
            Console.WriteLine("Q4:");
            int pivot = PivotIndex(arr1);
            if (pivot > 0)
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);


            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();

        }

        /* 
<summary>
/// Input: moves = "UD"
/// Output: true
/// Explanation: The robot moves up once, and then down once. All moves have the same ///magnitude, so it ended up at the origin where it started. Therefore, we return true.
</summary>
<retunrs>true/False</returns>
*/
        private static bool JudgeCircle(string moves)
        {
            // Identify variables
            int r = 0;
            int l = 0;
            int u = 0;
            int d = 0;
            try
            {
                // Count steps the robot takes.
                foreach (int step in moves)
                {
                    if (step == 'R')
                        r++;
                    else if (step == 'L')
                        l++;
                    else if (step == 'U')
                        u++;
                    else if (step == 'D')
                        d++;
                }
                // If the steps the robot take to the right equals the step it takes to the left, and steps up equal step down,
                // it returns to the origin.
                if (r == l && u == d) return true;
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* 
 <summary>
A pangram is a sentence where every letter of the English alphabet appears at least once.
Given a string sentence containing only lowercase English letters, return true if sentence is a pangram, or false otherwise.
Example 1:
Input: sentence = "thequickbrownfoxjumpsoverthelazydog"
Output: true
Explanation: sentence contains at least one of every letter of the English alphabet.
</summary>
</returns> true/false </returns>
Note: Use of String function (Contains) and hasmap is not allowed, think of other ways how you could the numbers be represented
        */


        private static bool CheckIfPangram(string s)
        {
            try
            {
                // Get the number of characters in a sentence.
                int sentence = s.Length;

                // Suppose each "1" represents one letter in the alphabet, there are 26 of them.

                int[] letters = new int[26]
                {
                    1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1
                };

                // Go through all letters of the input sentence.
                // If a letter appears, the number represents it changes to 0.
                // 97 is the ASCII number for letter "a" .
                for (int i = 0; i < sentence; i++)
                {
                    int check = s[i] - 97;
                    if (letters[check] == 1)
                    {
                        letters[check] = 0;
                    }
                }
                // Take the sum of all the "1"s that represent 26 letters.
                // If all letter appear, the sum should be 0, otherwise the sum will be greater than 0.
                int total = letters.Sum();
                if (total > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        /*

 <summary> 
 Given an array of integers nums 
 A pair (i,j) is called good if nums[i] == nums[j] and i < j.
 Return the number of good pairs.
 Example:
 Input: nums = [1,2,3,1,1,3]
 Output: 4
 Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
   return type  : int
 </summary>
 <returns>int </returns>
     */

        private static int NumIdenticalPairs(int[] arr)
        {
            try
            {
                // Set number of good pairs.
                int good = 0;

                // Check each number in the array. Compare it with other numbers.
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = 0; j < arr.Length; j++)
                    {
                        // If meets the requirement, number of good pair increase by one.
                        if (arr[i] == arr[j] && i < j)
                        {
                            good++;
                        }
                    }
                }
                return good;

            }
            catch (Exception)
            {

                throw;
            }
        }






        /*

          <summary>
   Given an array of integers nums, calculate the pivot index of this array.The pivot index is the index where the sum of all the numbers strictly to the left of  the index is equal to the sum of all the numbers strictly to the index's right.
  If the index is on the left edge of the array, then the left sum is 0 because there are no elements to the left. This also applies to the right edge of the array.
  Return the leftmost pivot index. If no such index exists, return -1.
  Example 1:
  Input: nums = [1,7,3,6,5,6]
         Output : 3


      Explanation:
  The pivot index is 3.
  Left sum = nums[0] + nums[1] + nums[2] = 1 + 7 + 3 = 11
  Right sum = nums[4] + nums[5] = 5 + 6 = 11
          /// </summary>
          /// <param name="nums"></param>
          /// <returns>Number the index in the array</returns>
      */
        private static int PivotIndex(int[] nums)
        {
            try
            {
                // Identify the total of numbers in nums.
                // Identiry the sum of left part to the pivot index in the array.              
                // Count the length of nums.
                int total = 0;
                int left = 0;
                int count = nums.Length;

                // Add up all numbers in the array.               
                foreach (int numbers in nums)
                {
                    total = total + numbers;
                }

                // Supposing the pivot index is the first number in the array, the sum to its left is 0, and sum to its right = sum of nums - nums[0]
                // Check if left sum equals right sum.
                // And use the second number as pivot index and check its left sum and right sum, then third number, etc.  
                for (int i = 0; i < count; i++)
                {
                    if (left == total - nums[i])
                    {
                        return i;
                    }

                    left = left + nums[i];
                    total = total - nums[i];
                }

                // If no such index exists, return -1.
                if (count == 0)
                {
                    return -1;
                }
                return 0;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /*
            /// <summary>
    /// You are given two strings word1 and word2. Merge the strings by adding letters /// in alternating order, starting with word1. If a string is longer than the other,
    /// append the additional letters onto the end of the merged string.
    /// Example 1
    /// Input: word1 = "abc", word2 = "pqr"
    /// Output: "apbqcr"
    /// Explanation: The merged string will be merged as so:
    /// word1:  a   b   c
    /// word2:    p   q   r
    /// merged: a p b q c r
    /// </summary>
           /// <param name="word1"></param>
    ///<param name="word2"></param>
           /// <returns>return the merged string </returns>

    */

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                // Identiry vairables.
                string input1 = "";
                string input2 = "";
                int lenword1 = word1.Length;
                int lenword2 = word2.Length;
                string output = "";

                // Compare the length of word1 and word2.
                // And consider both situations.
                // When word1 is longer:
                if (lenword1 > lenword2)
                {
                    for (int i = 0; i < lenword1; i++)
                    {
                        if (i < lenword1)
                        {
                            input1 = word1[i].ToString();
                        }
                        else
                        {
                            input1 = "";
                        }
                    }
                    // When word2 is longer:
                    if (lenword1 < lenword2)
                    {
                        for (int j = 0; j < lenword2; j++)
                        {
                            if (j < lenword2)
                            {
                                input2 = word2[j].ToString();
                            }
                            else
                            {
                                input2 = "";
                            }
                        }
                    }

                }
                return output = input1 + input2;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /*
        <summary>
    /// A sentence sentence is given, composed of words separated by spaces. Each word consists of lowercase and uppercase letters only.
    We would like to convert the sentence to "Goat Latin" (a made-up language similar to Pig Latin.)
    The rules of Goat Latin are as follows:
    1)	If a word begins with a vowel (a, e, i, o, or u), append "ma" to the end of the word.
    For example, the word 'apple' becomes 'applema'.

    2)	If a word begins with a consonant (i.e. not a vowel), remove the first letter and append it to the end, then add "ma".
    For example, the word "goat" becomes "oatgma".

    3)	Add one letter 'a' to the end of each word per its word index in the sentence, starting with 1.
    For example, the first word gets "a" added to the end, the second word gets "aa" added to the end and so on.
    Hint : think of a string function to divide the sentence on white spaces
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns> string</returns>
       */
        private static string ToGoatLatin(string sentence)
        {
            try
            {
                // Identiry variables.
                string[] goat = sentence.Split("");
                // string vowel = "AaEeIiOoUu";
                int length = goat.Length;

                //for (int i; i < length; i++)
                {
                    // If the word is vowel, keep it as it is and add "ma" at the end.
                    //if ()
                    {

                    }
                }

                return "null";

            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}





