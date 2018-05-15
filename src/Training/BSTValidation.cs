namespace Training
{
    class BSTValidation
    {
        public static void RunTestCases()
        {
            var r = IsValid(AVLTree.CreateTestTree().root);
            TestHelper.IsEquals(r, true);

            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(0);
            r = IsValid(root);
            TestHelper.IsEquals(r, false);
        }

        public static bool IsValid(Node root)
        {
            if (root == null) return true;
            if (root.left != null && root.Value < root.left.Value)
                return false;
            if (root.right != null && root.Value > root.right.Value)
                return false;
            return IsValid(root.left) && IsValid(root.right);
        }
    }
}
