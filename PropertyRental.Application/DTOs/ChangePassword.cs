namespace PropertyRental.API.Controllers
{
    public class ChangePassword
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
    }
}