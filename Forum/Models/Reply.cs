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

        public int? AuthorID { get; set;  }
        public Author Author { get; set;  }

        public int? PostID { get; set;  }
        public Post Post { get; set;  }
    }
}
