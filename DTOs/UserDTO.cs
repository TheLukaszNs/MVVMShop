using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVVMShop.DTOs;

public class UserDTO
{
    [Key] public Guid Id { get; set; }
    [Required] public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public uint Points { get; set; }

    public ICollection<OrderDTO> Orders { get; set; }
}