using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalService.Modals
{
    // Data strucutre for an Issue Report (a reported issue)
    internal class IssueReport
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string AttachedFile { get; set;}
        public DateTime ReportedDate { get; set; }
        public string Status { get; set; }
    }
}
