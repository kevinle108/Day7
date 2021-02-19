using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(Gcd(56, 64)); // Expected 8
            //Console.WriteLine(Gcd(56, 56)); // Expected 56
            //Console.WriteLine(Lcm(12, 4)); // Expected 12
            //Console.WriteLine(Lcm(12, 12)); // Expected 12
            //Console.WriteLine(GcdList(new List<int> { 12 })); // Expected 12
            //Console.WriteLine(GcdList(new List<int> { 12, 4 })); // Expected 4
            //Console.WriteLine(GcdList(new List<int> { 12, 4, 15 })); // Expected 1
            //Console.WriteLine(GcdList(new List<int> { 840, 630, 455 })); // Expected 35
            //Console.WriteLine(GcdList(new List<int> { 78, 96, 1564, 130, 54, 22 })); // Expected 2
            //Console.WriteLine(LcmList(new List<int> { 12 })); // Expected 12
            //Console.WriteLine(LcmList(new List<int> { 12, 24 })); // Expected 24
            //Console.WriteLine(LcmList(new List<int> { 840, 630, 455 })); // Expected 32760
            //Console.WriteLine(Min(new List<int> { 1 })); // Expected 1
            //Console.WriteLine(Min(new List<int> { 1, 432, -2, 4 })); // Expected -2
            //Console.WriteLine(Max(new List<int> { 2, 2 })); // Expected 2
            //Console.WriteLine(Max(new List<int> { 1, 432, -2, 4 })); // Expected 432
            //myList.ForEach(ele => Console.WriteLine(ele));

            List<int> myList = UserIntegerList();
            Console.WriteLine();
            Console.WriteLine($"GCD = {GcdList(myList)}");
            Console.WriteLine($"LCM = {LcmList(myList)}");
            Console.WriteLine($"MIN = {Min(myList)}");
            Console.WriteLine($"MAX = {Max(myList)}");

            //// FUNCTIONS ////

            // returns the gcd of 2 integers
            static int Gcd(int num1, int num2)
            {
                int num3 = num1 % num2;
                while (num3 != 0)
                {
                    num1 = num2;
                    num2 = num3;
                    num3 = num1 % num2;
                }
                return num2;
            }

            // returns the lcm of 2 integers
            static int Lcm(int num1, int num2)
            {
                return num1 * num2 / Gcd(num1, num2); 
            }

            // returns the gcd of a list of integers
            static int GcdList(List<int> nums)
            {
                int gcd = nums[0];
                if (nums.Count >= 2)
                {
                    int index = 1;
                    while (index <= nums.Count-1)
                    {
                        gcd = Gcd(gcd, nums[index]);
                        index++;
                    }
                }
                return gcd;
            }

            // returns the lcm of a list of integers
            static int LcmList(List<int> nums)
            {
                int lcm = nums[0];
                if (nums.Count >= 2)
                {
                    int index = 1;
                    while (index <= nums.Count - 1)
                    {
                        lcm = Lcm(lcm, nums[index]);
                        index++;
                    }
                }
                return lcm;
            }

            //return the minimum of a list of integers
            static int Min(List<int> nums)
            {
                //if using Linq
                //return nums.Min();
                
                int min = nums[0];
                nums.ForEach(ele =>
                {
                    if (ele < min) min = ele;
                });
                return min;
            }

            //return the maximum of a list of integers
            static int Max(List<int> nums)
            {
                //if using Linq
                //return nums.Max();

                int max = nums[0];
                nums.ForEach(ele =>
                {
                    if (ele > max) max = ele;
                });
                return max;
            }

            // prompt the user for an integer
            static void PromptForNum(string msg, out int num)
            {
                while (true)
                {
                    Console.Write(msg);
                    if (int.TryParse(Console.ReadLine(), out num) && num >= 0) return;
                    Console.WriteLine("Invalid input!");
                }
            }

            // get a list of integers from the user
            static List<int> UserIntegerList()
            {
                int num;
                List<int> numsList = new List<int>();
                PromptForNum("Enter the first number: ", out num);
                if (num == 0)
                {
                    Console.WriteLine("Nothing to do!");
                    PromptForNum("Enter the first number: ", out num);
                }
                else
                {
                    numsList.Add(num);
                    while (true)
                    {
                        PromptForNum("Enter the next number (0 if no more): ", out num);
                        if (num == 0) break;
                        numsList.Add(num);
                    }
                }
                return numsList;
            }
        }
    }
}
