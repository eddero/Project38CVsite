using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project38CVsite.Models
{
    public class MessageHeader
    {
        public int MessageHeaderId { get; set; }

        public string FromId { get; set; }
        [ForeignKey("FromId")]
        public ApplicationUser FromUser { get; set; }


        public string ToId { get; set; }
        [ForeignKey("ToId")]
        public ApplicationUser ToUser { get; set; }

        public ICollection<Message> messages { get; set; }
    }
}