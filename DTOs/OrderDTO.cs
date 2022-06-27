using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Documents;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVVMShop.DTOs;

public class OrderDTO
{
    [Key] public Guid Id { get; set; }
    public decimal Value { get; set; }
    public DateTime Date { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string PaymentMethod { get; set; }
    public string ShipmentMethod { get; set; }
    public string Address { get; set; }
    public uint Points { get; set; }

    public virtual ICollection<OrdersProductsDTO> OrdersProducts { get; set; }

    public Guid UserId { get; set; }
    [ForeignKey("UserId")] public UserDTO User { get; set; }
}