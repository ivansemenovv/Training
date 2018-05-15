using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class TreeSerializer
    {
        private const string Marker = "#";

        public static void RunTestCases()
        {
            var tree = AVLTree.CreateTestTree();
            var strTree = TreeSerializer.Serialize(tree.root);
            Console.WriteLine("Tree is serialized: {0}", strTree);
            var node = TreeSerializer.Deserialize(strTree);
            var strTree1 = TreeSerializer.Serialize(node);
            Console.WriteLine("Tree is serialized again after deserialization: {0}", strTree1);
            TestHelper.IsEquals(strTree, strTree1);
        }

        public static String Serialize(Node root)
        {
            if (root == null)
                return Marker;

            StringBuilder buider = new StringBuilder();
            buider.Append(root.Value);
            buider.Append(Serialize(root.left));
            buider.Append(Serialize(root.right));
            return buider.ToString();
        }

        public static Node Deserialize(string serializedTree)
        {
            int startIndex = 0;
            return Deserialize(serializedTree, ref startIndex);
        }

        private static Node Deserialize(string serializedTree, ref int startIndex)
        {
            var strValue = serializedTree[startIndex++];
            if (strValue.ToString() == Marker)
            {
                return null;
            }

            int value;
            int.TryParse(strValue.ToString(), out value);
            var node = new Node(value);
            node.left = Deserialize(serializedTree, ref startIndex);
            node.right = Deserialize(serializedTree, ref startIndex);
            return node;
        }
    }
}
