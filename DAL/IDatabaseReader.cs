using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL
{
    internal interface IDatabaseReader<T>
    {
        T ReadDataFromDatabase(MySqlDataReader reader);
    }
}
