using System;
using MVVMShop.DTOs;

namespace MVVMShop.Model;

public class Order
{
    public Guid Id { get; set; }
    public User Customer { get; set; }
    public User Assistant { get; set; }
    public decimal Value { get; set; }
    public string Address { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime OrderDate { get; set; }
    public string Payment { get; set; }
    public string Delivery { get; set; }
    public uint Points { get; set; }

    public Order()
    {
    }
}