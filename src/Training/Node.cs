namespace Training
{
    class Node
    {
        public int Value;
        public int height = 1;

        public Node left = null;
        public Node right = null;

        public Node(int v)
        {
            this.Value = v;
        }
    }
}
