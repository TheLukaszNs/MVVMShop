using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;

namespace MVVMShop.Model
{
    public class Order
    {
        public uint? Id { get; set; }
        public User Customer { get; set; }
        public User Assistant { get; set; }
        public decimal Value { get; set; }
        public string Address { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public PaymentMethod Payment { get; set; }
        public DeliveryMethod Delivery { get; set; }

        public Order(uint? id, User customer, User assistant, decimal value, string address, OrderStatus status,
            DateTime orderDate, PaymentMethod payment, DeliveryMethod delivery)
        {
            Id = id;
            Customer = customer;
            Assistant = assistant;
            Value = value;
            Address = address;
            Status = status;
            OrderDate = orderDate;
            Payment = payment;
            Delivery = delivery;
        }
    }
}