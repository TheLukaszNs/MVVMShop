using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVMShop.DTOs;

public class OrdersProductsDTO
{
    [Key] public Guid Id { get; set; }

    public Guid ProductId { get; set; }
    [ForeignKey("ProductId")] public ProductDTO Product { get; set; }

    public Guid OrderId { get; set; }
    [ForeignKey("OrderId")] public OrderDTO Order { get; set; }

    public uint ProductCount { get; set; }
}