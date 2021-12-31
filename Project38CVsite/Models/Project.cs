using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project38CVsite.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<UserProject> UserProjects { get; set; }

        public string ManagerId { get; set; }
        [ForeignKey("ManagerId")]
        public ApplicationUser Manager { get; set; }

    }

}