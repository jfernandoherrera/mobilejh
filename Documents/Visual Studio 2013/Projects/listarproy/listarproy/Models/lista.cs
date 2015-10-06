using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace listarproy.Models
{
    public class lista
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int list { get; set; }
        public int Tel { get; set; }
        public long? Cel { get; set; }
        public String Email { get; set; }
        public String Otros { get; set; }
        public Boolean Checked { get; set; }
    }
}