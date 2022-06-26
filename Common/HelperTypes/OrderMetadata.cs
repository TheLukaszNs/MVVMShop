using System;

namespace MVVMShop.Common.HelperTypes;

public class OrderMetadata
{
    public string PaymentMethod { get; set; }
    public string ShipmentMethod { get; set; }
    public string Address { get; set; }
    public string PostalCode { get; set; }
    public uint Points { get; set; }
    public decimal Value { get; set; }
    public Guid UserId { get; set; }
}