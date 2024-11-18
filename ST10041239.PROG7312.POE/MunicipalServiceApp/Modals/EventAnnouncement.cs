using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalServiceApp.Modals
{
    // PART 2 
    public enum Category
    {
        All,
        Community,
        Market,
        Entertainment,
        Government,
        Health,
        Festival,
        ServiceUpdate,
        Sports,
        Cultural,
        Utility,
    }

    // Data strucutre for an Event Announcement
    internal class EventAnnouncement
    {
        public int Id { get; set; }                
        public string Title { get; set; }          
        public string Location { get; set; }       
        public DateTime Date { get; set; }         
        public TimeSpan? Time { get; set; }        
        public string Description { get; set; }    
        public Category Category { get; set; }       
        public string ContactInfo { get; set; }    
    }


}
