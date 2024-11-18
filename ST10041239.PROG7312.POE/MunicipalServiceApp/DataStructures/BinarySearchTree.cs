using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.DataStructures
{
    /// <summary>
    /// Feature 1 - Binary Search Tree
    /// Implementation of Binary Search Tree Data Data Structure for Service Requests
    /// Builds on top of TreeNode class.
    /// </summary>
    internal class BinarySearchTree
    {
        private TreeNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        // Method to insert a new service request into the tree
        public void Insert(ServiceRequest request)
        {
            root = InsertRecursive(root, request);
        }

        // Recursive method to insert a new service request
        private TreeNode InsertRecursive(TreeNode node, ServiceRequest request)
        {
            if (node == null)
            {
                return new TreeNode(request); // Create a new node if position is found
            }

            if (request.Id < node.Request.Id) // If ID is less, go left
            {
                node.Left = InsertRecursive(node.Left, request);
            }
            else if (request.Id > node.Request.Id) // If ID is greater, go right
            {
                node.Right = InsertRecursive(node.Right, request);
            }

            return node; // Return unchanged node pointer
        }

        // Method to search for a service request by ID
        public ServiceRequest SearchById(int id)
        {
            return SearchByIdRecursive(root, id);
        }

        // Recursive method to search for a service request by ID
        private ServiceRequest SearchByIdRecursive(TreeNode node, int id)
        {
            if (node == null || node.Request.Id == id) // Base case: found or reached end
            {
                return node?.Request; // Return the found request or null if not found
            }

            if (id < node.Request.Id) // If ID is less, search left
            {
                return SearchByIdRecursive(node.Left, id);
            }

            return SearchByIdRecursive(node.Right, id); // Otherwise search right
        }
    }
}
