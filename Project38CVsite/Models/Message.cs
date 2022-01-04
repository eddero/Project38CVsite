﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project38CVsite.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }


        public string FromUserId { get; set; }
        [ForeignKey("FromUserId")]
        public ApplicationUser FromUser { get; set; }

        public string ToUserId { get; set; }
        [ForeignKey("ToUserId")]
        public ApplicationUser User { get; set; }


    }
}