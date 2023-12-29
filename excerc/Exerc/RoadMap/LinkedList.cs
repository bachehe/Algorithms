using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class LinkedList
    {
        public void ReorderList(ListNode head)
        {
            ListNode slow = head, fast = head.next;

            //split
            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            //left is first halve, right is second
            ListNode right = slow.next, left = head;

            //break link between first and second half
            slow.next = null;

            //reverse right
            ListNode prev = null, curr = right;
            while (curr != null)
            {
                ListNode next = curr.next;
                curr.next = prev;
                prev = curr;
                curr = next;
            }

            //prev is head of reversed list, so set right to prev
            right = prev;

            //merge
            while (right != null)
            {
                //maintain reference of next nodes of left and right
                ListNode leftTemp = left.next, rightTemp = right.next;
                //set right pointer next to the left
                left.next = right;
                //now merge the maintained reference of left.next in front of right
                right.next = leftTemp;

                //move ahead
                left = leftTemp;
                right = rightTemp;
            }
        }

        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            ListNode list = new ListNode();
            ListNode current = list;

            while (list1 != null && list2 != null)
            {
                if (list1.val <= list2.val)
                {
                    current.next = list1;
                    list1 = list1.next;
                }
                else
                {
                    current.next = list2;
                    list2 = list2.next;
                }
                current = current.next;
            }

            if (list1 != null)
                current.next = list1;

            else
                current.next = list2;


            return list.next;
        }
        public static ListNode ReverseList(ListNode head)
        {
            ListNode node = null;

            while (head != null)
            {
                node = new ListNode(head.val, node);
                head = head.next;
            }

            return node;
        }
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2, int carry = 0)
        {
            if (l1 == null && l2 == null && carry == 0) return null;

            int total = (l1 != null ? l1.val : 0) + (l2 != null ? l2.val : 0) + carry;
            carry = total / 10;
            return new ListNode(total % 10, AddTwoNumbers(l1?.next, l2?.next, carry));
        }

    }
}
