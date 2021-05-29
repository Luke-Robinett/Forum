using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Reply
    {
        public int ID { get; set;  }
        [Required]
        [MaxLength(3000)]
        public string Message { get; set;  }
        public DateTime Date { get; set; } = DateTime.Now;

        public string ApplicationUserID { get; set;  }
        public ApplicationUser ApplicationUser { get; set;  }

        public int? PostID { get; set;  }
        public Post Post { get; set;  }
    }
}
