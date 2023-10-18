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
        if(root == null)
            return true;

        int left = GetHeight(root.left);
        int right = GetHeight(root.right);
        return Math.Abs(left - right) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode root){
        if(root == null)
            return 0;

        int left = GetHeight(root.left) + 1;
        int right = GetHeight(root.right) + 1;
        return Math.Max(left, right);
    }
}