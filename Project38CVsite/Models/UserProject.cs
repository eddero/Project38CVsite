using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project38CVsite.Models
{
    public class UserProject
    {
       
        //[Key, Column(Order = 1)]
        public int ProjectId { get; set; }
        //[ForeignKey("ProjectID")]
        public  Project Project { get; set; }


        
        public string ApplicationUserId { get; set; }
        //[ForeignKey("ApplicationUserId")]
        public  ApplicationUser ApplicationUser { get; set; }
    }
}