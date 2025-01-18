/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsBalanced(TreeNode root) {
        if(root == null){
            return true;
        }

        int left = GetHeight(root.left);
        int right = GetHeight(root.right);

        return Math.Abs(left - right ) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode node){
        if(node == null){
            return 0;
        }

        int left = GetHeight(node.left) + 1;
        int right = GetHeight(node.right) + 1;

        return Math.Max(left, right);
    }
}

/*

1. get height of left tree and right tree recursively in getHeight(node)
2. check and return left <= right && IsBalanced(node.left) && IsBalanced(node.right) <= 1

*Height of tree: calculate from leaf to root

Time complexity: O(h)
Space complexity: O(h)

*/