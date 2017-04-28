using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cod.Models
{

    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string AdditionalInfo { get; set; }
        public string ImagePath { get; set; }
        public int MarketingPageId { get; set; }
        public virtual MarketingPage MarketingPage { get; set; }

    }
}