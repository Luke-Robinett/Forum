using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Reply
    {
        public int ID { get; set;  }
        public string Message { get; set;  }

        public string ApplicationUserID { get; set;  }
        public ApplicationUser ApplicationUser { get; set;  }

        public int? PostID { get; set;  }
        public Post Post { get; set;  }
    }
}
