using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Topic
    {
        public int ID { get; set;  }
        public string Title { get; set;  }

        public List<Post> Posts { get; set;  }
    }
}
