using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode.Simples
{
    public class T141_LinkedListCircle
    {
        public T141_LinkedListCircle()
        {
        }

        //T141 判断单向链表有没有环
        public bool HasCycle(SingleListNode head)
        {
            if (head == null || head.next == null) return false;

            SingleListNode slow = head, fast = head.next;  //使用快慢指针，如果快指针追上了慢指针，说明产生了环

            while (fast != slow)
            {
                if (fast == null || fast.next == null) return false;
                fast = fast.next.next;
                slow = slow.next;
            }
            return true;
        }

        //T160 两个链表有可能是相交的。如果它们确实相交，返回相交的起始节点
        // 假设：链表均没有环状
        // 要求：两个链表要保持原有结构；如果链表没有相交，则返回null
        public SingleListNode GetIntersectionNode(SingleListNode headA, SingleListNode headB)
        {
            //使用字典实现---------------------------------------------------------------------
            //if (headA == null || headB == null) return null;

            //Dictionary<int, SingleListNode> dictOfListA = new Dictionary<int, SingleListNode>();
            //SingleListNode walk = headA;
            //for (int i = 0; walk != null; i++)
            //{
            //    dictOfListA.Add(i, walk);
            //    walk = walk.next;
            //}
            //walk = headB;
            //while (walk != null)
            //{
            //    if (dictOfListA.ContainsValue(walk))
            //    {
            //        return walk;
            //    }
            //    walk = walk.next;
            //}
            //return null;

            //不使用额外空间的实现--------------------------------------------------------------
            //这个解法在遇到大量数据的时候会超出时间限制……………………
            //if (headA == null || headB == null) return null;

            //SingleListNode pa = headA;
            //SingleListNode pb = headB;
            //while (pa != null)
            //{
            //    pb = headB;
            //    SingleListNode paa = pa.next;
            //    pa.next = null;    //把链表A从这个位置断开，用于观察链表B是否被阻断
            //    while (pb.next != null) pb = pb.next;    //链表B遍历
            //    pa.next = paa;    //把链表A断开的地方连上
            //    if (pa == pb) return pa;    //如果链表B遍历停止且指向链表A断开的位置，则断开的位置就是相交点
            //    else
            //    {
            //        pa = pa.next;
            //    }
            //}
            //return null;

            //能够通过大量数据测试的实现--------------------------------------------------------------
            //由于两个链表的长度可能不同，所以移动较长的链表指针向前走几个节点，到达和较短的链表同样的长度
            //再逐个比较
            if (headA == null || headB == null) return null;

            int lengthA = 0, lengthB = 0;
            SingleListNode pa = headA, pb = headB;
            while (pa != null)
            {
                ++lengthA;
                pa = pa.next;
            }
            while (pb != null)
            {
                ++lengthB;
                pb = pb.next;
            }

            pa = headA;
            pb = headB;
            int diff = lengthA >= lengthB ? lengthA - lengthB : lengthB - lengthA;
            if (lengthA - lengthB > 0)
            {
                while (diff-- > 0) pa = pa.next;
            }
            else if (lengthB - lengthA > 0)
            {
                while (diff-- > 0) pb = pb.next;
            }

            while (pa != null && pb != null)
            {
                if (pa == pb) return pa;
                pa = pa.next;
                pb = pb.next;
            }
            return null;

            //评论区里的一种飘逸的实现--------------------------------------------------------------          
            //定义两个指针, 第一轮让两个到达末尾的节点指向另一个链表的头部, 最后如果相遇则为交点(在第一轮移动中恰好抹除了长度差)
            //两个指针等于移动了相同的距离, 有交点就返回, 无交点就是各走了两条指针的长度

            //if (headA == null || headB == null) return null;
            //SingleListNode pA = headA, pB = headB;
            // 在这里第一轮体现在pA和pB第一次到达尾部会移向另一链表的表头, 而第二轮体现在如果pA或pB相交就返回交点, 不相交最后就是null==null
            //while (pA != pB)
            //{
            //    pA = pA == null ? headB : pA.next;
            //    pB = pB == null ? headA : pB.next;
            //}
            //return pA;
        
        }
    }
}
