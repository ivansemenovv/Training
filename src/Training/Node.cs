using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Node
    {
        public Node left;
        public Node right;
        public int Value = 0;

        public Node(int v)
        {
            this.Value = v;
        }
    }
}
