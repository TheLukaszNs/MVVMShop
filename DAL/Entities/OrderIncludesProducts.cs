using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Entities
{
    public sealed class OrderIncludesProducts : BaseEntity, IDatabaseReader<OrderIncludesProducts>
    {
        #region Properties

        public uint IDOrder { get; set; }
        public uint IDProduct { get; set; }
        public uint ProductCount { get; set; }

        #endregion

        #region Constructors

        public OrderIncludesProducts() { }

        #endregion

        #region Methods

        public OrderIncludesProducts ReadDataFromDatabase(MySqlDataReader reader) => new OrderIncludesProducts
        {
            Id = uint.Parse(reader["id"].ToString()),
            IDOrder = uint.Parse(reader["id_o"].ToString()),
            IDProduct = uint.Parse(reader["id_p"].ToString()),
            ProductCount = uint.Parse(reader["product_count"].ToString())
        };

        public string Insert() => $"(0, {IDOrder}, {IDProduct}, {ProductCount})";

        #endregion
    }
}
