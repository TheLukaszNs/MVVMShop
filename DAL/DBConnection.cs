using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL
{
    public sealed class DbConnection
    {
        private readonly MySqlConnectionStringBuilder _stringBuilder;

        public MySqlConnection Connection => new MySqlConnection(_stringBuilder.ToString());

        public DbConnection()
        {
            _stringBuilder = new MySqlConnectionStringBuilder
            {
                UserID = Properties.Settings.Default.DB_USER,
                Password = Properties.Settings.Default.DB_PASSWD,
                Server = Properties.Settings.Default.DB_ADDR,
                Port = Properties.Settings.Default.DB_PORT,
                Database = Properties.Settings.Default.DB_DATABASE
            };
        }
    }
}