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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {
        if(root == null)
            return false;

        if(IsIdentical(root, subRoot))
            return true;

        return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
    }

    private bool IsIdentical(TreeNode left, TreeNode right){
        if(left == null && right == null)
            return true;

        if(left == null || right == null)
            return false;

        if(left.val == right.val)
            return IsIdentical(left.left, right.left) && IsIdentical(left.right, right.right);

        return false;
    }
}