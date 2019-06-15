using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTracker.DBModels
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CaseNbr { get; set; }
        public string CaseURI { get; set; }
    }
}
