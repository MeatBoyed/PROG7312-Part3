using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MunicipalServiceApp.Modals;

namespace MunicipalServiceApp.DataStructures
{
    /// <summary>
    /// Feature 3 - Min Heap Data Strucutre for Service Requests
    /// </summary>
    internal class MinHeap
    {
        private List<ServiceRequest> heap; // List to store the heap elements

        public MinHeap()
        {
            heap = new List<ServiceRequest>();
        }

        // Method to insert a new service request into the heap
        public void Insert(ServiceRequest request)
        {
            heap.Add(request); // Add the new request at the end
            HeapifyUp(heap.Count - 1); // Restore the heap property
        }

        // Method to filter service requests by status
        public List<ServiceRequest> FilterByStatus(string status)
        {
            List<ServiceRequest> filteredRequests = new List<ServiceRequest>();

            foreach (var request in heap)
            {
                if (request.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                {
                    filteredRequests.Add(request); // Add matching requests to the list
                }
            }

            return filteredRequests; // Return all matching requests
        }

        // Method to maintain the min-heap property after insertion
        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;

                // Compare current node with its parent
                if (heap[index].Id < heap[parentIndex].Id) // Assuming we want to prioritize lower IDs
                {
                    Swap(index, parentIndex);
                    index = parentIndex; // Move up the tree
                }
                else
                {
                    break; // Heap property is satisfied
                }
            }
        }

        // Method to swap two elements in the heap
        private void Swap(int indexA, int indexB)
        {
            var temp = heap[indexA];
            heap[indexA] = heap[indexB];
            heap[indexB] = temp;
        }
    }
}
