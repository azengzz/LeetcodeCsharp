using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T867_Problems
    {
        public T867_Problems() { }

        #region T867 转置矩阵

        public int[][] Transpose(int[][] A)
        {
            if (A == null) return null;

            int rows = A[0].Length;
            int cols = A.Length;
            int[][] T = new int[rows][];
            
            for (int i = 0; i < rows; i++)
            {
                T[i] = new int[cols];
            }

            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < A[0].Length; j++)
                {
                    T[j][i] = A[i][j];
                }
            }
            return T;
        }

        #endregion

        #region T868 二进制间距

        public int BinaryGap(int N)
        {
            int count = 0, max = 0;
            bool start = false;
            int remaind = 0;

            while (N > 0)
            {
                remaind = N % 2;
                if (remaind == 1)
                {
                    if (count > max) max = count;
                    count = 0;
                    start = true;
                }
                if (start)
                    count++;

                N /= 2;
            }
            return max;
        }

        #endregion

        #region T872 叶子相似的树

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            if (root1 == null && root2 == null) return true;
            if (root1 == null || root2 == null) return false;

            List<int> leaves1 = new List<int>();
            List<int> leaves2 = new List<int>();

            GetLeavesValue(root1, leaves1);
            GetLeavesValue(root2, leaves2);

            if (leaves1.Count != leaves2.Count) return false;
            for (int i = 0; i < leaves1.Count; i++)
            {
                if (leaves1[i] != leaves2[i]) return false;
            }
            return true;
        }

        private void GetLeavesValue(TreeNode root, IList<int> leaves)
        {
            if (root == null) return;
            if (root.left == null && root.right == null)
            {
                leaves.Add(root.val);
                return;
            }
            GetLeavesValue(root.left, leaves);
            GetLeavesValue(root.right, leaves);
        }

        #endregion

        #region T874 模拟行走机器人

        public int RobotSim(int[] commands, int[][] obstacles)
        {
            //上，右，下，左 转向基准
            int[][] directions = { new int[] { 0, 1 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };
            HashSet<string> obstaclesSet = new HashSet<string>();
            int dicIndex = 0;    //方向索引
            int distance = 0;

            foreach (var ob in obstacles)
            {
                obstaclesSet.Add(ob[0] + " " + ob[1]);
            }

            int positionX = 0, positionY = 0;
            foreach (var cmd in commands)
            {
                if (cmd == -1)    //右转
                {
                    dicIndex = (dicIndex + 1) % 4;                
                }
                else if (cmd == -2)    //左转
                {
                    dicIndex = (dicIndex + 3) % 4;
                }
                else    //直行
                {
                    int[] current = directions[dicIndex];    //当前走向
                    for (int i = 0; i < cmd; i++)
                    {
                        if (obstaclesSet.Contains((positionX + current[0]) + " " + (positionY + current[1])))
                            break;    //遇到障碍物，此方向移动结束

                        positionX += current[0];
                        positionY += current[1];
                    }
                    int currentDistance = positionX * positionX + positionY * positionY;
                    distance = distance < currentDistance ? currentDistance : distance;
                }
            }
            return distance;
        }

        #endregion

        #region T876 链表的中间节点
        //快慢指针
        public ListNode MiddleNode(ListNode head)
        {
            ListNode fast = head;
            ListNode slow = head;

            if (slow == null) return slow;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }
            return slow;
        }

        #endregion

        #region T883 三维形体投影面积

        public int ProjectionArea(int[][] grid)
        {
            int total = 0;
            int[] maxEachCol = new int[grid[0].Length];

            //顶视图，坐标中有值的地方就有一个面积
            for (int i = 0; i < grid.Length; i++)
            {
                total += grid[i].Max();    //左视图，从x那一面看过去，每个子数组最大值累加
                for (int j = 0; j < grid[0].Length; j++)
                {
                    total += grid[i][j] != 0 ? 1 : 0;    //顶视图，坐标中有值的地方就有一个面积
                    maxEachCol[j] = grid[i][j] > maxEachCol[j] ? grid[i][j] : maxEachCol[j];
                }                    
            }
            total += maxEachCol.Sum();    //前视图，从y方向看过去，子数组中相同下标的的值中最大值的累加

            return total;
        }

        #endregion

        #region T884 两句话中不常见的单词

        //吸取之前题目的经验，这类型的题可以考虑将两个字符串合并
        public string[] UncommonFromSentences(string A, string B)
        {
            if (A == null || B == null) return new string[] { };

            string[] AB = (new StringBuilder(A + " " + B)).ToString().Split(' ');
            Dictionary<string, int> frequence = new Dictionary<string, int>();
            
            foreach (string word in AB)
            {
                if (frequence.ContainsKey(word))
                    frequence[word]++;
                else frequence[word] = 1;
            }
            return (from freq in frequence where freq.Value == 1 where freq.Key.Length > 0 select freq.Key).ToArray();
        }

        #endregion

        #region T888 公平交换糖果

        //A和B的差除以2，就是要交换的两块糖的重量差
        public int[] FairCandySwap(int[] A, int[] B)
        {
            HashSet<int> BSet = new HashSet<int>();
            foreach (int b in B) BSet.Add(b);    //为了加快查找

            int diff = (A.Sum() - B.Sum()) / 2;    //题目保证答案一定存在，则这个值一定不含小数点

            int[] res = { 0, 0 };
            foreach (int a in A)
            {
                if (BSet.Contains(a - diff))
                {
                    res[0] = a;
                    res[1] = a - diff;
                    break;
                }
            }
            return res;
        }

        #endregion

        #region T892 三维形体的表面积

        //和883题算三维形体投影面积类似。
        public int SurfaceArea(int[][] grid)
        {
            int total = 0;
            
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    total += grid[i][j] != 0 ? 2 : 0;    //顶视图 + 底视图
                }

                //每一行的情况，每个行就是一个子数组
                total += CalculateUntouchArea(grid[i]);    //每个位置上两侧的面积之和，减去所有接触面面积
            }      

            //再看每一列的情况，列是每个子数组中相同下标的集合
            for (int i = 0; i < grid[0].Length; i++)
            {
                int[] transpose = new int[grid.Length];
                for (int j = 0; j < grid.Length; j++)
                {
                    transpose[j] += grid[j][i];
                }
                total += CalculateUntouchArea(transpose);
            }

            return total;
        }

        private int CalculateUntouchArea(int[] cells)
        {
            int area = cells.Sum() * 2;
            for (int j = 1; j < cells.Length; j++)
            {
                area -= (cells[j] <= cells[j - 1] ? cells[j] : cells[j - 1]) * 2;    //减去接触面
            }
            return area;
        }

        #endregion

        #region T893 特殊等价字符串组

        public int NumSpecialEquivGroups(string[] A)
        {
            HashSet<string> seen = new HashSet<string>();
            foreach (string str in A)
            {
                int[] count = new int[52];
                for (int i = 0; i < str.Length; i++)
                {
                    count[str[i] - 'a' + 26 * (i % 2)]++;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < count.Length; i++)
                {
                    sb.Append(count[i]);
                }
                seen.Add(sb.ToString());
            }
            return seen.Count;
        }

        #endregion

        #region T896 单调数列

        public bool IsMonotonic(int[] A)
        {
            bool upFlag = true;
            bool downFlag = true;

            for (int i = 0; i < A.Length - 1; i++)
            {
                if (A[i] > A[i + 1]) upFlag = false;
                else if (A[i] < A[i + 1]) downFlag = false;

                if (upFlag == false && downFlag == false) return false;
            }
            return true;
        }

        #endregion

        #region T897 递增顺序查找树

        public TreeNode IncreasingBST(TreeNode root)
        {
            TreeNode newRoot = new TreeNode(int.MinValue);
            DepthFirstSearch(root, newRoot);
            return newRoot.right;
        }

        private void DepthFirstSearch(TreeNode oldTree, TreeNode newTree)
        {
            if (oldTree == null) return;

            DepthFirstSearch(oldTree.left, newTree);
            while (newTree.right != null) newTree = newTree.right;
            newTree.right = new TreeNode(oldTree.val);
            DepthFirstSearch(oldTree.right, newTree);
        }

        #endregion

        #region T905 按奇偶排序数组

        public int[] SortArrayByParity(int[] A)
        {
            int evenPtr = 0;    //将遍历到的偶数与这个位置上的值交换

            for (int i = 0; i < A.Length; i++)
            {
                if ((A[i] & 1) == 0)
                {
                    int temp = A[i];
                    A[i] = A[evenPtr];
                    A[evenPtr] = temp;
                    evenPtr++;
                }
            }

            return A;
        }

        #endregion

        #region T908 最小差值I

        //如果A的最大最小值之差比2倍K还小，则一定可以在范围内找到一个值使得最大值减去它，最小值加上它之后相等
        public int SmallestRangeI(int[] A, int K)
        {
            int diff = A.Max() - A.Min();
            return diff > 2 * K ? (diff - 2 * K) : 0;
        }

        #endregion

        #region T914 卡牌分组

        //找出各卡牌出现频数的最大公约数（gcd）
        public bool HasGroupsSizeX(int[] deck)
        {
            if (deck.Length < 1) return false;

            Dictionary<int, int> numCount = new Dictionary<int, int>();

            foreach (int d in deck)
            {
                if (numCount.ContainsKey(d)) numCount[d]++;
                else numCount[d] = 1;
            }

            int[] frequency = numCount.Values.ToArray();
            int min = frequency.Min();

            if (min < 2) return false;

            for (int i = 2; i <= min; i++)
            {
                bool gcdFlag = true;
                foreach (int freq in frequency)
                {
                    if (freq % i != 0)
                    {
                        gcdFlag = false;
                        break;
                    }
                }
                if (gcdFlag == true) return true;
            }
            return false;
        }

        #endregion

        #region T917 仅仅翻转字母

        public string ReverseOnlyLetters(string S)
        {
            StringBuilder res = new StringBuilder();
            int front = 0;
            int rear = S.Length - 1;

            while (front < S.Length)
            {
                if (!IsAlpha(S[front]))
                {
                    res.Append(S[front]);
                    front++;
                    continue;
                }

                while (!IsAlpha(S[rear]))
                {
                    rear--;
                }
                res.Append(S[rear]);
                front++;
                rear--;
            }
            return res.ToString();
        }

        private bool IsAlpha(char ch)
        {
            if ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z')) return true;
            return false;
        }

        #endregion

        #region T922 按奇偶性排序数组II

        public int[] SortArrayByParityII(int[] A)
        {
            List<int> evenIndexes = new List<int>();
            List<int> oddIndexes = new List<int>();

            for (int i = 0; i < A.Length; i++)
            {
                if ((A[i] % 2) != (i % 2))
                {
                    if (i % 2 == 0) oddIndexes.Add(i);
                    else evenIndexes.Add(i);
                }
            }
            for (int i = 0; i < evenIndexes.Count; i++)
            {
                int temp = A[evenIndexes[i]];
                A[evenIndexes[i]] = A[oddIndexes[i]];
                A[oddIndexes[i]] = temp;
            }

            return A;
        }

        #endregion

        #region T925 长按键入

        public bool IsLongPressedName(string name, string typed)
        {
            if (name.Length > typed.Length) return false;

            char current = typed[0];
            int namePtr = 0, typedPtr = 0;
            int count = 0;

            while (typedPtr <= typed.Length)
            {
                if (typedPtr < typed.Length && typed[typedPtr] == current)
                {
                    typedPtr++;
                    count++;
                }
                else
                {
                    int nCount = 0;
                    char nCurrent = name[namePtr];
                    while (namePtr < name.Length)
                    {
                        if (name[namePtr] != nCurrent) break;
                        namePtr++;
                        nCount++;
                    }

                    if (nCurrent != current || nCount > count) return false;
                    else
                    {
                        if (typedPtr >= typed.Length) break;
                        current = typed[typedPtr];
                        count = 0;
                    }                    
                }
            }
            if (namePtr < name.Length) return false;
            return true;
        }

        #endregion

        #region T929 独特的电子邮件地址

        public int NumUniqueEmails(string[] emails)
        {
            Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();

            foreach (string em in emails)
            {
                string[] emSplit = em.Split('@');

                string domain = emSplit[1];
                string validLocal = emSplit[0].Split('+')[0].Replace(".", "");

                if (dict.ContainsKey(domain))
                {
                    if (!dict[domain].Contains(validLocal))
                        dict[domain].Add(validLocal);
                }
                else
                {
                    dict[domain] = new HashSet<string> { validLocal };
                }
            }

            int total = 0;
            foreach (var d in dict) total += d.Value.Count;

            return total; 
        }

        #endregion

        #region T933 最近的请求次数

        public class RecentCounter
        {
            private Queue<int> pingTime;

            public RecentCounter()
            {
                pingTime = new Queue<int>();
            }

            public int Ping(int t)
            {
                pingTime.Enqueue(t);
                while (t - pingTime.Peek() > 3000)
                    pingTime.Dequeue();

                return pingTime.Count;
            }
        }

        #endregion

        #region T937 重新排列日志文件

        public string[] ReorderLogFiles(string[] logs)
        {
            List<KeyValuePair<string, int>> alphaLogs = new List<KeyValuePair<string, int>>();
            List<int> numberic = new List<int>();

            for (int i = 0; i < logs.Length; i++)
            {
                string log = logs[i];
                if (log[log.Length-1] >= 'a' && log[log.Length - 1] <= 'z')    //只看最后一个字符即可知是字母日志还是数字日志
                {
                    int valid = log.IndexOf(' ') + 1;
                    alphaLogs.Add(new KeyValuePair<string, int>(logs[i].Substring(valid), i));
                }
                else
                {
                    numberic.Add(i);
                }
            }

            var sorted = alphaLogs.OrderBy(pair => pair.Key);
            List<string> res = new List<string>();
            
            foreach (var pair in sorted)
            {
                res.Add(logs[pair.Value]);
            }
            foreach (var i in numberic)
            {
                res.Add(logs[i]);
            }
            return res.ToArray();
        }

        #endregion

        #region T941 有效的山脉数组

        public bool ValidMountainArray(int[] A)
        {
            if (A.Length < 3) return false;

            int peakIndexLeft = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (i != A.Length - 1)
                {
                    if (A[i + 1] <= A[i])
                    {
                        peakIndexLeft = i;
                        break;
                    }
                    else peakIndexLeft = i;    //最右边的是山脉
                }
            }

            int peakIndexRight = A.Length;
            for (int i = A.Length - 1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (A[i] >= A[i - 1])
                    {
                        peakIndexRight = i;
                        break;
                    }
                    else peakIndexRight = i;    //最左边是山脉
                }
            }

            return peakIndexLeft == peakIndexRight;
        }

        #endregion

        #region T942 增减字符串匹配

        public int[] DiStringMatch(string S)
        {
            List<int> incs = new List<int>();
            for (int i = S.Length - 1; i >= 0; i--)    //倒序记录增长的位置
            {
                if (S[i] == 'I') incs.Add(i + 1);
            }

            int max = S.Length;
            int[] res = new int[max + 1];
            foreach (int n in incs)    //从右到左按递减在增长点放置最大值
            {
                res[n] = max;
                max -= 1;
            }
            for (int i = 0; i < S.Length; i++)    //从左到右添加递减点
            {
                if (res[i] == 0)
                {
                    res[i] = max;
                    max--;
                }
            }
            return res;
        }

        #endregion

        #region T944 删除造序

        //题目就是在问有多少列是非升序的 （相邻字母相同也算升序）
        public int MinDeletionSize(string[] A)
        {
            int count = 0;

            for (int i = 0; i < A[0].Length; i++)
            {
                for (int j = 0; j < A.Length - 1; j++)
                {
                    if (A[j][i] > A[j + 1][i])
                    {
                        count++;
                        break;
                    }
                }
            }
            return count;
        }

        #endregion

        #region T949 给定数字能组成的最大时间

        //找出所有可能的组合，然后找出合法的最大值
        public string LargestTimeFromDigits(int[] A)
        {
            Queue<List<int>> queue = new Queue<List<int>>();

            for (int i = 0; i < A.Length; i++)
            {
                List<int> lst = new List<int>() { i };    //记录下标
                queue.Enqueue(lst);
            }

            //只记录所有组合在A中的下标
            for (int t = 0; t < A.Length - 1; t++)
            {
                int count = queue.Count;
                while (count > 0)
                {
                    List<int> deq = queue.Dequeue();
                    for (int i = 0; i < A.Length; i++)
                    {
                        if (!deq.Contains(i))
                        {
                            List<int> tmp = new List<int>();
                            foreach (int v in deq) tmp.Add(v);
                            tmp.Add(i);
                            queue.Enqueue(tmp);
                        }
                    }
                    --count;
                }
            }

            //从下标组合中还原出所有的组合，并找合法的最大值
            int validMax = -1;
            while (queue.Count > 0)
            {
                List<int> lst = queue.Dequeue();
                int[] arr = new int[] { A[lst[0]], A[lst[1]], A[lst[2]], A[lst[3]] };
                int val = checkTime(arr);
                if (val > validMax) validMax = val;
            }

            //拼接出结果
            if (validMax != -1)
            {
                char[] res = new char[5];
                for (int i = res.Length - 1; i >= 0; i--)
                {
                    if (i == 2) res[i] = ':';
                    else
                    {
                        res[i] = (char)(validMax % 10 + '0');
                        validMax = validMax / 10;
                    }
                }
                return new string(res);
            }
            return "";
        }

        int checkTime(int[] arr)
        {
            bool flag = false;

            if (arr[0] >= 0 && arr[0] < 2)
            {
                if (arr[2] >= 0 && arr[2] <= 5)
                    flag = true;
            }
            else if (arr[0] == 2)
            {
                if (arr[1] >= 0 && arr[1] <= 3 && arr[2] >= 0 && arr[2] <= 5)
                    flag = true;
            }

            if (flag) return arr[0] * 1000 + arr[1] * 100 + arr[2] * 10 + arr[3];
            else return -1;
        }

        #endregion

        #region T953 验证外星语词典

        public bool IsAlienSorted(string[] words, string order)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < order.Length; i++)
            {
                dict.Add(order[i], i);
            }

            for (int i = 0; i < words.Length - 1; i++)
            {
                if (!CompareAlienWords(words[i], words[i + 1], dict))
                    return false;
            }
            return true;
        }

        private bool CompareAlienWords(string word1, string word2, Dictionary<char, int> order)
        {
            int minLength = word1.Length <= word2.Length ? word1.Length : word2.Length;

            int j = 0;
            for (j = 0; j < minLength; j++)
            {
                if (order[word1[j]] < order[word2[j]])
                {
                    return true;
                }
                else if (order[word1[j]] > order[word2[j]])
                {
                    return false;
                }
            }
            if (word1.Length <= word2.Length) return true;
            return false;
        }

        #endregion

        #region T961 重复N次的元素

        //甚至不需要全部遍历完，只要发现有一个元素出现2次，就返回它
        public int RepeatedNTimes(int[] A)
        {
            HashSet<int> elements = new HashSet<int>();

            foreach (int n in A)
            {
                if (elements.Contains(n)) return n;
                elements.Add(n);
            }

            return -1;
        }

        #endregion
    }
}
