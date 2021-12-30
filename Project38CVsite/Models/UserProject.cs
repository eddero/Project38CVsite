using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project38CVsite.Models
{
    public class UserProject
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}