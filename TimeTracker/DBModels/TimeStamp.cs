using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.DBModels
{
    public class TimeStamp
    {
        public DateTime Stamp { get; set; }
        public Guid ProjectId { get; set; }
        public string Comment { get; set; }
    }
}
