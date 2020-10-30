using System;
using System.Collections.Generic;

namespace Find_all_subsets_II_when_duplicate_is_present
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new int[] {2, 2, 1 };
            var result = SubsetsWithDup(nums);
            foreach (var res in result)
                Console.WriteLine(string.Join(" ", res));
        }


        // https://leetcode.com/problems/subsets-ii/discuss/30242/Share-my-2ms-java-iteration-solution-(very-simple-and-short)
        // Solution based on the above link

        static IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Array.Sort(nums);
            IList<IList<int>> output = new List<IList<int>>();
            output.Add(new List<int>());
            int count = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                if (i == 0 || nums[i] != nums[i - 1]) count = 0;
                int size = output.Count;
                for (int j = count; j < size; j++)
                {
                    List<int> inner = new List<int>();
                    inner.AddRange(output[j]);
                    inner.Add(nums[i]);
                    output.Add(inner);
                }
                count = size;
            }
            return output;
        }
    }
}
