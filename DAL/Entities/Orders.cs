using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Entities
{
    #region Status

    public enum OrderStatus
    {
        InProgress,
        Completed,
        Canceled
    }

    #endregion

    #region Payment

    public enum PaymentMethod
    {
        Cash,
        Card
    }

    #endregion

    #region Delivery

    public enum DeliveryMethod
    {
        Courier,
        Paczkomat,
        Post
    }

    #endregion

    public sealed class Orders : BaseEntity, IDatabaseReader<Orders>
    {
        #region Properties

        public uint IDCustomer { get; set; }
        public uint IDAssisstant { get; set; }
        public decimal OrderValue { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public string Address { get; set; }
        public PaymentMethod Payment { get; set; }
        public DeliveryMethod Delivery { get; set; }

        #endregion

        #region Constructors

        public Orders()
        {
        }

        public Orders(uint IDCustomer, uint IDAssisstant, decimal orderValue, OrderStatus status, DateTime orderDate,
            string address, PaymentMethod payment, DeliveryMethod delivery)
        {
            Id = null;
            this.IDCustomer = IDCustomer;
            this.IDAssisstant = IDAssisstant;
            OrderValue = orderValue;
            Status = status;
            OrderDate = orderDate;
            Address = address.Trim();
            Payment = payment;
            Delivery = delivery;
        }

        public Orders(Orders orders)
        {
            Id = orders.Id;
            IDCustomer = orders.IDCustomer;
            IDAssisstant = orders.IDAssisstant;
            OrderValue = orders.OrderValue;
            Status = orders.Status;
            OrderDate = orders.OrderDate;
            Address = orders.Address;
            Payment = orders.Payment;
            Delivery = orders.Delivery;
        }

        #endregion

        #region Methods

        public Orders ReadDataFromDatabase(MySqlDataReader reader) => new Orders
        {
            Id = uint.Parse(reader["id"]
                .ToString()),
            IDCustomer = uint.Parse(reader["id_c"]
                .ToString()),
            IDAssisstant = uint.Parse(reader["id_a"]
                .ToString()),
            OrderValue = decimal.Parse(reader["order_value"]
                .ToString()),
            Status = (OrderStatus)Enum.Parse(typeof(OrderStatus), reader["order_status"]
                .ToString()),
            OrderDate = DateTime.Parse(reader["order_date"]
                .ToString()),
            Address = reader["address"]
                .ToString(),
            Payment = (PaymentMethod)Enum.Parse(typeof(PaymentMethod), reader["payment_method"]
                .ToString()),
            Delivery = (DeliveryMethod)Enum.Parse(typeof(DeliveryMethod), reader["delivery_method"]
                .ToString())
        };

        public string Insert() =>
            $"(0, {IDCustomer}, {IDAssisstant}, {OrderValue}, {Status}, {OrderDate}, {Address}, {Payment}, {Delivery})";

        public override string ToString() => $"{Id} {OrderValue} {OrderDate} {Status}";

        public override bool Equals(object obj)
        {
            var order = obj as Orders;

            if (order is null)
                return false;

            if (IDCustomer != order.IDCustomer)
                return false;

            if (IDAssisstant != order.IDAssisstant)
                return false;

            if (OrderValue != order.OrderValue)
                return false;

            if (OrderDate != order.OrderDate)
                return false;

            if (Address != order.Address)
                return false;

            if (Payment != order.Payment)
                return false;

            if (Delivery != order.Delivery)
                return false;

            return true;
        }

        public override int GetHashCode() => base.GetHashCode();

        #endregion

        public static BaseEntity FromDatabaseReader(MySqlDataReader reader)
        {
            return new Orders();
        }
    }
}