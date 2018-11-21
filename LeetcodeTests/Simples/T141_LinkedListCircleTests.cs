using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode.Simples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples.Tests
{
    [TestClass()]
    public class T141_LinkedListCircleTests
    {
        T141_LinkedListCircle t141 = new T141_LinkedListCircle();

        [TestMethod()]
        public void GetIntersectionNodeTest_1()
        {
            int[] a = { 1, 2 };
            int[] b = { 3, 4, 5 };
            SingleListNode headA = LinkedListHelper.CreateSingleListedListByArray(a);
            SingleListNode headB = LinkedListHelper.CreateSingleListedListByArray(b);

            SingleListNode lastA = headA;
            SingleListNode lastB = headB;
            while (lastA.next != null)
            {
                lastA = lastA.next;
            }
            while (lastB.next != null)
            {
                lastB = lastB.next;
            }

            int[] same = { 6, 7, 8 };
            for (int i = 0; i < same.Length; i++)
            {
                SingleListNode node = new SingleListNode(same[i]);
                lastA.next = node;              
                lastB.next = node;
                lastA = lastA.next;
                lastB = lastB.next;
            }
            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result.val == 6);
        }

        [TestMethod()]
        public void GetIntersectionNodeTest_2()   //B链表只包含A链表的最后一个节点
        {
            int[] a = { 1, 2, 3, 4, 5, 7 };
            SingleListNode headA = LinkedListHelper.CreateSingleListedListByArray(a);
            SingleListNode headB = null;

            SingleListNode lastA = headA;
            while (lastA.next != null)
            {
                lastA = lastA.next;
            }
            headB = lastA;    //B链表只包含A链表的最后一个节点

            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result.val == 7);
        }

        [TestMethod()]
        public void GetIntersectionNodeTest_3()   //A链表只有一个节点，即是B链表的最后一个节点
        {
            int[] b = { 1, 2, 3, 4, 5, 8 };
            SingleListNode headB = LinkedListHelper.CreateSingleListedListByArray(b);
            SingleListNode headA = null;

            SingleListNode lastB = headB;
            while (lastB.next != null)
            {
                lastB = lastB.next;
            }

            int[] same = { 9 };
            SingleListNode node = new SingleListNode(same[0]);
            lastB.next = node;
            headA = node;

            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result.val == 9);
        }

        [TestMethod()]
        public void GetIntersectionNodeTest_4()   //两条链表其实是同一条
        {
            int[] ab = { 1, 2, 3, 4, 5, 8 };
            SingleListNode headB = LinkedListHelper.CreateSingleListedListByArray(ab);
            SingleListNode headA = headB;

            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result.val == 1);
        }

        [TestMethod()]
        public void GetIntersectionNodeTest_5()    //没有交点
        {
            int[] a = { 1, 2 };
            int[] b = { 3, 4, 5 };
            SingleListNode headA = LinkedListHelper.CreateSingleListedListByArray(a);
            SingleListNode headB = LinkedListHelper.CreateSingleListedListByArray(b);

            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result == null);
        }

        [TestMethod()]
        public void GetIntersectionNodeTest_6()    //节点的值都相同，但没有交点
        {
            int[] a = { 1, 2, 3, 5, 6};
            SingleListNode headA = LinkedListHelper.CreateSingleListedListByArray(a);
            SingleListNode headB = LinkedListHelper.CreateSingleListedListByArray(a);

            SingleListNode result = t141.GetIntersectionNode(headA, headB);
            Assert.IsTrue(result == null);
        }
    }
}