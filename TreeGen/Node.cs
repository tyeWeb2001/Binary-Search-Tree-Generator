using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeGen
{
    public class Node
    {
        public int leafNumber;
        public Node leftNode;
        public Node rightNode;


        public Node(int LeafNumber)
        {
            this.leafNumber = LeafNumber;
            leftNode = rightNode = null;
            //this.leftNode = null;
            //this.rightNode = null;
        }

    }




}
