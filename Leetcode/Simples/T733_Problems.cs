using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T733_Problems
    {
        public T733_Problems() { }

        #region T733 图像渲染
        //非递归算法 - 广度优先
        public int[,] FloodFill(int[,] image, int sr, int sc, int newColor)
        {
            int originColor = image[sr, sc];
            int rows = image.GetLength(0);
            int cols = image.GetLength(1);
            Queue<KeyValuePair<int, int>> pixels = new Queue<KeyValuePair<int, int>>();
            pixels.Enqueue(new KeyValuePair<int, int>(sr, sc));
            while (pixels.Count > 0)
            {
                KeyValuePair<int, int> pixel = pixels.Dequeue();
                int row = pixel.Key;
                int col = pixel.Value;
                image[row, col] = newColor;

                if (row - 1 >= 0 && image[row - 1, col] == originColor && image[row-1, col] != newColor)
                    pixels.Enqueue(new KeyValuePair<int, int>(row - 1, col));
                if (row + 1 < rows && image[row + 1, col] == originColor && image[row + 1, col] != newColor)
                    pixels.Enqueue(new KeyValuePair<int, int>(row + 1, col));
                if (col - 1 >= 0 && image[row, col - 1] == originColor && image[row, col - 1] != newColor)
                    pixels.Enqueue(new KeyValuePair<int, int>(row, col - 1));
                if (col + 1 < cols && image[row, col + 1] == originColor && image[row, col + 1] != newColor)
                    pixels.Enqueue(new KeyValuePair<int, int>(row, col + 1));
            }
            return image;
        }

        #endregion

        #region T743 网络延迟时间   （待完成）



        #endregion

        #region T744 寻找比目标字母大的最小字母
        //letters已经排序过的
        public char NextGreatestLetter(char[] letters, char target)
        {
            foreach (char c in letters)
            {
                if (c > target) return c;
            }
            return letters[0];
        }

        #endregion

        #region T746 使用最小花费爬楼梯

        public int MinCostClimbingStairs(int[] cost)
        {
            if (cost.Length == 0) return 0;
            if (cost.Length == 1) return cost[0];

            int[] totalCost = new int[cost.Length];

            totalCost[0] = cost[0];
            totalCost[1] = cost[1];
            for (int i = 2; i < totalCost.Length; i++)
            {
                //计算每登一级阶梯要造成的总最小花费
                totalCost[i] = Math.Min(totalCost[i - 1], totalCost[i - 2]) + cost[i];
            }
            return Math.Min(totalCost[totalCost.Length - 1], totalCost[totalCost.Length - 2]);
        }

        #endregion

        #region T747 找至少是其他数字2倍的最大数

        public int DominantIndex(int[] nums)
        {
            int max = nums.Max();

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != max)
                {
                    if (nums[i] * 2 > max) return -1;    //nums[i]可能为0，故不可用除法
                }
            }
            return Array.IndexOf(nums, max);
        }

        #endregion

        #region T748 最短的完整词

        public string ShortestCompletingWord(string licensePlate, string[] words)
        {
            Dictionary<char, int> plateDict = new Dictionary<char, int>();
            for (int i = 0; i < licensePlate.Length; i++)
            {
                char ch = licensePlate[i];
                bool isCharacter = false;
                if (ch >= 'a' && ch <= 'z') { isCharacter = true; }
                else if (ch >= 'A' && ch <= 'Z') { ch = (char)(ch + 32); isCharacter = true; }
                if (isCharacter)
                {
                    if (plateDict.ContainsKey(ch)) plateDict[ch]++;
                    else plateDict.Add(ch, 1);
                }
            }
            List<string> completingWords = new List<string>();
            int shortestLen = int.MaxValue;
            foreach (string word in words)
            {
                Dictionary<char, int> temp = new Dictionary<char, int>();
                for (int j = 0; j < word.Length; j++)
                {
                    if (temp.ContainsKey(word[j])) temp[word[j]]++;
                    else temp.Add(word[j], 1);
                }
                bool complete = true;
                foreach (var mem in plateDict)
                {
                    if (!temp.ContainsKey(mem.Key) || temp[mem.Key] < plateDict[mem.Key])
                    {
                        complete = false;
                        break;
                    } 
                }
                if (complete)
                {
                    completingWords.Add(word);
                    if (word.Length < shortestLen) shortestLen = word.Length;
                }
            }
            return completingWords.Find(w => w.Length == shortestLen);
        }

        #endregion

        #region T754 到达终点的数字

        public int ReachNumber(int target)
        {
            if (target < 0) target *= -1;

            int n = 0;
            int sum = 0;
            while (sum < target)
            {
                n += 1;
                sum += n;                
            }
            if (sum == target) return n;

            int diff = sum - target;
            if (diff % 2 == 0) return n;    //相差偶数，可以通过翻转diff/2来实现

            if (n % 2 == 0) return n + 1;   //相差为奇数，观察n的奇偶性
            return n + 2;
        }

        #endregion

        #region T762 二进制表示中质数个计算置位

        public int CountPrimeSetBits(int L, int R)
        {
            //因为最大数为10^6，换算成二进制是20位，故只检查num是否为2，3，5，7，11，13，17，19
            int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19 };

            int count = 0;

            for (int i = L; i <= R; i++)
            {
                int ones = CountOnes(i);
                if (Array.IndexOf(primes, ones) != -1) count++;
            }
            return count;
        }

        private int CountOnes(int num)
        {
            int res = 0;
            while (num != 0)
            {
                res += num & 0x01;
                num >>= 1;
            }
            return res;
        }

        #endregion

        #region T766 托普利茨矩阵

        public bool IsToeplitzMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int top = i - 1, left = j - 1;
                    if (top < 0 || left < 0) continue;
                    if (matrix[top, left] != matrix[i, j]) return false;
                }
            }
            return true;
        }

        #endregion

        #region T771 宝石与石头

        public int NumJewelsInStones(string J, string S)
        {
            HashSet<char> jewels = new HashSet<char>();
            foreach (char c in J)
                jewels.Add(c);
            int count = 0;
            foreach (char stone in S)
            {
                if (jewels.Contains(stone))
                    count++;
            }
            return count;
        }

        #endregion

        #region T783 二叉搜索树结点最小距离

        public int MinDiffInBST(TreeNode root)
        {
            if (root == null) return 0;

            List<int> nums = new List<int>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int min = int.MaxValue;

            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();                
                int found = FindMinDiff(nums, node.val);

                if (found < min)
                    min = found;
                nums.Add(node.val);

                if (node.left != null) queue.Enqueue(node.left);
                if (node.right != null) queue.Enqueue(node.right);
            }
            return min;
        }

        private int FindMinDiff(List<int> list, int val)
        {
            if (list.Count == 0) return int.MaxValue;

            int min = int.MaxValue;
            foreach (int n in list)
            {
                int diff = Math.Abs(n - val);
                if (diff < min)
                    min = diff;
            }
            return min;
        }

        #endregion

        #region T784 字母大小写全排列

        private class BinaryStringTreeNode
        {
            public string val { get; set; }
            public BinaryStringTreeNode left { get; set; }
            public BinaryStringTreeNode right { get; set; }
            public BinaryStringTreeNode(string val)
            {
                this.val = val;
                left = null;
                right = null;
            }
        }

        public IList<string> LetterCasePermutation(string S)
        {
            //先构造一棵树
            BinaryStringTreeNode root = new BinaryStringTreeNode("");
            Queue<BinaryStringTreeNode> queue = new Queue<BinaryStringTreeNode>();
            queue.Enqueue(root);

            foreach (char c in S)
            {
                char lower, upper;
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {                    
                    if (c >= 'a' && c <= 'z')
                    {
                        lower = c;
                        upper = (char)(c - 32);
                    }
                    else
                    {
                        lower = (char)(c + 32);
                        upper = c;
                    }
                }
                else
                {
                    lower = c;
                    upper = c;
                }

                List<BinaryStringTreeNode> lst = new List<BinaryStringTreeNode>();
                while (queue.Count > 0)
                {
                    BinaryStringTreeNode node = queue.Dequeue();
                    node.left = new BinaryStringTreeNode(node.val + lower.ToString());
                    lst.Add(node.left);
                    if (lower != upper)
                    {
                        node.right = new BinaryStringTreeNode(node.val + upper.ToString());
                        lst.Add(node.right);
                    }                        
                }
                foreach (var node in lst)
                {
                    queue.Enqueue(node);
                }
                lst.Clear();
            }

            List<string> res = new List<string>();
            while (queue.Count > 0)
                res.Add(queue.Dequeue().val);
            res.Sort();
            return res;
        }

        #endregion

        #region T788 旋转数字
        //这里的旋转不是指数字的位置变化，而是物理意义上的旋转
        public int RotatedDigits(int N)
        {
            int[] shouldInclude = { 2, 5, 6, 9 };
            int[] shouldNotInclude = { 3, 4, 7 };
            int count = 0;

            for (int i = 1; i <= N; i++)
            {
                List<int> digits = new List<int>();
                int num = i;
                while (num != 0)
                {
                    digits.Add(num % 10);
                    num /= 10;
                }
                bool isRotateNum = false;
                foreach (int d in digits)
                {
                    if (Array.IndexOf(shouldInclude, d) >= 0) isRotateNum = true;
                    else if (Array.IndexOf(shouldNotInclude, d) >= 0)
                    {
                        isRotateNum = false;
                        break;
                    }
                }
                if (isRotateNum) count++;
            }
            return count;
        }

        #endregion

        #region T796 旋转字符串

        public bool RotateString(string A, string B)
        {
            if (A.Length != B.Length) return false;

            string bb = B + B;
            return bb.Contains(A);
        }

        #endregion

        #region T804 唯一摩尔斯密码词

        public int UniqueMorseRepresentations(string[] words)
        {
            Dictionary<char, string> morseSheet = new Dictionary<char, string>
            {
                {'a', ".-"},
                {'b', "-..." },
                {'c', "-.-." },
                {'d', "-.." },
                {'e', "." },
                {'f', "..-." },
                {'g', "--." },
                {'h', "...." },
                {'i', ".." },
                {'j', ".---" },
                {'k', "-.-" },
                {'l', ".-.." },
                {'m', "--" },
                {'n', "-." },
                {'o', "---" },
                {'p', ".--." },
                {'q', "--.-" },
                {'r', ".-." },
                {'s', "..." },
                {'t', "-" },
                {'u', "..-" },
                {'v', "...-" },
                {'w', ".--" },
                {'x', "-..-" },
                {'y', "-.--" },
                {'z', "--.." }
            };

            List<string> groups = new List<string>();
            foreach (var word in words)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < word.Length; i++)
                {
                    sb.Append(morseSheet[word[i]]);
                }
                string s = sb.ToString();
                if (!groups.Contains(s)) groups.Add(s);
            }
            return groups.Count;
        }

        #endregion

        #region T806 写字符串需要的行数

        public int[] NumberOfLines(int[] widths, string S)
        {
            int lines = 1;
            int lineSpace = 100;

            foreach (char c in S)
            {
                if (lineSpace >= widths[c - 'a'])
                    lineSpace -= widths[c - 'a'];
                else
                {
                    lines++;
                    lineSpace = 100;
                    lineSpace -= widths[c - 'a'];
                }
            }
            return new int[2] { lines, 100 - lineSpace };

        }

        #endregion

        #region T811 子域名访问次数

        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string s in cpdomains)
            {
                string[] domains = s.Split('.').Reverse().ToArray();
                string[] lowest = domains[domains.Length - 1].Split(' ');
                domains[domains.Length - 1] = lowest[1];
                int visits = int.Parse(lowest[0]);

                string splice = "";
                for (int i = 0; i < domains.Length; i++)
                {
                    splice = domains[i] + "." + splice;
                    if (i == 0) splice = splice.Substring(0, splice.Length - 1);    //去掉最后一个点
                    if (dict.ContainsKey(splice))
                        dict[splice] += visits;
                    else
                    {
                        dict[splice] = visits;
                    }
                }                
            }

            List<string> result = new List<string>();
            foreach (var d in dict)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(d.Value).Append(" ").Append(d.Key);
                result.Add(sb.ToString());
            }
            return result;
        }

        #endregion

        #region T812 最大三角形面积
        //参考网上的三角形面积求解方法 : 由三个直角三角形面积组成
        public double LargestTriangleArea(int[][] points)
        {
            double area = 0;
            foreach (var a in points)
            {
                foreach (var b in points)
                {
                    foreach (var c in points)
                    {
                        double temp = (double)(a[0] * b[1] + b[0] * c[1] + c[0] * a[1] - a[0] * c[1] - c[0] * b[1] - b[0] * a[1]) / 2;
                        if (temp > area) area = temp;
                    }
                }
            }

            return area;
        }

        #endregion
    }
}
