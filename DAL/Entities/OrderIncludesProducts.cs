using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Entities
{
    public sealed class OrderIncludesProducts
    {
        #region Properties

        public uint? Id { get; set; }
        public uint IDOrder { get; set; }
        public uint IDProduct { get; set; }
        public uint ProductCount { get; set; }

        #endregion

        #region Constructors

        public OrderIncludesProducts(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["id"].ToString());
            IDOrder = uint.Parse(reader["id_o"].ToString());
            IDProduct = uint.Parse(reader["id_p"].ToString());
            ProductCount = uint.Parse(reader["product_count"].ToString());
        }

        #endregion

        #region Methods

        public string Insert() => $"(0, {IDOrder}, {IDProduct}, {ProductCount})";

        #endregion
    }
}
