/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
        ListNode dummy = new ListNode(0);
        dummy.next = head;
        ListNode left = dummy;
        ListNode right = dummy;

        // move right away from left to create a gap of n
        for(int i = 1; i <= n + 1; i++){
            right = right.next;
        }

        // move right to end and maintain gap of n
        while(right != null){
            right = right.next;
            left = left.next;
        }

        // remove the nth node
        left.next = left.next.next;

        return dummy.next;
    }
}