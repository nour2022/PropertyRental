using Microsoft.AspNetCore.Identity;

namespace PropertyRental.Domain.Entities.User
{
    public class Role:IdentityRole<int>
    {
    
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
}