using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T665_Problems
    {
        public T665_Problems() { }

        #region T665 非递减数列

        public bool CheckPossibility(int[] nums)
        {
            //三个一组判断
            bool flag = false;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] < nums[i - 1])
                {
                    if (flag == true) return false;
                    if (i - 2 >= 0 && nums[i] < nums[i - 2])
                    {
                        nums[i] = nums[i - 1];    //修改后继续判断
                    }
                    flag = true;
                }
            }
            return true;
        }

        #endregion

        #region T669 修剪二叉搜索树
        //修改不符合条件的节点的父指针
        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null) return null;
            if (root.val > R)
                return TrimBST(root.left, L, R);
            else if (root.val < L)
                return TrimBST(root.right, L, R);
            else
            {
                root.left = TrimBST(root.left, L, R);
                root.right = TrimBST(root.right, L, R);
                return root;
            }
        }

        #endregion

        #region T671 二叉树中第二小的节点

        public int FindSecondMinimumValue(TreeNode root)
        {
            int Mininum = root.val;
            int SecondMin = -1;
            Traverse(root, Mininum, ref SecondMin);
            return SecondMin;
        }

        private void Traverse(TreeNode node, int mininum, ref int secondMin)
        {
            if (node == null) return;
            if (node.val == mininum)
            {
                Traverse(node.left, mininum, ref secondMin);
                Traverse(node.right, mininum, ref secondMin);
                return;
            }
            else
            {
                if (secondMin > node.val || secondMin == -1)
                    secondMin = node.val;
            }
        }

        #endregion

        #region T674 找出最长的连续递增数列，返回最长连续递增数列的长度

        public int FindLengthOfLCIS(int[] nums)
        {
            if (nums == null || nums.Length == 0) return 0;

            int begin = 0, end = 0, max = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    end++;
                }
                else
                {
                    max = Math.Max(max, end - begin + 1);
                    begin = i;
                    end = i;
                }
            }
            return Math.Max(max, end - begin + 1);           
        }

        #endregion

        #region T680 验证回文字符串

        public bool ValidPalindrome(string s)
        {
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return (CheckPalindrome(s, left + 1, right) || CheckPalindrome(s, left, right - 1));
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }

        private bool CheckPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])    //这是第二次不同了，肯定错误
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        #endregion

        #region T682 棒球比赛计分

        public int CalPoints(string[] ops)
        {
            Stack<int> scores = new Stack<int>();
            foreach(string s in ops)
            {
                int score = 0;
                if (int.TryParse(s, out score))
                {
                    scores.Push(score);
                }
                else
                {
                    if (s == "C") scores.Pop();
                    else if (s == "D")
                    {
                        scores.Push(scores.Peek() * 2);
                    }
                    else if (s == "+")
                    {
                        int last = scores.Pop();
                        int sum = last + scores.Peek();    //不用pop两个，pop一个就可以了
                        scores.Push(last);    //取出来的再放回去
                        scores.Push(sum);
                    }
                }
            }
            return scores.Sum();
        }

        #endregion

        #region T686 重复叠加字符串匹配
        //使用正则表达式时可能出现提交超出内存限制的问题
        public int RepeatedStringMatch(string A, string B)
        {
            if (B.Length == 0) return 0;

            int maxLen = A.Length * 2 + B.Length;
            StringBuilder sb = new StringBuilder(A);

            while (sb.Length < B.Length)
            {
                sb.Append(A);
            }

            while (sb.Length < maxLen)
            {
                if (sb.ToString().IndexOf(B) >= 0)
                    return sb.Length / A.Length;
                sb.Append(A);
            }
            return -1;
        }

        #endregion

        #region T687 最长同值路径
        //用BST走到叶子节点，从叶子节点往回走，分别找到根节点的左、右最长路径，再根据根节点左右节点是否值相同确定是否相加
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null) return 0;

            int longest = 0;
            LongestPathFrom(root, root.val, ref longest);
            return longest;
        }

        //后序遍历
        private int LongestPathFrom(TreeNode node, int fatherVal, ref int longest)
        {
            if (node == null) return 0;

            int left = LongestPathFrom(node.left, node.val, ref longest);    //看左子树中跟当前节点值相同的节点的路径和
            int right = LongestPathFrom(node.right, node.val, ref longest);
            longest = left + right > longest ? left + right : longest;
            if (node.val == fatherVal) return Math.Max(left, right) + 1;
            return 0;
        }

        #endregion

        #region T690 员工的重要性

        public class Employee
        {
            public Employee(int id, int importance, List<int> subordinates)
            {
                Id = id;
                Importance = importance;
                Subordinates = new List<int>();
                foreach(int sub in subordinates)
                {
                    Subordinates.Add(sub);
                }
            }

            public int Id { get; private set; }
            public int Importance { get; private set; }
            public List<int> Subordinates { get; private set; }
        }

        public int GetImportance(List<Employee> employees, int id)
        {            
            Employee em = employees.Where(emp => id == emp.Id).FirstOrDefault();
            if (em == null) return 0;

            int importance = 0;
            //层序遍历
            Queue<Employee> queue = new Queue<Employee>();
            queue.Enqueue(em);
            while (queue.Count > 0)
            {
                Employee e = queue.Dequeue();
                importance += e.Importance;
                foreach (int i in e.Subordinates)
                {
                    queue.Enqueue(employees.Where(emp => i == emp.Id).FirstOrDefault());
                }
            }
            return importance;
        }

        #endregion

        #region T693 交替二进制数

        public bool HasAlternatingBits(int n)
        {
            int pre = n & 1;
            n >>= 1;
            while (n > 0)
            {
                int now = n & 1;
                if (now == pre) return false;
                pre = now;
                n >>= 1;
            }
            return true;
        }

        #endregion

        #region T696 计数二进制子串

        public int CountBinarySubstrings(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '1')
                {
                    int index = 0;
                    count += FindPreZeros(s, i);
                    count += FindNextZeros(s, i, ref index);
                    i += index;    //跳过
                }
            }
            return count;
        }

        private int FindPreZeros(string s, int now)
        {
            int count = 0;
            int zeroIndex = now - 1, oneIndex = now;
            while (zeroIndex >= 0 && oneIndex < s.Length && s[zeroIndex] != '1' && s[oneIndex] == '1')
            {
                count++;
                zeroIndex--;
                oneIndex++;
            }
            return count;
        }

        private int FindNextZeros(string s, int now, ref int index)
        {
            int count = 0;
            int  oneIndex = now;
            while (oneIndex+1 < s.Length && s[oneIndex+1] == '1')
            {
                oneIndex++;
                index++;
            }
            int zeroIndex = oneIndex + 1;
            while (zeroIndex < s.Length && oneIndex >= 0 && s[zeroIndex] != '1' && s[oneIndex] == '1')
            {
                count++;
                oneIndex--;
                zeroIndex++;
                index++;
            }
            return count;
        }

        #endregion

        #region T697 数组的度

        public int FindShortestSubArray(int[] nums)
        {
            int maxDegree = 0;
            Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();    //字典中包括数字及数字出现的下标集合

            //构造字典，并找出最大的度
            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]].Add(i);
                }
                else
                {
                    dict.Add(nums[i], new List<int> { i });
                }
                if (dict[nums[i]].Count > maxDegree)
                    maxDegree = dict[nums[i]].Count;
            }

            //找出所有度最大的数的下标集合
            var colle = (from d in dict where d.Value.Count == maxDegree select d.Value).ToList();

            int minSubLen = int.MaxValue;
            foreach(var li in colle)
            {
                int distance = li[li.Count - 1] - li[0] + 1;
                if (distance < minSubLen) minSubLen = distance;
            }
            return minSubLen;
        }

        #endregion

        #region T700 在二叉搜索树中搜索指定子树

        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null) return null;

            if (root.val == val) return root;
            else if (root.val < val)
                return SearchBST(root.right, val);
            else return SearchBST(root.left, val);
        }

        #endregion

        #region T703 构造求数据流中的第K大元素的类

        public class KthLargest
        {
            List<int> _kNums = null;
            int _kth = 0;

            public KthLargest(int k, int[] nums)
            {
                _kth = k;
                _kNums = nums.ToList();
                _kNums.Sort((a, b) => { return -a.CompareTo(b); });
                _kNums = _kNums.Take(k).ToList();    //取前K个               
            }

            public int Add(int val)
            {
                if (_kNums.Count < _kth)
                {
                    _kNums.Insert(GetIndex(_kNums, val), val);
                    return _kNums[_kNums.Count - 1];
                }
                int index = GetIndex(_kNums, val);
                if (index < _kth)
                {
                    _kNums.Insert(index, val);
                    if (_kNums.Count > _kth) _kNums.RemoveAt(_kNums.Count - 1);
                }
                return _kNums[_kNums.Count - 1];
            }

            private int GetIndex(List<int> nums, int val)
            {
                if (nums.Count == 0) return 0;
                for (int i = 0; i < nums.Count; i++)
                {
                    if (val >= nums[i])
                        return i;
                }
                return nums.Count;
            }
        }

        #endregion

        #region T705 设计哈希集合

        public class MyHashSet
        {
            private List<int>[] sheet;

            private int Hash(int val)
            {
                return val % sheet.Length;
            }

            /** Initialize your data structure here. */
            public MyHashSet()
            {
                sheet = new List<int>[10000];
            }

            public void Add(int key)
            {
                int k = Hash(key);
                if (sheet[k] == null)
                {
                    sheet[k] = new List<int>() { key };
                }
                else
                {
                    int index = sheet[k].FindIndex(mem =>  mem >= key );
                    if (index != -1 && sheet[k][index] != key)
                    {
                        sheet[k].Insert(index, key);    //保持升序
                    }
                    else if (index == -1) sheet[k].Add(key);
                }
            }

            public void Remove(int key)
            {
                int k = Hash(key);
                if (sheet[k] == null) return;
                int index = sheet[k].IndexOf(key);
                if (index != -1) sheet[k].RemoveAt(index);
            }

            /** Returns true if this set contains the specified element */
            public bool Contains(int key)
            {
                int k = Hash(key);
                if (sheet[k] == null) return false;
                return (sheet[k].IndexOf(key) != -1) ? true : false;
            }
        }

        #endregion

        #region T706 设计哈希映射

        public class MyHashMap
        {
            private class Pair
            {
                public int Key { get; set; }
                public int Value { get; set; }
                public Pair Next { get; set; }
                public Pair(int key, int value)
                {
                    Key = key;
                    Value = value;
                    Next = null;
                }
            }

            private Pair[] map;

            private int Hash(int key)
            {
                return key % map.Length;
            }

            private Pair FindPrePosition(Pair pairList, int keyVal)
            {
                if (keyVal <= pairList.Key) return null; 
                else
                {
                    Pair ptr = pairList;
                    while (ptr.Next != null)
                    {
                        if (ptr.Next.Key >= keyVal) return ptr;
                        else ptr = ptr.Next;
                    }
                    return ptr;
                }
            }

            /** Initialize your data structure here. */
            public MyHashMap()
            {
                map = new Pair[10000];
            }

            /** value will always be non-negative. */
            public void Put(int key, int value)
            {
                //按题意，允许重复的key值
                int k = Hash(key);
                Pair newNode = new Pair(key, value);

                if (map[k] == null)
                {
                    map[k] = newNode;
                }
                else
                {
                    Pair pre = FindPrePosition(map[k], key);
                    if (pre == null)
                    {
                        newNode.Next = map[k];
                        map[k] = newNode;
                    }
                    else if (pre.Next == null) pre.Next = newNode;
                    else
                    {
                        newNode.Next = pre.Next;
                        pre.Next = newNode;
                    }
                }
            }

            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key)
            {
                //如果有重复的key值，返回最近一次添加的
                int k = Hash(key);
                if (map[k] == null) return -1;
                else
                {
                    Pair pre = FindPrePosition(map[k], key);
                    if (pre == null)
                    {
                        if (map[k].Key == key)
                            return map[k].Value;    //返回第一个元素
                        else return -1;
                    }
                    else if (pre.Next == null)
                    {
                        if (pre.Key == key) return pre.Value;
                        else return -1;
                    }
                    else
                    {
                        if (pre.Next.Key == key) return pre.Next.Value;
                        else return -1;
                    }
                }
            }

            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key)
            {
                //按题意要把所有KEY相同的节点删掉
                int k = Hash(key);
                if (map[k] == null) return;
                else
                {
                    while (map[k] != null && map[k].Key == key)    //如果要找的Key就在最前面
                    {
                        map[k] = map[k].Next;
                    }
                    if (map[k] == null) return;
                    Pair pre = map[k];
                    while (pre.Next != null && pre.Next.Key <= key)
                    {
                        if (pre.Next.Key == key)
                        {
                            pre.Next = pre.Next.Next;
                        }
                        else
                            pre = pre.Next;                        
                    }
                }
            }
        }

        #endregion

        #region T707 设计链表

        public class MyLinkedListNode
        {
            public int Val { get; set; }
            public MyLinkedListNode Next { get; set; }

            public MyLinkedListNode()
            {
                Val = 0;
                Next = null;
            }

            public MyLinkedListNode(int val)
            {
                Val = val;
                Next = null;
            }
        }


        public class MyLinkedList
        {
            private MyLinkedListNode list;

            public int Length { get; private set; }
              
            /** Initialize your data structure here. */
            public MyLinkedList()
            {
                list = null;
                Length = 0;
            }

            private MyLinkedListNode GetNode(int index)
            {
                if (list == null || index < 0 || index >= Length) return null;

                MyLinkedListNode ptr = list;
                int i = 0;
                while (i < index)
                {
                    ptr = ptr.Next;
                    i++;
                }
                return ptr;
            }

            /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
            public int Get(int index)
            {
                MyLinkedListNode node = GetNode(index);
                if (node != null) return node.Val;
                return -1;
            }

            /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
            public void AddAtHead(int val)
            {
                MyLinkedListNode newNode = new MyLinkedListNode(val);
                newNode.Next = list;
                list = newNode;
                Length++;
            }

            /** Append a node of value val to the last element of the linked list. */
            public void AddAtTail(int val)
            {
                MyLinkedListNode newNode = new MyLinkedListNode(val);
                MyLinkedListNode tail = GetNode(Length - 1);
                if (tail == null) list = newNode;
                else tail.Next = newNode;
                Length++;
            }

            /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
            public void AddAtIndex(int index, int val)
            {
                if (index > Length || index < 0) return;
                else if (index == Length) AddAtTail(val);
                else
                {
                    MyLinkedListNode pre = GetNode(index - 1);
                    MyLinkedListNode newNode = new MyLinkedListNode(val);
                    if (pre == null)
                    {
                        newNode.Next = list;
                        list = newNode;
                    }
                    else
                    {
                        newNode.Next = pre.Next;
                        pre.Next = newNode;
                    }
                    Length++;
                }                
            }

            /** Delete the index-th node in the linked list, if the index is valid. */
            public void DeleteAtIndex(int index)
            {
                if (index >= Length || index < 0) return;

                MyLinkedListNode pre = GetNode(index - 1);
                if (pre == null)
                {
                    list = list.Next;
                }
                else
                {
                    pre.Next = pre.Next.Next;
                }
                Length--;
            }
        }

        #endregion

        #region T709 实现ToLowerCase()将字符串的大写字母转换为小写

        public string ToLowerCase(string str)
        {
            char[] chars = str.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] >= 'A' && chars[i] <= 'Z')
                    chars[i] = (char)(chars[i] + 32);
            }
            return new string(chars);
        }

        #endregion

        #region T717 1比特与2比特字符串的最后一个字符是否是1比特字符

        public bool IsOneBitCharacter(int[] bits)
        {
            for (int i = 0; i < bits.Length;)
            {
                if (i == bits.Length - 1 && bits[i] == 0) return true;
                if (bits[i] == 1)
                {
                    i += 2;
                }
                else
                {
                    i += 1;
                }
            }
            return false;
        }

        #endregion

        #region T720 词典中最长的单词

        //意思是问一个单词是否在词典中拥有所有的前缀
        public string LongestWord(string[] words)
        {
            Array.Sort(words);

            string longest = "";
            HashSet<string> prefixs = new HashSet<string>();
            foreach (string s in words)
            {
                if (s.Length == 1 || prefixs.Contains(s.Substring(0, s.Length - 1)))
                {
                    prefixs.Add(s);
                    if (s.Length > longest.Length)
                        longest = s;
                }
            }

            return longest;
        }

        #endregion

        #region T724 寻找数组的中心索引

        public int PivotIndex(int[] nums)
        {
            if (nums == null || nums.Length == 0) return -1;

            int[] leftSum = new int[nums.Length];
            int[] rightSum = new int[nums.Length];

            for (int i = 0; i < nums.Length; i++)
            {
                leftSum[i] = nums[i] + (i > 0 ? leftSum[i - 1] : 0);                
            }
            rightSum[0] = leftSum[nums.Length - 1];
            if (leftSum[0] == rightSum[0]) return 0;
            for (int i = 1; i < nums.Length; i++)
            {
                rightSum[i] = rightSum[i - 1] - nums[i - 1];
                if (leftSum[i] == rightSum[i]) return i;
            }
            return -1;
        }

        #endregion

        #region T728 自除数

        public IList<int> SelfDividingNumbers(int left, int right)
        {
            List<int> res = new List<int>();
            for (int i = left; i <= right; i++)
            {
                if (i < 10) res.Add(i);
                else
                {
                    int val = i;
                    while (val != 0)
                    {
                        int div = val % 10;                     
                        if (div == 0 || i % div != 0) break;
                        val = val / 10;
                    }
                    if (val == 0) res.Add(i);
                }
            }
            return res;
        }

        #endregion
    }
}
