using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Author
    {
        public int ID { get; set;  }
        public string Username { get; set;  }

        public List<Post> Posts { get; set;  }
        public List<Reply> Replies { get; set;  }
    }
}
