using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreelancingSystem.Models
{
    // defining enum for rates 
    public enum JobPostRates
    {
        VeryBad,
        Bad,
        Good,
        VeryGood,
        Excellent

    }
    // class for post rate
    public class JobPostRate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public JobPostRates Rate { get; set; }
        //rated post
        public int PostID { get; set; }

    }

}