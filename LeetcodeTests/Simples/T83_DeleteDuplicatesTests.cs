using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leetcode.Simples;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leetcode;

namespace Leetcode.Simples.Tests
{
    [TestClass()]
    public class T83_DeleteDuplicatesTests
    {
        //private ListNode CreateLinkedListByArray(int[] elements)
        //{
        //    ListNode node0 = new ListNode(elements[0]) { next = null };
        //    ListNode head = node0;
        //    ListNode walk = head;
        //    for (int i = 1; i < elements.Length; i++)
        //    {
        //        ListNode node = new ListNode(elements[i]) { next = null };
        //        walk.next = node;
        //        walk = walk.next;
        //    }
        //    return head;
        //}

        //private int[] GetElementsFromLinkedList(ListNode head)
        //{
        //    List<int> elements = new List<int>();
        //    while(head != null)
        //    {
        //        elements.Add(head.val);
        //        head = head.next;
        //    }
        //    return elements.ToArray();
        //}

        //private bool CompareArrays(int[] arr1, int[] arr2)
        //{
        //    if (arr1.Length != arr2.Length) return false;
        //    for (int i = 0; i < arr1.Length; i++)
        //    {
        //        if (arr1[i] != arr2[i]) return false;
        //    }
        //    return true;
        //}

        T83_DeleteDuplicates t83 = new T83_DeleteDuplicates();

        [TestMethod()]
        public void DeleteDuplicatesTest_1()
        {
            int[] list = { 1, 1, 2 };
            ListNode head = ListNodeHelper.CreateLinkedListByArray(list);
            t83.DeleteDuplicates(head);
            int[] result = ListNodeHelper.GetElementsFromLinkedList(head);
            int[] expect = { 1, 2 };
            Assert.IsTrue(CompareHelper.CompareArrays(result, expect));
        }

        [TestMethod()]
        public void DeleteDuplicatesTest_2()
        {
            int[] list = { 1, 1, 2, 3, 3 };
            ListNode head = ListNodeHelper.CreateLinkedListByArray(list);
            t83.DeleteDuplicates(head);
            int[] result = ListNodeHelper.GetElementsFromLinkedList(head);
            int[] expect = { 1, 2, 3 };
            Assert.IsTrue(CompareHelper.CompareArrays(result, expect));
        }

        [TestMethod()]
        public void DeleteDuplicatesTest_3()
        {
            int[] list = { 1, 1, 1, 2, 2, 3, 3, 3, 5 };
            ListNode head = ListNodeHelper.CreateLinkedListByArray(list);
            t83.DeleteDuplicates(head);
            int[] result = ListNodeHelper.GetElementsFromLinkedList(head);
            int[] expect = { 1, 2, 3, 5 };
            Assert.IsTrue(CompareHelper.CompareArrays(result, expect));
        }

        [TestMethod()]
        public void DeleteDuplicatesTest_null()
        {
            ListNode head = null;
            t83.DeleteDuplicates(head);
            int[] result = ListNodeHelper.GetElementsFromLinkedList(head);
            int[] expect = { };
            Assert.IsTrue(CompareHelper.CompareArrays(result, expect));
        }

        [TestMethod()]
        public void DeleteDuplicatesTest_single()
        {
            int[] list = { 1 };
            ListNode head = ListNodeHelper.CreateLinkedListByArray(list);
            t83.DeleteDuplicates(head);
            int[] result = ListNodeHelper.GetElementsFromLinkedList(head);
            int[] expect = { 1 };
            Assert.IsTrue(CompareHelper.CompareArrays(result, expect));
        }
    }
}