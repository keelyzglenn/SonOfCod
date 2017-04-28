using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace cod.Models
{
    public class Subscriber
    {
        [Key]
        public int SubscriberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string FavoriteFood { get; set; }
        public string Location { get; set; }

    }
}