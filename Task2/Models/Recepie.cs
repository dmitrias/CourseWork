using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models
{
    public class Recepie
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string Ingridients { get; set; }
        public string Text { get; set; }
        public string ImageURL { get; set; }
        public DateTime DateOfLastUpdate { get; set; }

        public ApplicationUser RecepieAuthor { get; set; }

        public List<Comment> RecepieComments { get; set; }

    }
}