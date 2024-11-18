using MunicipalServiceApp.Modals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalServiceApp.Services
{
    // Part 2 - Data Store Service for Events and Anouncements
    internal class EventsDataStoreService
    {
        private Dictionary<int, EventAnnouncement> eventAnnouncements;  // Dictionary to store events and announcements
        private HashSet<Category> uniqueCategories;                     // Set for unique categories
        private Queue<EventAnnouncement> userInteractionQueue;          // Queue for tracking user interactions
        private Dictionary<int, int> clickCount;                        // Dictionary to track click counts for each event

        public EventsDataStoreService()
        {
            eventAnnouncements = new Dictionary<int, EventAnnouncement>(); 
            LoadData();
            userInteractionQueue = new Queue<EventAnnouncement>();          
            clickCount = new Dictionary<int, int>(); 
        }

        /// <summary>
        /// Handles loading dummy data into the store, and initializing the set for unique categories
        /// </summary>
        private void LoadData()
        {
            eventAnnouncements.Add(1, new EventAnnouncement
            {
                Id = 1,
                Title = "Community Clean-Up Day",
                Location = "Central Park",
                Date = new DateTime(2024, 10, 22),
                Time = new TimeSpan(9, 0, 0), // 09 AM
                Description = "Join us for a community clean-up day to help keep our parks clean and beautiful. Supplies will be provided.",
                Category = Category.Community,
                ContactInfo = "contact@community.org"
            });

            eventAnnouncements.Add(2, new EventAnnouncement
            {
                Id = 2,
                Title = "Local Farmers Market",
                Location = "Town Square",
                Date = new DateTime(2024, 10, 15),
                Time = new TimeSpan(8, 0, 0), // 08 AM
                Description = "Come support local farmers and enjoy fresh produce, crafts, and live music at the Town Square.",
                Category = Category.Market,
                ContactInfo = "info@farmersmarket.com"
            });

            eventAnnouncements.Add(3, new EventAnnouncement
            {
                Id = 3,
                Title = "City Council Meeting",
                Location = "City Hall, Room 101",
                Date = new DateTime(2024, 10, 25),
                Time = new TimeSpan(18, 0, 0), // 06 PM
                Description = "Attend the city council meeting to discuss local issues and voice your opinions.",
                Category = Category.Government,
                ContactInfo = "citycouncil@city.gov"
            });

            eventAnnouncements.Add(4, new EventAnnouncement
            {
                Id = 4,
                Title = "Free Health Screening",
                Location = "Community Health Center",
                Date = new DateTime(2024, 10, 30),
                Time = new TimeSpan(10, 0, 0), // 10 AM
                Description = "Get free health screenings, including blood pressure and cholesterol checks. No appointment necessary.",
                Category = Category.Health,
                ContactInfo = "healthcenter@communityhealth.org"
            });

            eventAnnouncements.Add(5, new EventAnnouncement
            {
                Id = 5,
                Title = "Holiday Festival",
                Location = "Downtown Plaza",
                Date = new DateTime(2024, 12, 05),
                Time = new TimeSpan(17, 0, 0), // 05 PM
                Description = "Celebrate the holiday season with food, music, and fun activities for the whole family at the Downtown Plaza.",
                Category = Category.Festival,
                ContactInfo = "festival@holidayevents.com"
            });

            // Make Set for Categories
            uniqueCategories = new HashSet<Category>(eventAnnouncements.Values.Select(e => e.Category));
        }

        /// <summary>
        /// Handles searching the Events and Announcements by category and date range
        /// </summary>
        public List<EventAnnouncement> SearchByCategoryAndDate(Category category, DateTime startDate, DateTime endDate)
        {
            if (category == Category.All) // Allows viewing all categories
                return eventAnnouncements.Values
                    .Where(e => e.Date.Date >= startDate && e.Date.Date <= endDate).ToList();
            return eventAnnouncements.Values
                .Where(e => e.Category == category && e.Date.Date >= startDate && e.Date.Date <= endDate)
                .ToList();
        }

        // Method to track user interaction with an event
        /// <summary>
        /// Handles tracking the user interaction.
        /// </summary>
        /// <param name="eventAnnouncement"></param>
        public void TrackUserInteraction(EventAnnouncement eventAnnouncement)
        {
            // Add the event to the Click Count if it doesn't already exist
            if (!clickCount.ContainsKey(eventAnnouncement.Id))
            {
                clickCount[eventAnnouncement.Id] = 0; // Initialize click count if not present
            }

            clickCount[eventAnnouncement.Id]++; // Increment click count

            // Only adds the event to the queue if it has been clicked more than 3 times
            if (clickCount[eventAnnouncement.Id] > 3) 
            {
                // Limiting the queue to 10 events
                if (userInteractionQueue.Count >= 10) 
                {
                    // Remove oldest interaction if limit exceeded
                    userInteractionQueue.Dequeue(); 
                }

                // Ensures an event is only added once
                if (userInteractionQueue.Contains(eventAnnouncement)) return;

                userInteractionQueue.Enqueue(eventAnnouncement); 
            }
        }

        public Dictionary<int, EventAnnouncement> GetAllEventAnnouncements()
        {
            return eventAnnouncements;
        }

        public HashSet<Category> GetUniqueCategories()
        {
            return uniqueCategories;
        }

        public List<EventAnnouncement> GetRecommendations()
        {
            return userInteractionQueue.ToList(); 
        }
    }
}