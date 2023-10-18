/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        if(root == null)
            return "";

        StringBuilder sb = new StringBuilder();
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while(queue.Count > 0){
            int level = queue.Count;
            
            for(int i = 0; i < level; i++){
                TreeNode node = queue.Dequeue();
                
                if(node == null)
                    sb.Append("null,");
                else{
                    sb.Append(node.val.ToString()).Append(",");
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
            }
        }

        while(sb.Length > 0 && sb[sb.Length - 1] == ',')
            sb.Length--;

        return sb.ToString();
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        if(string.IsNullOrWhiteSpace(data))
            return null;

        string[] items = data.Split(",");

        if(items.Length == 0)
            return null;

        TreeNode root = new TreeNode();
        root.val = Convert.ToInt32(items[0]);
        
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int pos = 0;
        int count = items.Length;

        while(queue.Count > 0){
            TreeNode temp = queue.Dequeue();
            TreeNode left = null;
            TreeNode right = null;

            if(pos < count - 1 && items[++pos] != "null"){
                left = new TreeNode();
                left.val = Convert.ToInt32(items[pos]);
                temp.left = left;
                queue.Enqueue(left);
            }

            if(pos < count - 1 && items[++pos] != "null"){
                right = new TreeNode();
                right.val = Convert.ToInt32(items[pos]);
                temp.right = right;
                queue.Enqueue(right);
            }
        }
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));

/*

1. Create a class named `Codec` to implement the solution for serializing and deserializing a binary tree.

2. Define two methods within the `Codec` class:

   a. `serialize(TreeNode root)`: This method encodes (serializes) a binary tree into a single string.

   b. `deserialize(string data)`: This method decodes (deserializes) the encoded data back into a binary tree.

3. **Serialization** (`serialize` method):

   a. Check if the `root` node is null. If it is, return an empty string as there is no tree to serialize.

   b. Create a `StringBuilder` named `sb` to build the serialized string.

   c. Create a `Queue<TreeNode>` named `queue` and enqueue the root node into it.

   d. Use a `while` loop that continues as long as the `queue` is not empty:

      i. Get the current level size by checking the count of elements in the `queue` and store it in a variable named `level`.

      ii. Iterate through the elements in the current level:

         - Dequeue a node from the `queue`.
         - If the node is null, append the string "null," to the `sb`.
         - If the node is not null, append its value as a string followed by a comma to the `sb`. Then, enqueue its left and right children (if they exist) into the `queue`.

   e. After exiting the loop, remove any trailing commas from the `sb` by checking and adjusting the length of the `sb`.

   f. Return the `sb.ToString()` as the serialized string.

4. **Deserialization** (`deserialize` method):

   a. Check if the input `data` is null or empty. If it is, return null, indicating that there is no tree to deserialize.

   b. Split the input `data` string into an array of strings, `items`, using the comma as the delimiter.

   c. Create the root node of the binary tree and initialize its value using the first element in the `items` array, which is the root value. Convert it to an integer.

   d. Create a `Queue<TreeNode>` named `queue` and enqueue the root node.

   e. Initialize two variables: `pos` (position) to track the current position in the `items` array and `count` to store the total number of items.

   f. Use a `while` loop that continues as long as the `queue` is not empty:

      i. Dequeue a node from the `queue` and store it in a temporary variable, `temp`.

      ii. Create two variables, `left` and `right`, initially set to null. These variables will represent the left and right children of the current node.

      iii. Check if the current position (`pos`) is less than the total number of items (`count`), and the next item in the `items` array is not "null." If these conditions are met, create a new `TreeNode` for the left child, set its value from the `items` array, and link it to the left of the current node. Enqueue the left child into the `queue`.

      iv. Repeat the same process for the right child if the conditions are met.

   g. After completing the loop, the binary tree is fully reconstructed. Return the root node as the deserialized tree.

5. The `Codec` class can be instantiated and used as follows:

   - Create an instance of the `Codec` class: `Codec ser = new Codec();`
   - Use the `serialize` method to serialize a tree: `string serialized = ser.serialize(root);`
   - Create another instance of the `Codec` class: `Codec deser = new Codec();`
   - Use the `deserialize` method to deserialize the serialized data and reconstruct a tree: `TreeNode deserializedTree = deser.deserialize(serialized);`

*/