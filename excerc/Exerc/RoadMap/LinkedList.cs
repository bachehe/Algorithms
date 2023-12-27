using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace excerc.Exerc.RoadMap
{
    public class LinkedList
    {
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
            //nodes
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
