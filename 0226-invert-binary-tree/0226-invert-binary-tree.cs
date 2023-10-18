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
    public TreeNode InvertTree(TreeNode root) {
        // recursive
        /*
        if(root == null)
            return root;
        TreeNode temp = InvertTree(root.right);
        root.right = InvertTree(root.left);
        root.left = temp;
        return root;
        */

        // iterative

        if(root == null)
            return null;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while(stack.Count > 0){
            TreeNode temp = stack.Pop();
            TreeNode left = temp.left;
            temp.left = temp.right;
            temp.right = left;

            if(temp.left != null)
                stack.Push(temp.left);

            if(temp.right != null)
                stack.Push(temp.right);
        }

        return root;
    }
}

/*

1. Create a class named `Solution` to implement the solution for inverting a binary tree.

2. Define a method `InvertTree` that takes a binary tree node `root` as input and returns the root of the inverted tree.

3. First, check if the `root` is null. If the `root` is null, there is nothing to invert, so return null.

4. The code provides both recursive and iterative approaches for inverting the binary tree. We'll describe both methods:

   a. **Recursive Approach**:
      - If the `root` is not null, perform the following steps recursively:
        - Swap the `left` and `right` subtrees of the current node. This effectively inverts the current node.
        - Recursively call the `InvertTree` method for the `right` subtree and store the result in a temporary variable `temp`.
        - Update the `right` subtree of the current node with the result of the recursive call.
        - Update the `left` subtree of the current node with the value stored in `temp`.
        - Return the inverted `root`.

   b. **Iterative Approach**:
      - If the `root` is not null, create an empty stack named `stack` to help with the iterative process.

      - Push the `root` node onto the `stack`.

      - Enter a while loop that continues as long as the `stack` is not empty.

      - Inside the loop, pop a node from the `stack` and store it in a temporary variable `temp`.

      - Swap the `left` and `right` subtrees of the current node `temp`.

      - If the `left` subtree of `temp` is not null, push it onto the `stack`.

      - If the `right` subtree of `temp` is not null, push it onto the `stack`.

      - Continue this process until the `stack` is empty.

      - After the loop, the binary tree will be inverted in place.

5. Regardless of whether the recursive or iterative approach is used, return the `root` node of the inverted binary tree.

*/