using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FreelancingSystem.Models
{
    public class FrAppliedPost
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int FreelancerID { get; set; }
    }
}