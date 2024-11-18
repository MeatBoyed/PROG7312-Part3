using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.DataStructures
{
    internal class TreeNode
    {
        public ServiceRequest Request { get; set; } // The service request stored in the node
        public TreeNode Left { get; set; } // Reference to the left child
        public TreeNode Right { get; set; } // Reference to the right child

        public TreeNode(ServiceRequest request)
        {
            Request = request;
            Left = null;
            Right = null;
        }
    }
}
