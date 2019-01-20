using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string CreatorName { get; set; }

        public DateTime CreationTime { get; set; }

        public Recepie Recepie { get; set; }

        public ApplicationUser Author { get; set; }
    }
}