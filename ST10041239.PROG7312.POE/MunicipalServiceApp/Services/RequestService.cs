using MunicipalServiceApp.DataStructures;
using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServiceApp.Services
{
    // Part 3 - Data Store Service for Service Requests
    internal class RequestService 
    {
        private BinarySearchTree serviceRequestBST;     // Feature 1 - Binary Search Tree to store Requests, and find by ID
        private BinaryTree serviceRequestBT;            // Feature 2 - Binary Tree to store Requests, and Filter by Category
        private MinHeap serviceRequestsHeap;            // Feature 3 - Min Heap to store Requests, and Filter by Status
        private List<ServiceRequest> serviceRequests;  // Dictionary to store events and announcements

        // Available statuses 
        public static readonly List<string> AvailableStatuses = new List<string>
        {
            "In-Progress",
            "Completed",
            "Cancelled"
        };

        public RequestService()
        {
            serviceRequests = new List<ServiceRequest>(); 
            serviceRequestBST = new BinarySearchTree();
            serviceRequestBT = new BinaryTree();
            serviceRequestsHeap = new MinHeap();
            LoadData();
        }

        /// <summary>
        /// Handles loading dummy data into the store, and initializing the set for unique categories
        /// </summary>
        private void LoadData()
        {
           serviceRequests = GenerateData();

            // Insert each request into the Tree for population
            foreach (ServiceRequest request in serviceRequests)
            {
                serviceRequestBST.Insert(request); 
                serviceRequestBT.Insert(request);
                serviceRequestsHeap.Insert(request);
            }

            // Make Set for Categories
            //uniqueCategories = new HashSet<Category>(serviceRequests.Values.Select(e => e.Category));
        }

        /// <summary>
        /// Feature 1 - Search by ID (Binary Search)
        /// Uses Binary Search Tree to execute searching by provided Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ServiceRequest SearchById(int id)
        {
            return serviceRequestBST.SearchById(id); // Use the BST's search method
        }

        /// <summary>
        /// Feature 2 - Filter by Category (Binary Tree)
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public List<ServiceRequest> FilterByCategory(string category)
        {
            if (category == "All") {  return serviceRequests; }
            return serviceRequestBT.FilterByCategory(category); // Uses the binary tree's filter method
        }
        public HashSet<string> GetAllCategories() // Helper method for the UI
        {
            return serviceRequestBT.GetAllCategories(); // Uses the binary tree's method to get all categories
        }

        /// <summary>
        /// Feature 3 - Filter by Status (Min Heap)
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<ServiceRequest> FilterByStatus(string status)
        {
            if (status == "All") {  return serviceRequests; }
            return serviceRequestsHeap.FilterByStatus(status); // Use the heap's filter method
        }
        public List<string> GetAvailableStatuses()
        {
            return AvailableStatuses; // Return the list of statuses
        }


        public List<ServiceRequest> GetAllServiceRequests()
        {
            return serviceRequests;
        }


        /// <summary>
        /// Generates dummy data of Service Requests in a standard list
        /// </summary>
        /// <returns></returns>
        public List<ServiceRequest> GenerateData()
        {

            return new List<ServiceRequest>
                {
                    new ServiceRequest
                    {
                        Id = 1,
                        Location = "123 Main St",
                        Category = "Road Maintenance",
                        Description = "Pothole on Main Street needs repair.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-5),
                        Status = "In-Progress"
                    },
                    new ServiceRequest
                    {
                        Id = 2,
                        Location = "456 Elm St",
                        Category = "Waste Management",
                        Description = "Missed garbage collection this week.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-2),
                        Status = "Completed"
                    },
                    new ServiceRequest
                    {
                        Id = 3,
                        Location = "789 Oak St",
                        Category = "Street Lighting",
                        Description = "Street light is out on Oak Street.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-10),
                        Status = "Cancelled"
                    },
                    new ServiceRequest
                    {
                        Id = 4,
                        Location = "321 Pine St",
                        Category = "Traffic Signals",
                        Description = "Traffic signal not functioning at Pine and 1st.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-3),
                        Status = "In-Progress"
                    },
                    new ServiceRequest
                    {
                        Id = 5,
                        Location = "654 Maple St",
                        Category = "Public Parks",
                        Description = "Park benches need repair.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-7),
                        Status = "Completed"
                    },
                    new ServiceRequest
                    {
                        Id = 6,
                        Location = "987 Cedar St",
                        Category = "Water Supply",
                        Description = "Low water pressure in the area.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-1),
                        Status = "In-Progress"
                    },
                    new ServiceRequest
                    {
                        Id = 7,
                        Location = "135 Birch St",
                        Category = "Public Transport",
                        Description = "Bus stop sign is missing.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-4),
                        Status = "Completed"
                    },
                    new ServiceRequest
                    {
                        Id = 8,
                        Location = "246 Spruce St",
                        Category = "Building Permits",
                        Description = "Need to check the status of my building permit application.",
                        AttachedFile = null,
                        ReportedDate = DateTime.Now.AddDays(-6),
                        Status = "Cancelled"
                    },
                    new ServiceRequest
                    {
                       Id=9,
                       Location="159 Willow St",
                       Category="Noise Complaint",
                       Description="Loud music from neighbors late at night.",
                       AttachedFile=null,
                       ReportedDate=DateTime.Now.AddDays(-8),
                       Status="In-Progress"
                   },
                   new ServiceRequest
                   {
                       Id=10,
                       Location="753 Fir St",
                       Category="Sidewalk Repair",
                       Description="Cracked sidewalk causing tripping hazard.",
                       AttachedFile=null,
                       ReportedDate=DateTime.Now.AddDays(-9),
                       Status="Completed"
                   },
                   new ServiceRequest
                   {
                       Id=11,
                       Location="852 Cherry St",
                       Category="Graffiti Removal",
                       Description="Graffiti on public wall needs removal.",
                       AttachedFile=null,
                       ReportedDate=DateTime.Now.AddDays(-3),
                       Status="In-Progress"
                   },
                   new ServiceRequest
                   {
                       Id=12,
                       Location="963 Peach St",
                       Category="Environmental Issues",
                       Description="Illegal dumping reported in the area.",
                       AttachedFile=null,
                       ReportedDate=DateTime.Now.AddDays(-5),
                       Status="Cancelled"
                   },
                   new ServiceRequest
                   {
                       Id=13,
                       Location="147 Plum St",
                       Category="Animal Control",
                       Description="Stray dog spotted in the neighborhood.",
                       AttachedFile=null,
                       ReportedDate=DateTime.Now.AddDays(-2),
                       Status="Completed"
                   },
                   new ServiceRequest
                   {
                      Id=14,
                      Location="258 Grape St",
                      Category="Fire Safety",
                      Description="Fire hydrant needs inspection.",
                      AttachedFile=null,
                      ReportedDate=DateTime.Now.AddDays(-1),
                      Status="In-Progress"
                   },
                   new ServiceRequest
                   {
                      Id=15,
                      Location="369 Lemon St",
                      Category="Public Health",
                      Description="Need information on vaccination clinics.",
                      AttachedFile=null,
                      ReportedDate=DateTime.Now.AddDays(-4),
                      Status="Cancelled"
                   }
                };

        }
    }
}