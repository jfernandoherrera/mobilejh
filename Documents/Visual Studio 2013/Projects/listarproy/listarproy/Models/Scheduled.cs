using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace listarproy.Models
{
    public class Scheduled
    {
        public int Id { get; set; }
        public DateTime Until { get; set; } 
        public int list { get; set; }
        public int Finished { get; set; }
    }
}