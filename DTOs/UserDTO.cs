using System;
using System.ComponentModel.DataAnnotations;
using MVVMShop.DAL.Entities;

namespace MVVMShop.DTOs;

public enum UserRole
{
    Admin,
    Pracownik,
    Klient,
}

public class UserDTO
{
    [Key] public Guid Id { get; set; }
    [Required] public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserRole Role { get; set; }
    public uint Points { get; set; }
}