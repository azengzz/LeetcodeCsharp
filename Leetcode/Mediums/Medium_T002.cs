using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Mediums
{
    public class Medium_T002
    {
        public Medium_T002() { }

        #region T02 两数相加

        private class AddTwoHelper
        {
            public AddTwoHelper(int carry, ListNode ptr)
            {
                Carry = carry;
                CurrentPtr = ptr;
            }

            public int Carry { get; set; }
            public ListNode CurrentPtr { get; set; }
        }

        //不能用普通的整数类型来存储结果，因为这样用链表表示的数字可能是天文数字
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode head = new ListNode(int.MinValue);
            ListNode current = head;

            AddTwoHelper helper = new AddTwoHelper(0, current);
            
            while (l1 != null && l2 != null)
            {
                AddTwoNumberInList(l1, l2, helper);
                l1 = l1.next;
                l2 = l2.next;
            }

            //链表长度不一样时，把长的多出来那截加上
            while (l1 != null)
            {
                AddTwoNumberInList(l1, null, helper);
                l1 = l1.next;
            }

            while (l2 != null)
            {
                AddTwoNumberInList(l2, null, helper);
                l2 = l2.next;
            }

            if (helper.Carry != 0)
            {
                helper.CurrentPtr.next = new ListNode(helper.Carry);
            }

            return head.next;
        }

        private void AddTwoNumberInList(ListNode node1, ListNode node2, AddTwoHelper helper)
        {
            int sum = 0;

            if (node2 != null)
            {
                sum = node1.val + node2.val + helper.Carry;
            }
            else
            {
                sum = node1.val + helper.Carry;
            }

            helper.Carry = sum / 10;
            sum = sum % 10;
            helper.CurrentPtr.next = new ListNode(sum);
            helper.CurrentPtr = helper.CurrentPtr.next;
        }

        #endregion

        #region T03 无重复字符的最长子串

        public int LengthOfLongestSubstring(string s)
        {
            Dictionary<char, int> charLastIndex = new Dictionary<char, int>();
            int dontCare = 0;
            int counter = 0;
            int max = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (charLastIndex.ContainsKey(s[i]))
                {
                    if (counter > max) max = counter;

                    dontCare = charLastIndex[s[i]] > dontCare ? charLastIndex[s[i]] : dontCare;
                    counter = i - dontCare;                    
                }
                else
                {
                    counter++;
                }
                charLastIndex[s[i]] = i;
            }

            return max >= counter ? max : counter;
        }

        #endregion

        #region T05 最长回文子串

        public string LongestPalindrome(string s)
        {
            if (s == null || s.Length == 0) return "";

            int start = 0, end = 0;

            for (int i = 0; i < s.Length; i++)
            {
                int len1 = ExpandAroundCenter(s, i, i);
                int len2 = ExpandAroundCenter(s, i, i + 1);

                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end - start + 1);
        }

        private int ExpandAroundCenter(string s, int start, int end)
        {
            while (start >= 0 && end < s.Length)
            {
                if (s[start] != s[end]) break;

                --start;
                ++end;
            }

            return end - start - 1;
        }

        #endregion

        #region T06 Z字形变换

        public string Convert(string s, int numRows)
        {
            if (numRows < 2) return s;

            Dictionary<int, StringBuilder> dict = new Dictionary<int, StringBuilder>();

            bool up = true;
            bool down = false;
            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (up)
                {
                    ++count;
                    if (!dict.ContainsKey(count))
                    {
                        dict[count] = new StringBuilder();
                    }
                    dict[count].Append(s[i]);

                    if (count >= numRows)
                    {
                        count = numRows;
                        up = false;
                        down = true;
                    }
                }
                else if (down)
                {
                    --count;
                    if (!dict.ContainsKey(count))
                    {
                        dict[count] = new StringBuilder();
                    }
                    dict[count].Append(s[i]);

                    if (count <= 1)
                    {
                        count = 1;
                        up = true;
                        down = false;
                    }
                }
            }

            StringBuilder res = new StringBuilder();
            for (int i = 1; i <= numRows && dict.ContainsKey(i); i++)
            {
                res.Append(dict[i]);
            }

            return res.ToString();
        }

        #endregion

        #region T08 字符串转换整数

        public int MyAtoi(string str)
        {
            if (str == null || str.Length == 0)
            {
                return 0;
            }

            if (str[0] != ' ' && str[0] != '+' && str[0] != '-'
            && !(str[0] >= '0' && str[0] <= '9'))
            {
                return 0;
            }

            int index = 0;
            while (index < str.Length && str[index] == ' ')
            {
                ++index;
            }

            long res = 0;
            bool isPositive = true;

            if (index < str.Length && (str[index] == '-' || str[index] == '+'))
            {
                isPositive = str[index] == '-' ? false : true;
                ++index;
            }

            for (int i = index; i < str.Length; ++i)
            {
                if (str[i] >= '0' && str[i] <= '9')
                {
                    res *= 10;
                    res += (long)(str[i] - '0');

                    if (res > (long)int.MaxValue)
                    {
                        if (isPositive)
                        {
                            return int.MaxValue;
                        }
                        else
                        {
                            if (res > (long)int.MaxValue + 1)
                            {
                                return int.MinValue;
                            }
                        }
                    }
                }
                else
                {
                    return isPositive ? (int)res : (int)res * -1;
                }
            }

            return isPositive ? (int)res : (int)res * -1;
        }

        #endregion

        #region T11 盛水最多的容器

        public int MaxArea(int[] height)
        {
            int max = int.MinValue;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                int lower = height[left] <= height[right] ? left : right;
                int width = right - left;

                int area = height[lower] * width;

                max = area > max ? area : max;

                if (lower == left)
                {
                    ++left;
                }
                else
                {
                    --right;
                }
            }

            return max;
        }

        #endregion

        #region T12 整数转换为罗马数字

        public string IntToRoman(int num)
        {

            StringBuilder res = new StringBuilder();

            if (num >= 1000)
            {
                int digit = num / 1000;

                res.Append(ConvertHelper(digit, "", "", "M"));

                num %= 1000;
            }

            if (num >= 100 && num <= 999)
            {
                int digit = num / 100;

                res.Append(ConvertHelper(digit, "M", "D", "C"));

                num %= 100;
            }

            if (num >= 10 && num <= 99)
            {
                int digit = num / 10;

                res.Append(ConvertHelper(digit, "C", "L", "X"));

                num %= 10;
            }

            res.Append(ConvertHelper(num, "X", "V", "I"));

            return res.ToString();
        }

        private string ConvertHelper(int digit, string ten, string five, string one)
        {
            string res = "";

            if (digit == 9)
            {
                res += one + ten;
            }
            else if (digit == 4)
            {
                res += one + five;
            }
            else
            {
                if (digit >= 5)
                {
                    res += five;
                    digit -= 5;
                }
                while (digit > 0)
                {
                    res += one;
                    --digit;
                }
            }

            return res;
        }

        #endregion

        #region T15 三数之和

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> res = new List<IList<int>>();

            if (nums.Length < 3)
            {
                return res;
            }

            Array.Sort(nums);

            for (int left = 0; left < nums.Length; ++left)
            {
                if (left != 0 && nums[left] == nums[left - 1])    //跳过重复项
                    continue;

                int mid = left + 1;
                int right = nums.Length - 1;

                while (mid < right)
                {
                    if (nums[left] + nums[mid] + nums[right] == 0)
                    {
                        res.Add(new List<int> { nums[left], nums[mid], nums[right] });

                        //忽略重复项
                        ++mid;
                        --right;

                        while (mid < right && nums[mid] == nums[mid - 1])
                        {
                            ++mid;
                        }
                        while (mid < right && nums[right] == nums[right + 1])
                        {
                            --right;
                        }
                    }
                    else if (nums[left] + nums[mid] + nums[right] > 0)
                    {
                        --right;
                    }
                    else
                    {
                        ++mid;
                    }
                }
            }

            return res;
        }

        #endregion

        #region T16 最接近的三数之和

        public int ThreeSumClosest(int[] nums, int target)
        {
            if (nums.Length < 3)
            {
                return 0;
            }

            Array.Sort(nums);

            int minDistance = int.MaxValue;
            int res = 0;

            for (int i = 0; i < nums.Length - 2; ++i)
            {
                int left = i + 1;
                int right = nums.Length - 1;

                int sum = 0;

                while (left < right)
                {
                    sum = nums[left] + nums[right] + nums[i];

                    int distance = Math.Abs(target - sum);

                    if (minDistance > distance)
                    {
                        minDistance = distance;
                        res = sum;
                    }

                    if (sum == target)
                    {
                        return res;
                    }
                    else if (sum < target)
                    {
                        ++left;
                    }
                    else
                    {
                        --right;
                    }
                }
            }

            return res;
        }

        #endregion

        #region T17 电话号码的字母组合

        public IList<string> LetterCombinations(string digits)
        {
            Dictionary<char, List<char>> dict = new Dictionary<char, List<char>>
            {
                {'0', new List<char> {' '}},
                {'1', new List<char> {'*'}},
                {'2', new List<char> {'a', 'b', 'c'}},
                {'3', new List<char> {'d', 'e', 'f'}},
                {'4', new List<char> {'g', 'h', 'i'}},
                {'5', new List<char> {'j', 'k', 'l'}},
                {'6', new List<char> {'m', 'n', 'o'}},
                {'7', new List<char> {'p', 'q', 'r', 's'}},
                {'8', new List<char> {'t', 'u', 'v'}},
                {'9', new List<char> {'w', 'x', 'y', 'z'}},
            };

            if (digits == null || digits.Length == 0)
            {
                return new List<string>();
            }

            Queue<string> queue = new Queue<string>();

            queue.Enqueue("");

            for (int i = 0; i < digits.Length; ++i)
            {
                int count = queue.Count;
                List<char> letters = dict[digits[i]];

                while (count-- > 0)
                {
                    string str = queue.Dequeue();

                    foreach (char ch in letters)
                    {
                        queue.Enqueue(str + ch);
                    }
                }
            }

            return queue.ToList();
        }

        #endregion

        #region T18 四数之和

        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            List<IList<int>> res = new List<IList<int>>();

            if (nums.Length < 4)
            {
                return res;
            }

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 3; ++i)
            {
                for (int j = i + 1; j < nums.Length - 2; ++j)
                {
                    int left = j + 1;
                    int right = nums.Length - 1;
                    int sum = 0;

                    while (left < right)
                    {
                        sum = nums[i] + nums[j] + nums[left] + nums[right];

                        if (sum == target)
                        {
                            List<int> found = new List<int> { nums[i], nums[j], nums[left], nums[right] };
                            res.Add(found);

                            ++left;
                            --right;

                            //跳过相同项
                            while (left < right && found[2] == nums[left])
                            {
                                ++left;
                            }
                            while (left < right && found[3] == nums[right])
                            {
                                --right;
                            }
                        }
                        else if (sum < target)
                        {
                            ++left;
                        }
                        else
                        {
                            --right;
                        }
                    }

                    while (j < nums.Length - 2 && nums[j] == nums[j + 1])    //跳过相同项
                    {
                        ++j;
                    }
                }

                while (i < nums.Length - 3 && nums[i] == nums[i + 1])    //跳过相同项
                {
                    ++i;
                }
            }

            return res;
        }

        #endregion

        #region T19 删除链表的倒数第N个节点

        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head == null || n == 0)
            {
                return head;
            }

            ListNode fast = head;
            int count = n;

            while (count > 0 && fast != null)
            {
                --count;
                fast = fast.next;
            }

            if (fast == null)
            {
                return head.next;
            }

            ListNode slow = head;

            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }

            slow.next = slow.next.next;

            return head;
        }

        #endregion

        #region T24 两两交换链表中的节点

        public ListNode SwapPairs(ListNode head)
        {
            if (head == null)
            {
                return head;
            }

            ListNode pNew = new ListNode(0);
            pNew.next = head;

            ListNode pre = pNew;

            ListNode ptr1 = head;
            ListNode ptr2 = ptr1.next;

            while (ptr1 != null)
            {
                if (ptr2 == null)
                {
                    return pNew.next;
                }

                ptr1.next = ptr2.next;
                ptr2.next = ptr1;

                pre.next = ptr2;
                pre = ptr1;

                ptr1 = ptr1.next;

                if (ptr1 == null)
                {
                    return pNew.next;
                }

                ptr2 = ptr1.next;
            }

            return pNew.next;
        }

        #endregion

        #region T29 两数相除

        public int Divide(int dividend, int divisor)
        {

            bool isNegative = (dividend < 0) ^ (divisor < 0);

            long ldividend = Math.Abs((long)dividend);
            long ldivisor = Math.Abs((long)divisor);

            if (ldivisor == 0)
            {
                return int.MaxValue;
            }

            if (ldividend == 0 || (ldividend < ldivisor))
            {
                return 0;
            }

            long result = Divide(ldividend, ldivisor);

            if (result > int.MaxValue)
            {
                return isNegative ? int.MinValue : int.MaxValue;
            }

            return (int)(isNegative ? -result : result);

        }

        private long Divide(long dividend, long divisor)
        {
            if (dividend < divisor)
            {
                return 0;
            }

            long sum = divisor;
            long result = 1;

            while (dividend >= (sum << 1))
            {
                sum <<= 1;
                result += result;
            }

            return result + Divide(dividend - sum, divisor);
        }

        #endregion

        #region T31 下一个排列

        public void NextPermutation(int[] nums)
        {

            int ptr = nums.Length - 2;

            while (ptr >= 0 && nums[ptr + 1] <= nums[ptr])
            {
                --ptr;
            }

            if (ptr >= 0)
            {
                int next = nums.Length - 1;

                while (next >= 0 && nums[next] <= nums[ptr])
                {
                    --next;
                }

                SwapNums(nums, ptr, next);
            }

            ReverseNums(nums, ptr + 1);
        }

        private void SwapNums(int[] nums, int aIdx, int bIdx)
        {
            int tmp = nums[aIdx];
            nums[aIdx] = nums[bIdx];
            nums[bIdx] = tmp;
        }

        private void ReverseNums(int[] nums, int start)
        {
            int end = nums.Length - 1;

            while (start < end)
            {
                SwapNums(nums, start, end);
                ++start;
                --end;
            }
        }

        #endregion
    }
}
