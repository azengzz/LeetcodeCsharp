using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    public class ListNodeHelper
    {
        public static ListNode CreateLinkedListByArray(int[] elements)
        {
            ListNode node0 = new ListNode(elements[0]) { next = null };
            ListNode head = node0;
            ListNode walk = head;
            for (int i = 1; i < elements.Length; i++)
            {
                ListNode node = new ListNode(elements[i]) { next = null };
                walk.next = node;
                walk = walk.next;
            }
            return head;
        }

        public static int[] GetElementsFromLinkedList(ListNode head)
        {
            List<int> elements = new List<int>();
            while (head != null)
            {
                elements.Add(head.val);
                head = head.next;
            }
            return elements.ToArray();
        }     
    }

    public class CompareHelper
    {
        public static bool CompareArrays(int[] arr1, int[] arr2)
        {
            if (arr1.Length != arr2.Length) return false;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != arr2[i]) return false;
            }
            return true;
        }
    }
}
