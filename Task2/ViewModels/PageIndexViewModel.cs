using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2.ViewModels
{
    public class PageIndexViewModel
    {
        public IEnumerable<Recepie> EnumRecepie { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
