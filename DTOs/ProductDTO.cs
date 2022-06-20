using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MVVMShop.DTOs;

public class ProductDTO
{
    [Key] public Guid Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public bool Availability { get; set; }
    public string Image { get; set; }
    public uint Points { get; set; }
}