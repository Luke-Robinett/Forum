using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        public int ID { get; set;  }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Subject { get; set;  }
        public string Message { get; set;  }

        public int? AuthorID { get; set; }
        public Author Author { get; set;  }

        public int? TopicID { get; set;  }
        public Topic Topic { get; set;  }

        public List<Reply> Replies { get; set;  }
    }
}
