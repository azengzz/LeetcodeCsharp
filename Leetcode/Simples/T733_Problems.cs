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

        #region T819 最常见的单词

        /*
         * 1, 从字符串中分离出单词，转换成小写；
         * 2, 单词是否在禁用表中；
         * 3, 不在禁用表中的单词添加到结果表中，累加它的出现次数；
         * 4, 输出出现次数最多的单词
         */
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> bans = new HashSet<string>();
            Dictionary<string, int> results = new Dictionary<string, int>();

            foreach (string b in banned) bans.Add(b);

            int start = 0, end = 0;
            while (end <= paragraph.Length)
            {
                if (end == paragraph.Length || !IsAlpha(paragraph[end]))
                {
                    int wordLength = end - start;
                    string word = paragraph.Substring(start, wordLength).ToLower();
                    if (wordLength > 0 && !bans.Contains(word))
                    {
                        if (results.ContainsKey(word))
                        {
                            results[word]++;
                        }
                        else
                        {
                            results[word] = 1;
                        }
                    }
                    end++;
                    start = end;               
                }
                else
                {
                    end++;
                }
            }
            int freq = results.Values.Max();
            return (from re in results where re.Value == freq select re.Key).ToArray()[0];
        }

        private bool IsAlpha(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }

        #endregion

        #region T821 字符的最短距离

        public int[] ShortestToChar(string S, char C)
        {
            List<int> indexs = new List<int>();
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == C) indexs.Add(i);
            }

            int ptr = 0;
            int index0 = indexs[ptr];
            int index1 = index0;
            int[] result = new int[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                if (i < index0) result[i] = index0 - i;
                else if (i == index0 || i == index1)
                {
                    result[i] = 0;
                    index0 = index1;
                    ++ptr;
                    if (ptr < indexs.Count)  index1 = indexs[ptr];
                }
                else if (i > index0 && i <= index1)
                {
                    result[i] = Math.Min(Math.Abs(i - index0), Math.Abs(i - index1));
                }
                else
                {
                    result[i] = i - index1;
                }
            }
            return result;
        }

        #endregion

        #region T824 山羊拉丁文

        public string ToGoatLatin(string S)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            StringBuilder result = new StringBuilder();
            string[] words = S.Split(' ');

            for (int i = 0; i < words.Length; i++)
            {
                StringBuilder word = new StringBuilder(words[i]);
                if (!vowels.Contains(word[0]))
                {
                    char c = word[0];
                    word.Remove(0, 1);
                    word.Append(c);
                }
                word.Append("ma");
                word.Append('a', i + 1);

                result.Append(word + " ");
            }
            return result.Remove(result.Length - 1, 1).ToString();
        }

        #endregion

        #region T830 较大分组的位置

        public IList<IList<int>> LargeGroupPositions(string S)
        {
            List<IList<int>> res = new List<IList<int>>();
            int start = 0, end = 0;

            while (end <= S.Length)
            {
                if (end == S.Length || S[start] != S[end])
                {
                    if (end - start >= 3)
                    {
                        res.Add(new List<int> { start, end - 1 });
                    }
                    start = end;
                }
                end++;
            }
            return res;
        }

        #endregion

        #region T832 翻转图像

        public int[][] FlipAndInvertImage(int[][] A)
        {
            for(int i = 0; i < A.Length; i++)
            {
                A[i] = A[i].Reverse().ToArray();
                for (int j = 0; j < A[i].Length; j++)
                    A[i][j] ^= 1;
            }
            return A;
        }

        #endregion

        #region T836 矩形重叠

        public bool IsRectangleOverlap(int[] rec1, int[] rec2)
        {
            return ((long)(rec2[0] - rec1[2]) * (long)(rec2[2] - rec1[0]) < 0)
                && ((long)(rec2[1] - rec1[3]) * (long)(rec2[3] - rec1[1]) < 0);
        }

        #endregion

        #region T840 矩阵中的幻方

        public int NumMagicSquaresInside(int[][] grid)
        {          
            int count = 0;
            
            for (int i = 0; i < grid.Length - 2; i++)
            {
                for (int j = 0; j < grid[0].Length - 2; j++)
                {
                    int[] arrA = new int[3];
                    int[] arrB = new int[3];
                    int[] arrC = new int[3];
                    HashSet<int> marked = new HashSet<int>();
                    bool enable = true;
                    for (int m = 0; m < 3; m++)
                    {
                        if (marked.Contains(grid[i][j + m]) || grid[i][j + m] < 1 || grid[i][j + m] > 9)
                        {
                            enable = false;
                            break;
                        }
                        if (marked.Contains(grid[i + 1][j + m]) || grid[i+1][j + m] < 1 || grid[i + 1][j + m] > 9)
                        {
                            enable = false;
                            break;
                        }
                        if (marked.Contains(grid[i + 2][j + m]) || grid[i+2][j + m] < 1 || grid[i + 2][j + m] > 9)
                        {
                            enable = false;
                            break;
                        }
                        arrA[m] = grid[i][j + m];
                        arrB[m] = grid[i + 1][j + m];
                        arrC[m] = grid[i + 2][j + m];
                        marked.Add(arrA[m]);
                        marked.Add(arrB[m]);
                        marked.Add(arrC[m]);
                    }
                    if (enable)    //都是有效数字
                    {
                        int oblique1 = arrA[0] + arrB[1] + arrC[2];
                        int oblique2 = arrA[2] + arrB[1] + arrC[0];
                        int col1 = arrA[0] + arrB[0] + arrC[0];
                        int col2 = arrA[1] + arrB[1] + arrC[1];
                        int col3 = arrA[2] + arrB[2] + arrC[2];
                        int sumA = arrA.Sum();
                        if (sumA == arrB.Sum() && sumA == arrC.Sum() && sumA == arrC.Sum() 
                            && sumA == col1 && sumA == col2 && sumA == col3
                            && sumA == oblique1 && sumA == oblique2)
                            count++;
                    }
                }
            }
            return count;
        }

        #endregion

        #region T844 比较含退格的字符串

        public bool BackspaceCompare(string S, string T)
        {
            Stack<char> stackS = new Stack<char>();
            Stack<char> stackT = new Stack<char>();

            StringIntoStack(stackS, S);
            StringIntoStack(stackT, T);

            if (stackS.Count != stackT.Count) return false;

            while (stackS.Count > 0)
            {
                if (stackS.Pop() != stackT.Pop()) return false;
            }
            return true;
        }

        private void StringIntoStack(Stack<char> stk, string s)
        {
            foreach (char c in s)
            {
                if (c != '#') stk.Push(c);
                else if (stk.Count > 0) stk.Pop();
            }
        }

        #endregion

        #region T849 到最近的人的最大距离

        //最大值只可能出现在三种位置：最前N个0；最后N个0；中间连续0的个数除以2
        public int MaxDistToClosest(int[] seats)
        {
            int firstOneIndex = int.MinValue;
            int lastOneIndex = int.MinValue;
            int left = int.MinValue, right = int.MinValue;
            int max = 0;

            for (int i = 0; i < seats.Length; i++)
            {
                if (seats[i] == 0) continue;
                if (firstOneIndex < 0)
                {
                    firstOneIndex = i;
                    lastOneIndex = i;
                    left = i;
                }
                if (i > lastOneIndex)
                {
                    lastOneIndex = i;
                }
                if (right <= left)
                {
                    right = i;
                    max = Math.Max(max, (right - left) / 2);
                    left = right;
                }
            }
            if (firstOneIndex > max) max = firstOneIndex;
            if (seats.Length - lastOneIndex > max) max = seats.Length - lastOneIndex - 1;
            return max;
        }

        #endregion

        #region T852 山脉数组的峰值索引
        //题干已说明数组一定是山脉数组
        public int PeakIndexInMountainArray(int[] A)
        {
            return Array.IndexOf(A, A.Max());
        }

        #endregion

        #region T859 亲密字符串

        public bool BuddyStrings(string A, string B)
        {
            if (A == null || B == null) return false;
            if (A.Length < 2 || B.Length < 2) return false;

            List<int> difference = new List<int>();
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] != B[i]) difference.Add(i);
            }

            if (difference.Count == 0)
            {
                //如果A和B相等，若字符串A中没有重复的字符，则无法完成题目要求的交换字符操作。
                HashSet<char> charSet = new HashSet<char>();
                foreach (char c in A)
                {
                    if (charSet.Contains(c)) return true;
                    else charSet.Add(c);
                }
                return false;
            }

            if (difference.Count != 2) return false;

            //如果A和B中确实有两个字符不同，则试着交换A中那两个不同的字符，看是否能和B相等
            StringBuilder temp = new StringBuilder(A);
            temp[difference[0]] = A[difference[1]];
            temp[difference[1]] = A[difference[0]];
            return temp.ToString() == B;
        }

        #endregion

        #region T860 柠檬水找零

        public bool LemonadeChange(int[] bills)
        {
            Dictionary<int, int> wallet = new Dictionary<int, int> { { 5, 0 }, { 10, 0 }, { 20, 0 } };    //当前钱包中纸币种类与余额
           
            foreach (int bill in bills)
            {
                wallet[bill] += 1;    //收钱

                //找钱
                if (bill == 10)
                {
                    if (wallet[5] == 0) return false;
                    wallet[5]--;
                }
                else if (bill == 20)
                {
                    if (wallet[10] != 0 && wallet[5] != 0)
                    {
                        wallet[10]--;
                        wallet[5]--;
                    }
                    else if (wallet[5] >= 3)
                    {
                        wallet[5] -= 3;
                    }
                    else return false;
                }
            }
            return true;
        }

        #endregion
    }
}
