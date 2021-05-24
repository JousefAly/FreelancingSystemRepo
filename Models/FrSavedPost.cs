using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreelancingSystem.Models
{
    // this class defines relation between freelancer and his saved post as many to many
    public class FrSavedPost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int  PostID { get; set; }
        public int FreeLancerID { get; set; }

    }
}