using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.DataStructures
{
    /// <summary>
    /// Feature 2 - Binary Tree Data Structure for Service Requests
    /// </summary>
    internal class BinaryTree
    {
        private TreeNode root;

        public BinaryTree()
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

            // For simplicity, we can add service requests based on their categories
            // You can modify this logic based on your specific requirements
            if (string.Compare(request.Category, node.Request.Category) < 0) // If category is less, go left
            {
                node.Left = InsertRecursive(node.Left, request);
            }
            else // If category is greater or equal, go right
            {
                node.Right = InsertRecursive(node.Right, request);
            }

            return node; // Return unchanged node pointer
        }

        // Method to filter service requests by category
        public List<ServiceRequest> FilterByCategory(string category)
        {
            var result = new List<ServiceRequest>();
            FilterByCategoryRecursive(root, category, result);
            return result;
        }

        // Recursive method to filter by category
        private void FilterByCategoryRecursive(TreeNode node, string category, List<ServiceRequest> result)
        {
            if (node != null)
            {
                // Check if the current node's request matches the category
                if (node.Request.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(node.Request); // Add matching request to results
                }

                // Traverse left and right subtrees
                FilterByCategoryRecursive(node.Left, category, result);
                FilterByCategoryRecursive(node.Right, category, result);
            }
        }

        // Method to get all unique categories from the service requests
        public HashSet<string> GetAllCategories()
        {
            var categories = new HashSet<string>();
            CollectCategories(root, categories);
            return categories;
        }

        // Recursive method to collect unique categories
        private void CollectCategories(TreeNode node, HashSet<string> categories)
        {
            if (node != null)
            {
                // Add the category of the current request to the set
                categories.Add(node.Request.Category);

                // Traverse left and right subtrees
                CollectCategories(node.Left, categories);
                CollectCategories(node.Right, categories);
            }
        }
    }
}
