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
    }
}
