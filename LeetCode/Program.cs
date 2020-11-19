using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Solution
{
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        var max = candies.Max();
        var result = candies.Select(candy => candy + extraCandies >= max).ToList();

        return result;
    }

    public int[] Shuffle(int[] nums, int n)
    {
        var vector = new List<int>();
        for (var i = 0; i < n; i++)
        {
            vector.Add(nums[i]);
            vector.Add(nums[i + n]);
        }

        return vector.ToArray();
    }

    public string DefangIPaddr(string address)
    {
        return address.Replace(".", "[.]");
    }

    public int NumIdenticalPairs(int[] nums)
    {
        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] == nums[j])
                    result++;
            }
        }

        return result;
    }

    public int NumJewelsInStones(string J, string S)
    {
        return S.Count(J.Contains);
    }

    public int NumberOfSteps(int num)
    {
        var count = 0;
        while (num != 0)
        {
            if (num % 2 == 0)
            {
                num /= 2;
            }
            else
            {
                num--;
            }

            count++;
        }

        return count;
    }

    public string RestoreString(string s, int[] indices)
    {
        var builder = new StringBuilder(s);
        for (var i = 0; i < s.Length; i++)
        {
            builder[indices[i]] = s[i];
        }

        return builder.ToString();
    }

    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var list = nums.Select(_ => 0).ToArray();

        foreach (var num in nums)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] > num)
                {
                    list[i]++;
                }
            }
        }

        return list;
    }

    public static TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null) return null;

        t1 ??= new TreeNode();
        t2 ??= new TreeNode();

        t1.val += t2.val;

        if (t2.left != null)
        {
            t1.left ??= new TreeNode();
            MergeTrees(t1.left, t2.left);
        }

        if (t2.right != null)
        {
            t1.right ??= new TreeNode();
            MergeTrees(t1.right, t2.right);
        }

        return t1;
    }

    private static int FindTreeDepth(TreeNode tree, int n = 0)
    {
        if (tree == null) return n;

        if (tree.left != null && tree.right == null) return n + 1;

        return Math.Max(FindTreeDepth(tree.left, n + 1), FindTreeDepth(tree.right, n + 1));
    }

    public int DiameterOfBinaryTree(TreeNode root)
    {
        // TODO: Wrong Answer
        if (root == null || root.left == null && root.right == null) return 0;

        var left = FindTreeDepth(root.left);
        var right = FindTreeDepth(root.right);

        var result = left + right;

        return result;
    }
}

namespace LeetCode
{
    class Program
    {
        private static void PrintTree(TreeNode tree, string type = "Root")
        {
            Console.WriteLine($"{type} {tree.val}");

            if (tree.left != null)
            {
                PrintTree(tree.left, type + ",Left");
            }

            if (tree.right != null)
            {
                PrintTree(tree.right, type + ", Right");
            }
        }

        static void Main(string[] args)
        {
            var t1 = new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(5)
                },

                right = new TreeNode(2)
            };

            var t2 = new TreeNode(2)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(4)
                },

                right = new TreeNode(3)
                {
                    right = new TreeNode(7)
                }
            };

            var tree = Solution.MergeTrees(t1, t2);

            PrintTree(tree);
        }
    }
}

public class ParkingSystem
{
    private List<int> _parkingCenter;


    public ParkingSystem(int big, int medium, int small)
    {
        _parkingCenter = new List<int> {big, medium, small};
    }

    public bool AddCar(int carType)
    {
        return _parkingCenter[carType - 1]-- > 0;
    }
}

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}