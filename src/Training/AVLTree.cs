using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class AVLTree
    {
        public Node root = null;

        public void Insert(int v)
        {
            root = Insert(this.root, v);
            Console.WriteLine("Value {0} is inserted", v);
        }

        private int setHeight(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            return 1 + Math.Max((root.left != null ? root.left.height : 0),
                                (root.right != null ? root.right.height : 0));
        }

        private int getBalance(Node rootLeft, Node rootRight)
        {
            return height(rootLeft) - height(rootRight);
        }

        private int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                return root.height;
            }
        }
        
        Node RotateLeft(Node root)
        {
            Node newRoot = root.right;
            root.right = newRoot.left;
            newRoot.left = root;
            root.height = setHeight(root);
            newRoot.height = setHeight(newRoot);
            return newRoot;
        }


        Node RotateRight(Node root)
        {
            Node newRoot = root.left;
            root.left = newRoot.right;
            newRoot.right = root;
            root.height = setHeight(root);
            newRoot.height = setHeight(newRoot);
            return newRoot;
        }

        private Node Insert(Node root, int v)
        {
            if (root == null)
                return new Node(v);

            if (root.Value > v)
            {
                root.left = Insert(root.left, v);
            }
            else
            {
                root.right = Insert(root.right, v);
            }

            int balance = getBalance(root.left, root.right);

            if (balance > 1)
            {
                // left case
                if (height(root.left == null ? null : root.left.left) >= height(root.left == null ? null : root.left.right))
                {
                    root = RotateRight(root);
                }
                else
                {
                    root.left = RotateLeft(root.left);
                    root = RotateRight(root);
                }

            }
            else if (balance < -1)
            {
                // rigth case
                if (height(root.left == null ? null : root.left.right) >= height(root.left == null ? null : root.left.left))
                {
                    root = RotateLeft(root);
                }
                else
                {
                    root.right = RotateRight(root.right);
                    root = RotateLeft(root);
                }

            }
            else
            {
                root.height = setHeight(root);
            }

            return root;
        }

        public static AVLTree CreateTestTree()
        {
            var avl = new AVLTree();
            avl.Insert(0);
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(3);
            avl.Insert(4);
            avl.Insert(5);
            avl.Insert(6);
            avl.Insert(7);

            return avl;
        }

    }
}
