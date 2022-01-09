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
        public Project()
        {
            DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(1024)]
        public string Title { get; set; }

        [Required]
        [StringLength(1024)]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }

        public string ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public ApplicationUser Manager { get; set; }

        public DateTime? DateCreated { get; set; }


    }

}