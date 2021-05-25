using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreelancingSystem.Models
{
    public class Proposal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int FreelancerID { get; set; }
        [Display(Name ="Freelancer name")]
        public string FreelancerName { get; set; }

        public int PostID { get; set; }
        [Display(Name = "Requested budget")]
        public decimal FreelancerBudget { get; set; }
        [Display(Name = "Request")]
        public string Content { get; set; }
        public bool Accepted { get; set; } = false;

    }
}