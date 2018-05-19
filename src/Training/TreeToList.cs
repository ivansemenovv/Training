using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class TreeToList
    {

        enum HeadType
        {
            left,
            right,
            root
        }

        public static void RunTestCases()
        {
            var tree = AVLTree.CreateTestTree();
            Node list = GetListRoot(ConvertToList(tree.root, HeadType.root));
            PrintList(list);
        }

        static void PrintList(Node root)
        {
            Console.WriteLine("List: ");
            while(root != null)
            {
                Console.Write("{0} -> ", root.Value);
                root = root.right;
            }
        }

        static Node GetListRoot(Node root)
        {
            while (root.left != null)
            {
                root = root.left;
            }
            return root;
        }

        static Node ConvertToList(Node root, HeadType headType)
        {
            if (root.left == null && root.right == null)
            {
                return root;
            }
            
            if (root.left != null)
            {
                root.left = ConvertToList(root.left, HeadType.right);
                root.left.right = root;
            }

            if (root.right != null)
            {
                root.right = ConvertToList(root.right, HeadType.left);
                root.right.left = root;
            }

            if (headType == HeadType.root)
                return root;

            if (headType == HeadType.left)
            {
                if (root.left != null)
                    return root.left;
                return root;
            }
            else
            {
                if (root.right != null)
                    return root.right;
                return root;
            }
        }

    }
}
