using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode;

namespace Leetcode.Simples
{
    public class T83_DeleteDuplicates
    {
        /*
            Given a sorted linked list, delete all duplicates such that each element appear only once.

            Example 1:
            Input: 1->1->2
            Output: 1->2

            Example 2:
            Input: 1->1->2->3->3
            Output: 1->2->3
         */

        public T83_DeleteDuplicates()
        { }

        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;

            ListNode slowPtr = head, fastPtr = head.next;
            while (fastPtr != null)
            {
                if (fastPtr.val == slowPtr.val)
                {
                    ListNode deletedPtr = fastPtr;
                    fastPtr = fastPtr.next;
                    slowPtr.next = fastPtr;
                    deletedPtr.next = null;
                }
                else
                {
                    fastPtr = fastPtr.next;
                    slowPtr = slowPtr.next;
                }
            }

            return head;
        }
    }
}


/*
 更加简单的解答：
 public ListNode DeleteDuplicates(ListNode head)
{
    ListNode current = head;
    while (current != null && current.next != null)
    { 
        if (current.val == current.next.val)
        {
            current.next = current.next.next;
        }
        else
        {
            current = current.next;
        }
    }

    return head;
}
 */
