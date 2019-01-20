using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task2.Models.ManageViewModels
{
    public class UsersRecepiesViewModel
    {
            public ApplicationUser UserCreator { get; set; }
            public List<Recepie> UserRecepie { get; set; }

            public UsersRecepiesViewModel(ApplicationUser userCreator, List<Recepie> userRecepie)
            {
                UserCreator = userCreator;
                UserRecepie = userRecepie;
            }
    }
}
