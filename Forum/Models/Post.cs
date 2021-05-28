using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        public int ID { get; set;  }
        public DateTime Date { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(160)]
        public string Subject { get; set;  }
        [Required]
        [MaxLength(3000)]
        public string Message { get; set;  }

        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set;  }

        public int? TopicID { get; set;  }
        public Topic Topic { get; set;  }

        public List<Reply> Replies { get; set;  }
    }
}
