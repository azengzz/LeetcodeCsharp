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
    }
}
