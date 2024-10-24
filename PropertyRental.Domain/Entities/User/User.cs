using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyRental.Domain.Entities.User
{
    public class User: IdentityUser<int>
    {
       
        public string FullName { get; set; }
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }

    }
}
