using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL
{
    internal sealed class DBConnection
    {
        private MySqlConnectionStringBuilder stringBuilder = new MySqlConnectionStringBuilder();

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBConnection();

                return instance;
            }
        }

        public MySqlConnection Connection => new MySqlConnection(stringBuilder.ToString());

        private DBConnection()
        {
            stringBuilder.UserID = Properties.Settings.Default.DB_USER;
            stringBuilder.Password = Properties.Settings.Default.DB_PASSWD;
            stringBuilder.Server = Properties.Settings.Default.DB_ADDR;
            stringBuilder.Port = Properties.Settings.Default.DB_PORT;
            stringBuilder.Database = Properties.Settings.Default.DB_DATABASE;
        }
    }
}
