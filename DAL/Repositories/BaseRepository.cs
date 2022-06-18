using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMShop.DAL.Entities;
using MySql.Data.MySqlClient;

namespace MVVMShop.DAL.Repositories
{
    internal class BaseRepository<T> where T : BaseEntity
    {
        #region Queries

        private const string SELECT_ALL = "SELECT * FROM";
        private const string DELETE = "DELETE FROM ";

        #endregion

        #region Properties

        protected readonly DbConnection dbconnection;
        private readonly string table;

        #endregion

        #region Constuctors

        public BaseRepository(DbConnection dbconnection, string table)
        {
            this.dbconnection = dbconnection;
            this.table = table;
        }

        #endregion

        #region Methods

        public List<T> Get(Func<MySqlDataReader, T> readDataFromDatabase)
        {
            List<T> data = new List<T>();

            using (var connection = dbconnection.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{SELECT_ALL} {table}", connection);

                connection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                    data.Add(readDataFromDatabase(reader));

                connection.Close();
            }

            return data;
        }

        public bool Add(T item, Dictionary<string, string> valueMap)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                MySqlCommand command = new MySqlCommand($"INSERT {table} VALUE {ValueMapToCommandInsert(valueMap)}",
                    connection);
                AddParametersFromValueMap(valueMap, command);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                {
                    state = true;
                    item.Id = (uint)command.LastInsertedId;
                }

                connection.Close();
            }

            return state;
        }

        public bool Edit(uint id, string modifyCommand)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                string MODIFY = $"UPDATE {table} " +
                                $"SET " +
                                $"{modifyCommand}" +
                                $"WHERE " +
                                $"id={id}";

                MySqlCommand command = new MySqlCommand(MODIFY, connection);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    state = true;

                connection.Close();
            }

            return state;
        }

        public bool Delete(uint id)
        {
            bool state = false;

            using (var connection = dbconnection.Connection)
            {
                MySqlCommand command = new MySqlCommand($"{DELETE}{table} WHERE id={id}", connection);

                connection.Open();

                if (command.ExecuteNonQuery() == 1)
                    state = true;

                connection.Close();
            }

            return state;
        }

        private string ValueMapToCommandInsert(Dictionary<string, string> valueMap)
        {
            var insert = new StringBuilder();

            insert.Append("(0,");
            insert.Append(String.Join(",", valueMap.Keys));
            insert.Append(")");

            return insert.ToString();
        }

        private void AddParametersFromValueMap(Dictionary<string, string> valueMap, MySqlCommand command)
        {
            foreach (var parameter in valueMap)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }
        }

        #endregion
    }
}