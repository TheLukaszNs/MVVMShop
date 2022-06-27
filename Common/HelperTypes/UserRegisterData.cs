using MVVMShop.DTOs;

namespace MVVMShop.Common.HelperTypes
{
    public sealed class UserRegisterData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}