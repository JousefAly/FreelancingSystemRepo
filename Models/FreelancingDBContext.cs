using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FreelancingSystem.Models
{
    public class FreelancingDBContext : DbContext
    {
        public FreelancingDBContext() : base("FreelanincgConnectionString")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Freelancer> Freelancers { get; set; }
        public DbSet<JobPost> JobPosts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ClientProposal> ClientProposals { get; set; }
        public DbSet<FrSavedPost> FrSavedPosts { get; set; }
        public DbSet<JobPostRate> JobPostRates { get; set; }
        public DbSet<FrAppliedPost> FrAppliedPosts { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
    }
}